using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
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
    [ScheduledJob("C9CF60F3-22AC-4756-B7AD-FC3B984D6803", StartUpMode.Automatic, "0 2 * * *")]
    public class GenerateBookingSlotsJob : ScheduledJobBase, ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        public ILogger Logger { get; set; } = new NullLogger();
        private readonly IRepository<Schedule, Guid> _schedules;
        private readonly IRepository<ScheduleAvailability, Guid> _scheduleAvailability;
        private readonly IRepository<Slot, Guid> _slot;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedules"></param>
        /// <param name="scheduleAvailability"></param>
        public GenerateBookingSlotsJob(IRepository<Schedule, Guid> schedules, IRepository<ScheduleAvailability, Guid> scheduleAvailability, IRepository<Slot, Guid> slot)
        {
            _schedules = schedules;
            _scheduleAvailability = scheduleAvailability;
            _slot = slot;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task DoExecuteAsync(CancellationToken cancellationToken)
        {
            //var schedules = await _schedules.GetAll().Where(r => r.ServiceType == RefListServiceTypes.ap)
            var scheduleAvailability = await _scheduleAvailability.GetAll().Where(r => r.Active == true).ToListAsync();
            //var slot = await _slot.FirstOrDefaultAsync(r => r.)
        }
    }
}
