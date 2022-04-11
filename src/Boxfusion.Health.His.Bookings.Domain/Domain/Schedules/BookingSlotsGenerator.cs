using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Shesha.AutoMapper.Dto;
using Shesha.Enterprise.PublicHolidays;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Domain
{
    /// <summary>
    /// Domain Service for the Schedule entity.
    /// Includes logic for the generation of Appoitment Booking Slots.
    /// </summary>
    public class BookingSlotsGenerator : DomainService
    {
        private readonly IRepository<CdmSchedule, Guid> _schedulesRepo;
        private readonly IRepository<ScheduleAvailabilityForTimeBooking, Guid> _scheduleAvailabilityRepo;
        private readonly IRepository<CdmSlot, Guid> _slotsRepo;
        private readonly PublicHolidayManager _publicHolidayManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulesRepo"></param>
        /// <param name="scheduleAvailabilityRepo"></param>
        /// <param name="slotsRepo"></param>
        /// <param name="publicHolidayManager"></param>
        public BookingSlotsGenerator(IRepository<CdmSchedule, Guid> schedulesRepo,
            IRepository<ScheduleAvailabilityForTimeBooking, Guid> scheduleAvailabilityRepo,
            IRepository<CdmSlot, Guid> slotsRepo,
            PublicHolidayManager publicHolidayManager)
        {
            _schedulesRepo = schedulesRepo;
            _scheduleAvailabilityRepo = scheduleAvailabilityRepo;
            _slotsRepo = slotsRepo;
            _publicHolidayManager = publicHolidayManager;
        }

        /// <summary>
        /// Generate booking slots for all active Schedules where SchedulingModel is Appointment.
        /// </summary>
        /// <returns></returns>
        public async Task GenerateBookingSlotsForAllSchedulesAsync()
        {
            var schedules = await _schedulesRepo.GetAllListAsync(e => e.SchedulingModel == RefListSchedulingModels.TimeBasedAppointment && e.Active);

            foreach (var schedule in schedules)
            {
                await GenerateBookingSlotsForScheduleAsync(schedule);
            }
        }

        /// <summary>
        /// Generate booking slots for the specified Schedule accross all its ScheduleAvailabilities
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public async Task GenerateBookingSlotsForScheduleAsync(CdmSchedule schedule)
        {
            if (schedule.SchedulingModel != RefListSchedulingModels.TimeBasedAppointment) throw new InvalidOperationException("Operation is only valid if Schedule.SchedulingModel is Appointment.");

            var scheduleAvailabilities = await _scheduleAvailabilityRepo.GetAllListAsync(e => e.Schedule.Id == schedule.Id && e.Active);

            foreach (var scheduleAvailability in scheduleAvailabilities)
            {
                await GenerateBookingSlotsForScheduleAvailabilityAsync(scheduleAvailability);
            }
        }

        /// <summary>
        /// Generate booking slots for the specified Schedule accross all its ScheduleAvailabilities
        /// </summary>
        /// <param name="scheduleId">Id of the schedule for which slots should be generated.</param>
        /// <returns></returns>
        public async Task GenerateBookingSlotsForScheduleAsync(Guid scheduleId)
        {
            var schedule = _schedulesRepo.Get(scheduleId);

            await GenerateBookingSlotsForScheduleAsync(schedule);
        }

        private async Task GenerateBookingSlotsForScheduleAvailabilityAsync(ScheduleAvailabilityForTimeBooking scheduleAvailability)
        {
            if (scheduleAvailability.ApplicableDays == null)
                return;

            //TODO:IH Wrapp all changes in a transaction to ensure data consistency.

            // Determining the date range for which slots are to be generated
            var startDate = scheduleAvailability.LastGeneratedSlotDate.HasValue ? scheduleAvailability.LastGeneratedSlotDate.Value.Date.AddDays(1) : DateTime.Now.Date;
            if (scheduleAvailability.ValidFromDate.HasValue && scheduleAvailability.ValidFromDate > startDate)
                startDate = scheduleAvailability.ValidFromDate.Value.Date;

            var endDate = (DateTime.Now.Date.AddDays(scheduleAvailability.BookingHorizon.Value));
            if (scheduleAvailability.ValidToDate.HasValue && scheduleAvailability.ValidToDate < endDate)
                endDate = scheduleAvailability.ValidToDate.Value.Date;

            // Generating slots for each of the days within date range to which the schedule applies
            var currentDate = startDate;
            while (currentDate <= endDate)
            {
                if (CheckScheduleApplies(scheduleAvailability, currentDate))
                {
                    await GenerateBookingsSlotsForTheDayAsync(scheduleAvailability, currentDate);
                }

                currentDate = currentDate.AddDays(1);
            }

            //Update Last Generated Slot
            scheduleAvailability.LastGeneratedSlotDate = currentDate.AddDays(-1).Add(scheduleAvailability.EndTime.Value);
            await _scheduleAvailabilityRepo.UpdateAsync(scheduleAvailability);
        }

        /// <summary>
        /// Generates all the time slots (both Regular and Overflow) required for the specified day.
        /// </summary>
        /// <param name="scheduleAvailability"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private async Task GenerateBookingsSlotsForTheDayAsync(ScheduleAvailabilityForTimeBooking scheduleAvailability, DateTime d)
        {
            // Check pre-requisite state
            if (!scheduleAvailability.StartTime.HasValue) throw new InvalidOperationException("scheduleAvailability.StartTime should have been defined.");
            if (!scheduleAvailability.EndTime.HasValue) throw new InvalidOperationException("scheduleAvailability.EndTime should have been defined.");
            if (!scheduleAvailability.SlotDuration.HasValue) throw new InvalidOperationException("scheduleAvailability.SlotDuration should have been defined.");

            // Determines the first time slot for the day
            var slotStartTime = d.Date.Add(scheduleAvailability.StartTime.Value);
            var slotEndTime = slotStartTime.AddMinutes(scheduleAvailability.SlotDuration.Value);

            // Creates new time slots until reach the end of the day
            while (slotEndTime.TimeOfDay <= scheduleAvailability.EndTime && slotEndTime.Date == d.Date)
            {
                var capacity = scheduleAvailability.SlotRegularCapacity ?? 0;
                var overflowCapacity = scheduleAvailability.SlotOverflowCapacity ?? 0;
                await GenerateBookingSlotsForTimeSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, capacity, overflowCapacity);

                // Calculating the start and end time for the next slot
                slotStartTime = slotEndTime.AddMinutes(scheduleAvailability.BreakIntervalAfterSlot ?? 0);
                slotEndTime = slotStartTime.AddMinutes(scheduleAvailability.SlotDuration.Value);
            }
        }

        private async Task GenerateBookingSlotsForTimeSlotAsync(ScheduleAvailabilityForTimeBooking scheduleAvailability, DateTime slotStartTime, DateTime slotEndTime, int capacity, int overflowCapacity = 0)
        {
            if (scheduleAvailability.SlotGenerationMode == RefListSlotGenerationModes.OneSlotForAllResources)
            {
                await CreateSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, capacity, overflowCapacity);
            }
            else if (scheduleAvailability.SlotGenerationMode == RefListSlotGenerationModes.OneSlotPerResource)
            {
                for (int i = 0; i < capacity; i++)
                {
                    await CreateSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, 1, 0);
                }
                for (int i = 0; i < overflowCapacity; i++)
                {
                    await CreateSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, 0, 1);
                }
            }
        }

        private async Task CreateSlotAsync(ScheduleAvailabilityForTimeBooking scheduleAvailability, DateTime slotStartTime, DateTime slotEndTime, int capacity, int overflowCapacity = 0)
        {
            if ((capacity + overflowCapacity) <= 0) throw new InvalidOperationException("capacity must be larger than 0");

            await _slotsRepo.InsertAsync(new CdmSlot()
            {
                Schedule = scheduleAvailability.Schedule,
                IsGeneratedFrom = scheduleAvailability,
                StartDateTime = slotStartTime,
                EndDateTime = slotEndTime,
                Status = RefListSlotStatuses.free,
                ServiceCategory = scheduleAvailability.Schedule.ServiceCategory,
                Speciality = scheduleAvailability.Schedule.Speciality,
                ServiceType = scheduleAvailability.Schedule.ServiceType,
                Capacity = capacity,
                OverflowCapacity = overflowCapacity
                //AppointmentType = RefListAppointmentReasonCodes.ROUTINE
            });
        }

        private bool CheckScheduleApplies(ScheduleAvailabilityForTimeBooking scheduleAvailability, DateTime dt)
        {
            var daysOfWeek = ConverToDaysOfWeek(dt);
            return scheduleAvailability.ApplicableDays.Value.HasFlag(daysOfWeek);
        }

        private RefListDaysOfWeek ConverToDaysOfWeek(DateTime d)
        {
            bool isPublicHoliday = _publicHolidayManager.IsHolidayAsync(d).Result; //Check if the day is a public holiday

            if (isPublicHoliday)
                return RefListDaysOfWeek.pub;

            switch (d.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return RefListDaysOfWeek.mon;
                case DayOfWeek.Tuesday:
                    return RefListDaysOfWeek.tue;
                case DayOfWeek.Wednesday:
                    return RefListDaysOfWeek.wed;
                case DayOfWeek.Thursday:
                    return RefListDaysOfWeek.thu;
                case DayOfWeek.Friday:
                    return RefListDaysOfWeek.fri;
                case DayOfWeek.Saturday:
                    return RefListDaysOfWeek.sat;
                case DayOfWeek.Sunday:
                    return RefListDaysOfWeek.sun;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

    }
}
