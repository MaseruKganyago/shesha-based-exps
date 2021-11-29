using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.Scheduler;
using Shesha.Scheduler.Attributes;
using Shesha.Scheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Jobs
{
    /// <summary>
    /// Used to calculate stats daily
    /// </summary>
    [ScheduledJob("C9CF60F3-22AC-4756-B7AD-FC3B984D6811", StartUpMode.Automatic, "* * * * *")]
    public class DailyStatsCalculatorJob : ScheduledJobBase, ITransientDependency
    {
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        public DailyStatsCalculatorJob(IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport)
        {
            _wardMidnightCensusReport = wardMidnightCensusReport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task DoExecuteAsync(CancellationToken cancellationToken)
        {

        }
    }
}
