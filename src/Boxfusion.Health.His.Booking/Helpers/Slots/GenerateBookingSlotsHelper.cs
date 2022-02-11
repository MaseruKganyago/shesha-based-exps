using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using NHibernate.Linq;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedules"></param>
        /// <param name="scheduleAvailability"></param>
        /// <param name="slot"></param>
        public GenerateBookingSlotsHelper(IRepository<CdmSchedule, Guid> schedules,
            IRepository<ScheduleAvailabilityForBooking, Guid> scheduleAvailability,
            IRepository<CdmSlot, Guid> slot)
        {
            _schedules = schedules;
            _scheduleAvailability = scheduleAvailability;
            _slotRepo = slot;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task GenerateBookingSlotsAsync()
        {
            var schedules = await Getschedules();
            var scheduleAvailabilities = new List<ScheduleAvailabilityForBooking>();

            foreach (var schedule in schedules)
            {
                scheduleAvailabilities.AddRange(await GetscheduleAvailability(schedule));
            }

            foreach (var scheduleAvailability in scheduleAvailabilities)
            {
                if (scheduleAvailability.ApplicableDays == null)
                    continue;

                var bookingHor = (DateTime.Now.AddDays(scheduleAvailability.BookingHorizon.Value));

                //Unit Testable Logic
                if (!((scheduleAvailability.LastGeneratedSlotDate > scheduleAvailability.ValidFromDate && scheduleAvailability.LastGeneratedSlotDate < scheduleAvailability.ValidToDate) && (bookingHor > scheduleAvailability.ValidFromDate && bookingHor < scheduleAvailability.ValidToDate)))
                    continue;


                var resultsOfConversion = UtilityHelper.GetMultiReferenceListItemValueList(scheduleAvailability.ApplicableDays.Value);
                var dates = new List<DateTime>();
                if (resultsOfConversion != null)
                {
                    for (var dt = scheduleAvailability.LastGeneratedSlotDate.Value; dt <= bookingHor; dt = dt.AddDays(1))
                    {
                        //var applicableDay = resultsOfConversion.Select(x => x.ItemValue).Where(x => x == dt.Day).FirstOrDefault();
                        var applicableDay = resultsOfConversion.FirstOrDefault(r => r.ItemValue == dt.Day);
                        if (applicableDay != null)
                            dates.Add(dt);
                    }
                }

                var tempSlot = new Slot();
                tempSlot.EndDateTime = DateTime.Now;

                int i = 1;
                foreach (var date in dates)
                {
                    var tempSlotEndDateTime = tempSlot.
                        EndDateTime.Value.AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value).AddMinutes(scheduleAvailability.SlotDuration.Value);

                    if (tempSlotEndDateTime > date.Add(scheduleAvailability.EndTime.Value))
                        continue;

                    var slot = await _slotRepo.InsertAsync(new CdmSlot()
                    {
                        StartDateTime = (i == 1) ? date.Add(scheduleAvailability.StartTime.Value) : tempSlot.EndDateTime.Value.AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value).AddMinutes(scheduleAvailability.SlotDuration.Value),

                        EndDateTime = (i == 1) ? date.Add(scheduleAvailability.StartTime.Value).AddMinutes(scheduleAvailability.SlotDuration.Value) : tempSlot.EndDateTime.Value.AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value).AddDays(scheduleAvailability.SlotDuration.Value).AddMinutes(scheduleAvailability.SlotDuration.Value),
                    });

                    tempSlot = slot;
                    i++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public async Task<List<ScheduleAvailabilityForBooking>> GetscheduleAvailability(CdmSchedule schedule)
        {
            return await _scheduleAvailability.GetAll().Where(r => r.Active == true && r.Schedule == schedule).ToListAsync();
        }

        /// <summary>
        /// Used for getting Schedules as a single unit for easy unit testing
        /// </summary>
        /// <returns></returns>
        public async Task<List<CdmSchedule>> Getschedules()
        {
            return await _schedules.GetAll().Where(r => r.SchedulingModel == RefListSchedulingModels.Appointment).ToListAsync();
        }
    }
}
