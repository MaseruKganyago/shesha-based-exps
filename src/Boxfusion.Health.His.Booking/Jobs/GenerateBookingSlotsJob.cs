using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Castle.Core.Logging;
using NHibernate.Linq;
using Shesha.Scheduler;
using Shesha.Scheduler.Attributes;
using Shesha.Scheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Jobs
{
    /// <summary>
    /// Creates booking slots so that they can be made available for the booking of appointments.
    /// </summary>
    //[ScheduledJob("C9CF60F3-22AC-4756-B7AD-FC3B984D6803", StartUpMode.Automatic, "0 2 * * *")]
    public class GenerateBookingSlotsJob : ScheduledJobBase, ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        public ILogger Logger { get; set; } = new NullLogger();
        private readonly IRepository<CdmSchedule, Guid> _schedules;
        private readonly IRepository<ScheduleAvailabilityForBooking, Guid> _scheduleAvailability;
        private readonly IRepository<CdmSlot, Guid> _slotRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedules"></param>
        /// <param name="scheduleAvailability"></param>
        public GenerateBookingSlotsJob(IRepository<CdmSchedule, Guid> schedules, 
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task DoExecuteAsync(CancellationToken cancellationToken)
        {
            var schedules = await _schedules.GetAll().Where(r => r.SchedulingModel == RefListSchedulingModels.Appointment).ToListAsync();
            var scheduleAvailabilities = new List<ScheduleAvailabilityForBooking>();

            foreach (var schedule in schedules)
            {
                scheduleAvailabilities.AddRange(await _scheduleAvailability.GetAll().Where(r => r.Active == true && r.Schedule == schedule).ToListAsync());
            }

            foreach(var scheduleAvailability in scheduleAvailabilities)
            {
                if(scheduleAvailability.ApplicableDays == null)
                    continue;

                if (!((scheduleAvailability.LastGeneratedSlotDate > scheduleAvailability.ValidFromDate && scheduleAvailability.LastGeneratedSlotDate < scheduleAvailability.ValidToDate) && (DateTime.Now.AddDays(scheduleAvailability.BookingHorizon.Value) > scheduleAvailability.ValidFromDate && DateTime.Now.AddDays(scheduleAvailability.BookingHorizon.Value) < scheduleAvailability.ValidToDate)))
                    continue;


                var resultsOfConversion = UtilityHelper.GetMultiReferenceListItemValueList(scheduleAvailability.ApplicableDays.Value);
                var dates = new List<DateTime>();
                if (resultsOfConversion != null)
                {
                    for (var dt = scheduleAvailability.LastGeneratedSlotDate.Value; dt <= DateTime.Now.AddDays(scheduleAvailability.BookingHorizon.Value); dt = dt.AddDays(1))
                    {
                        var applicableDay = resultsOfConversion.Select(x => x.ItemValue).Where(x => x == dt.Day).FirstOrDefault();
                        if(applicableDay != null)
                            dates.Add(dt);
                    }
                }

                Slot tempSlot = null;
                int i = 1;
                foreach (var date in dates)
                {
                    if (tempSlot.EndDateTime.Value.AddMinutes(scheduleAvailability.BreakIntervalAfterSlot.Value).AddMinutes(scheduleAvailability.SlotDuration.Value) > date.Add(scheduleAvailability.EndTime.Value))
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
    }
}
