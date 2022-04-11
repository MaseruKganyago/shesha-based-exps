using Abp.Dependency;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports.Helpers
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

    }
}
