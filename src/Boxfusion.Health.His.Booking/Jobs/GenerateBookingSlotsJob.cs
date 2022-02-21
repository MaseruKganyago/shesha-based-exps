using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Bookings.Helpers.Slots;
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
        private readonly IGenerateBookingSlotsHelper _generateBookingSlots; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="generateBookingSlots"></param>
        public GenerateBookingSlotsJob(IGenerateBookingSlotsHelper generateBookingSlots)
        {
            _generateBookingSlots = generateBookingSlots;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task DoExecuteAsync(CancellationToken cancellationToken)
        {
            await _generateBookingSlots.GenerateBookingSlotsAsync();
        }
    }
}
