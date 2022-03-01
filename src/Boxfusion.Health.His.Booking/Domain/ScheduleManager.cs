using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
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
    public class ScheduleManager : DomainService
    {
        private readonly IRepository<CdmSchedule, Guid> _schedulesRepo;
        private readonly IRepository<ScheduleAvailabilityForBooking, Guid> _scheduleAvailabilityRepo;
        private readonly IRepository<CdmSlot, Guid> _slotsRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulesRepo"></param>
        /// <param name="scheduleAvailabilityRepo"></param>
        /// <param name="slotsRepo"></param>
        public ScheduleManager(IRepository<CdmSchedule, Guid> schedulesRepo,
            IRepository<ScheduleAvailabilityForBooking, Guid> scheduleAvailabilityRepo,
            IRepository<CdmSlot, Guid> slotsRepo)
        {
            _schedulesRepo = schedulesRepo;
            _scheduleAvailabilityRepo = scheduleAvailabilityRepo;
            _slotsRepo = slotsRepo;
        }

        //public ScheduleManager()
        //{
        //    _schedulesRepo = Resolve<IRepository<CdmSchedule, Guid>>();
        //    _scheduleAvailabilityRepo = Resolve<IRepository<CdmSchedule, Guid>>();
        //    _slotsRepo = Resolve<IRepository<CdmSchedule, Guid>>();

        //    _scheduleRepository = Resolve<IRepository<CdmSchedule, Guid>>();
        //    _facilityRepository = Resolve<IRepository<Hospital, Guid>>();
        //    _safbRepository = Resolve<IRepository<ScheduleAvailabilityForBooking, Guid>>();
        //    _slotsRepository
        //}

        #region GenerateBookingSlots

        /// <summary>
        /// Generate booking slots for all active Schedules where SchedulingModel is Appointment.
        /// </summary>
        /// <returns></returns>
        public async Task GenerateBookingSlotsForAllSchedulesAsync()
        {
            var schedules = await _schedulesRepo.GetAllListAsync(e => e.SchedulingModel == RefListSchedulingModels.Appointment && e.Active);

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
            if (schedule.SchedulingModel != RefListSchedulingModels.Appointment) throw new InvalidOperationException("Operation is only valid if Schedule.SchedulingModel is Appointment.");

            var scheduleAvailabilities = await _scheduleAvailabilityRepo.GetAllListAsync(e => e.Schedule == schedule && e.Active);

            foreach (var scheduleAvailability in scheduleAvailabilities)
            {
                await GenerateBookingSlotsForScheduleAvailabilityAsync(scheduleAvailability);
            }
        }

        private async Task GenerateBookingSlotsForScheduleAvailabilityAsync(ScheduleAvailabilityForBooking scheduleAvailability)
        {
            if (scheduleAvailability.ApplicableDays == null)
                return;

            //TODO:IH Wrapp all changes in a transaction to ensure data consistency.

            // Determining the date range for which slots are to be generated
            var startDate = scheduleAvailability.LastGeneratedSlotDate ?? DateTime.Now.Date;
            if (scheduleAvailability.ValidFromDate.HasValue && scheduleAvailability.ValidFromDate > startDate)
                startDate = scheduleAvailability.ValidFromDate.Value;

            var endDate = (DateTime.Now.AddDays(scheduleAvailability.BookingHorizon.Value));
            if (scheduleAvailability.ValidToDate.HasValue && scheduleAvailability.ValidToDate < endDate)
                endDate = scheduleAvailability.ValidToDate.Value;

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
        private async Task GenerateBookingsSlotsForTheDayAsync(ScheduleAvailabilityForBooking scheduleAvailability, DateTime d)
        {
            // Check pre-requisite state
            if (!scheduleAvailability.StartTime.HasValue) throw new InvalidOperationException("scheduleAvailability.StartTime should have been defined.");
            if (!scheduleAvailability.EndTime.HasValue) throw new InvalidOperationException("scheduleAvailability.EndTime should have been defined.");
            if (!scheduleAvailability.SlotDuration.HasValue) throw new InvalidOperationException("scheduleAvailability.SlotDuration should have been defined.");

            // Determines the first time slot for the day
            var slotStartTime = d.Date.Add(scheduleAvailability.StartTime.Value);
            var slotEndTime = slotStartTime.AddMinutes(scheduleAvailability.SlotDuration.Value);

            // Creates new time slots until reach the end of the day
            while (slotEndTime.TimeOfDay <= scheduleAvailability.EndTime || slotEndTime.Date == d.Date)
            {
                if ((scheduleAvailability.SlotRegularCapacity ?? 0) > 0)
                    await GenerateBookingSlotsForTimeSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, RefListSlotCapacityTypes.Regular, scheduleAvailability.SlotRegularCapacity.Value);

                if ((scheduleAvailability.SlotOverflowCapacity ?? 0) > 0)
                    await GenerateBookingSlotsForTimeSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, RefListSlotCapacityTypes.Overflow, scheduleAvailability.SlotOverflowCapacity.Value);

                // Calculating the start and end time for the next slot
                slotStartTime = slotEndTime.AddMinutes(scheduleAvailability.BreakIntervalAfterSlot ?? 0);
                slotEndTime = slotStartTime.AddMinutes(scheduleAvailability.SlotDuration.Value);
            }
        }

        private async Task GenerateBookingSlotsForTimeSlotAsync(ScheduleAvailabilityForBooking scheduleAvailability, DateTime slotStartTime, DateTime slotEndTime, RefListSlotCapacityTypes capacityType, int capacity)
        {
            if (scheduleAvailability.SlotGenerationMode == RefListSlotGenerationModes.OneSlotForAllResources)
            {
                await CreateSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, capacityType, capacity);
            }
            else if (scheduleAvailability.SlotGenerationMode == RefListSlotGenerationModes.OneSlotPerResource)
            {
                for (int i = 0; i < capacity; i++)
                {
                    await CreateSlotAsync(scheduleAvailability, slotStartTime, slotEndTime, capacityType, 1);
                }
            }
        }

        private async Task CreateSlotAsync(ScheduleAvailabilityForBooking scheduleAvailability, DateTime slotStartTime, DateTime slotEndTime, RefListSlotCapacityTypes capacityType, int capacity)
        {
            if (capacity <= 0) throw new InvalidOperationException("capacity must be larger than 0");

            await _slotsRepo.InsertAsync(new CdmSlot()
            {
                Schedule = scheduleAvailability.Schedule,
                IsGeneratedFrom = scheduleAvailability,
                StartDateTime = slotStartTime,
                EndDateTime = slotEndTime,
                Status = RefListSlotStatuses.free,
                ServiceCategory = scheduleAvailability.Schedule.ServiceCategory,    //TODO: Cannot be made Enums as list will be data driven
                                                                                    //Speciality = scheduleAvailability.Schedule.Speciality,  //TODO: Cannot be made Enums as list will be data driven
                ServiceType = scheduleAvailability.Schedule.ServiceType,    //TODO: Cannot be made Enums as list will be data driven
                CapacityType = capacityType,
                Capacity = capacity,
                //AppointmentType = RefListAppointmentReasonCodes.ROUTINE
            });
        }

        private bool CheckScheduleApplies(ScheduleAvailabilityForBooking scheduleAvailability, DateTime dt)
        {
            var daysOfWeek = ConverToDaysOfWeek(dt);
            return scheduleAvailability.ApplicableDays.Value.HasFlag(daysOfWeek);
        }

        private HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek ConverToDaysOfWeek(DateTime d)
        {
            bool isPublicHoliday = false; //Check if the day is a public holiday (TODO: Should be made available within framework)

            if (isPublicHoliday)
                return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.pub;

            switch (d.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.mon;
                case DayOfWeek.Tuesday:
                    return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.tue;
                case DayOfWeek.Wednesday:
                    return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.wed;
                case DayOfWeek.Thursday:
                    return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.thu;
                case DayOfWeek.Friday:
                    return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.fri;
                case DayOfWeek.Saturday:
                    return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.sat;
                case DayOfWeek.Sunday:
                    return HealthCommon.Core.Domain.BackBoneElements.Enum.RefListDaysOfWeek.sun;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        #endregion

    }
}
