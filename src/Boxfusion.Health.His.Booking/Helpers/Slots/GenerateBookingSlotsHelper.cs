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
        private readonly IScheduleAvailabilityForBookingHelper  _scheduleAvailabilityForBookingHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedules"></param>
        /// <param name="scheduleAvailability"></param>
        /// <param name="slot"></param>
        /// <param name="publicHolidayRepo"></param>
        /// <param name="mapper"></param>
        /// <param name="scheduleHelperCrudHelper"></param>
        /// <param name="scheduleAvailabilityForBookingHelper"></param>
        public GenerateBookingSlotsHelper(IRepository<CdmSchedule, Guid> schedules,
            IRepository<ScheduleAvailabilityForBooking, Guid> scheduleAvailability,
            IRepository<CdmSlot, Guid> slot,
            IRepository<PublicHoliday, Guid> publicHolidayRepo,
            IMapper mapper,
            IScheduleHelper<CdmSchedule, CdmScheduleResponse> scheduleHelperCrudHelper,
            IScheduleAvailabilityForBookingHelper scheduleAvailabilityForBookingHelper)
        {
            _schedules = schedules;
            _scheduleAvailability = scheduleAvailability;
            _slotRepo = slot;
            _publicHolidayRepo = publicHolidayRepo;
            _mapper = mapper;
            _scheduleHelperCrudHelper = scheduleHelperCrudHelper;
            _scheduleAvailabilityForBookingHelper = scheduleAvailabilityForBookingHelper;
        }

        /// <summary>
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
            return await _scheduleAvailabilityForBookingHelper.GetScheduleAvailability(schedule);
        }

        /// <summary>
        /// Used for getting Schedules as a single unit for easy unit testing
        /// ******************************************************************Move to CDM***************************************************
        /// </summary>
        /// <returns></returns>
        public async Task<List<CdmSchedule>> GetSchedules()
        {
            var scheduleAvailability = await _scheduleHelperCrudHelper.GetAllAsync();
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
