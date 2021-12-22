using Abp.Dependency;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    public interface IHisWardMidnightCensusReportsHelper : ITransientDependency
    {
        Task ResertReportAsync(ResertReportInput input);
        Task CreateAdmissionAuditTrailAsync(HisAdmissionAuditTrailInput input);
    }
}
