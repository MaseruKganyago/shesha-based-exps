using Abp.Dependency;
using Boxfusion.Health.His.Admissions.Services.Reports.Dto;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHisWardMidnightCensusReportsHelper : ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ResertReportAsync(ResertReportInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateAdmissionAuditTrailAsync(HisAdmissionAuditTrailInput input);
    }
}
