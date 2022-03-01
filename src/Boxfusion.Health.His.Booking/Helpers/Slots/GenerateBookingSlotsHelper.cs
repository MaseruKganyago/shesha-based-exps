using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Schedules.Helpers;
using Boxfusion.Health.His.Bookings.Domain.Dtos;
using NHibernate.Linq;
using Shesha.Domain;
using Shesha.NHibernate;
using Shesha.Services;
using Shesha.Sms;
using Shesha.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Helpers.Slots
{
    /// <summary>
    /// 
    /// </summary>
    public class GenerateBookingSlotsHelper : IGenerateBookingSlotsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<CdmSchedule, Guid> _schedules;
        private readonly IRepository<ScheduleAvailabilityForBooking, Guid> _scheduleAvailability;
        private readonly IRepository<CdmSlot, Guid> _slotRepo;
        private readonly IRepository<PublicHoliday, Guid> _publicHolidayRepo;
        private readonly IMapper _mapper;
        private readonly IScheduleHelper<CdmSchedule, CdmScheduleResponse> _scheduleHelperCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedules"></param>
        /// <param name="scheduleAvailability"></param>
        /// <param name="slot"></param>
        /// <param name="publicHolidayRepo"></param>
        /// <param name="mapper"></param>
        public GenerateBookingSlotsHelper(IRepository<CdmSchedule, Guid> schedules,
            IRepository<ScheduleAvailabilityForBooking, Guid> scheduleAvailability,
            IRepository<CdmSlot, Guid> slot,
            IRepository<PublicHoliday, Guid> publicHolidayRepo,
            IMapper mapper)
        {
            _schedules = schedules;
            _scheduleAvailability = scheduleAvailability;
            _slotRepo = slot;
            _publicHolidayRepo = publicHolidayRepo;
            _mapper = mapper;
        }


        #region Refactored Generate Slots

        /// <summary>
        /// Generate booking slots for all active Schedules.
        /// </summary>
        /// <returns></returns>
        public async Task GenerateBookingSlotsForAllSchedulesAsync()
        {
            var schedules = await _schedules.GetAll().Where(r => r.SchedulingModel == RefListSchedulingModels.Appointment && r.Active == true).ToListAsync();

            foreach (var schedule in schedules)
                await GenerateBookingSlotsForScheduleAsync(schedule);
        }

        /// <summary>
        /// Generate booking slots for the specified Schedule accross all its ScheduleAvailabilities
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public async Task GenerateBookingSlotsForScheduleAsync(CdmSchedule schedule)
        {
            var scheduleAvailabilities = await _scheduleAvailability.GetAll().Where(r => r.Active == true && r.Schedule.Id == schedule.Id).ToListAsync();

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
            await _scheduleAvailability.UpdateAsync(scheduleAvailability);

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

            await _slotRepo.InsertAsync(new CdmSlot()
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

        /// 
        /// </summary>
        /// <returns></returns>
        public async Task GenerateBookingSlotsAsync()
        {
            var schedules = await GetSchedules();
            var scheduleAvailabilities = new List<ScheduleAvailabilityForBooking>();

            foreach (var schedule in schedules)
            {
                scheduleAvailabilities.AddRange(await GetScheduleAvailability(schedule));
            }

            foreach (var scheduleAvailability in scheduleAvailabilities)
            {
                if (scheduleAvailability.ApplicableDays == null)
                    continue;

                var bookingHorizon = (DateTime.Now.AddDays(scheduleAvailability.BookingHorizon.Value));

                if (!((scheduleAvailability.LastGeneratedSlotDate >= scheduleAvailability.ValidFromDate && scheduleAvailability.LastGeneratedSlotDate <= scheduleAvailability.ValidToDate)
                    && (bookingHorizon >= scheduleAvailability.ValidFromDate && bookingHorizon <= scheduleAvailability.ValidToDate)))
                    continue;

                var resultsOfConversion = UtilityHelper.GetMultiReferenceListItemValueList(scheduleAvailability.ApplicableDays.Value);
                var dates = new List<DateTime>();
                if (resultsOfConversion != null)
                {
                    for (var dt = scheduleAvailability.LastGeneratedSlotDate.Value; dt <= bookingHorizon; dt = dt.AddDays(1))
                    {
                        var applicableDay = resultsOfConversion.Select(x => x.ItemValue).Where(x => x == transformedDayOfWeek((int)dt.DayOfWeek)).FirstOrDefault();
                        if (applicableDay != null)
                            dates.Add(dt);
                    }
                }

                var initialSlot = new Slot();
                initialSlot.StartDateTime = dates.Min().Date + scheduleAvailability.StartTime;// OrderBy(x => x).FirstOrDefault();
                var initialSlotEndDateTime = initialSlot.StartDateTime.Value
                    .AddMinutes(scheduleAvailability.SlotDuration.Value)
                    .AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value);

                int i = 1;
                var totalSlots = ((scheduleAvailability.EndTime.Value.Ticks - scheduleAvailability.StartTime.Value.Ticks)
                    / (new TimeSpan(initialSlotEndDateTime.Hour, initialSlotEndDateTime.Minute, initialSlotEndDateTime.Second).Ticks - new TimeSpan(initialSlot.StartDateTime.Value.Hour, initialSlot.StartDateTime.Value.Minute, initialSlot.StartDateTime.Value.Second).Ticks));

                foreach (var date in dates)
                {
                    if (initialSlotEndDateTime > date.Add(scheduleAvailability.EndTime.Value))
                        continue;

                    var startDateTime = (i == 1)
                        ? initialSlot.StartDateTime
                        : initialSlot.EndDateTime;

                    var endDateTime = (i == 1)
                        ? initialSlotEndDateTime
                        : initialSlot.EndDateTime.Value
                        .AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value)
                        .AddDays(scheduleAvailability.SlotDuration.Value).AddMinutes(scheduleAvailability.SlotDuration.Value);

                    if (i > 1)
                    {
                        startDateTime = date.Date + scheduleAvailability.StartTime;
                        endDateTime = startDateTime.Value.AddMinutes(scheduleAvailability.SlotDuration.Value)
                                        .AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value);
                    }

                    CdmSlot slot = null;

                    for (int j = 0; j < totalSlots; j++)
                    {
                        if (j > 0)
                        {
                            startDateTime = slot.StartDateTime.Value.AddMinutes(scheduleAvailability.SlotDuration.Value)
                                .AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value);

                            endDateTime = slot.EndDateTime.Value.AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value)
                                .AddDays(scheduleAvailability.SlotDuration.Value).AddMinutes(scheduleAvailability.SlotDuration.Value);

                            slot = null;
                        }

                        slot = await _slotRepo.InsertAsync(new CdmSlot()
                        {
                            Status = RefListSlotStatuses.free,
                            Capacity = scheduleAvailability.SlotRegularCapacity,
                            CapacityType = RefListSlotCapacityTypes.Regular, //To confirm with Ian
                            StartDateTime = startDateTime,
                            EndDateTime = endDateTime,
                            Schedule = scheduleAvailability.Schedule,
                        });

                        initialSlot = slot;
                    }

                    i++;
                }

                //Update Last Generated Slot
                scheduleAvailability.LastGeneratedSlotDate = dates.Max().Date + scheduleAvailability.EndTime;
                await _scheduleAvailability.UpdateAsync(scheduleAvailability);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<PublicHolidaysDto>> GetPublicHolidays()
        {
            return _mapper.Map<List<PublicHolidaysDto>>(await _publicHolidayRepo.GetAllListAsync());
        }

        /// <summary>
        /// ******************************************************************Move to CDM***************************************************
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public async Task<List<ScheduleAvailabilityForBooking>> GetScheduleAvailability(CdmSchedule schedule)
        {
            return await _scheduleAvailability.GetAll().Where(r => r.Active == true && r.Schedule.Id == schedule.Id).ToListAsync();
        }

        /// <summary>
        /// Used for getting Schedules as a single unit for easy unit testing
        /// ******************************************************************Move to CDM***************************************************
        /// </summary>
        /// <returns></returns>
        public async Task<List<CdmSchedule>> GetSchedules()
        {
            var scheduleAvailability = await _schedules.GetAll().Where(r => r.SchedulingModel == RefListSchedulingModels.Appointment && r.Active == true).ToListAsync();
            return scheduleAvailability;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        private int transformedDayOfWeek(int dayOfWeek)
        {
            int result = 128;

            switch (dayOfWeek)
            {
                case 0:
                    result = (int)Math.Pow(2, 6);
                    break;

                case 1:
                    result = (int)Math.Pow(2, 0);
                    break;

                case 2:
                    result = (int)Math.Pow(2, 1);
                    break;

                case 3:
                    result = (int)Math.Pow(2, 2);
                    break;

                case 4:
                    result = (int)Math.Pow(2, 3);
                    break;

                case 5:
                    result = (int)Math.Pow(2, 4);
                    break;

                case 6:
                    result = (int)Math.Pow(2, 5);
                    break;
            }

            return result;
        }

    }
}
