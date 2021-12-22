using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Patients;
using Boxfusion.Health.His.Admissions.Domain;
using Boxfusion.Health.His.Admissions.Services.Reports.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.UI;
using Boxfusion.Health.His.Admissions.Services.Reports.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services;

namespace Boxfusion.Health.His.Admissions.Services.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisAdmis/[controller]")]
    public class ReportAppService : CdmAppServiceBase,  IReportAppService
    {
        private readonly IReportHelper _reportHelper;
        private readonly IRepository<WardRoleAppointedPerson, Guid> _wardRoleRepositiory;

        ///
        public ReportAppService(
            IReportHelper reportHelper,
            IRepository<WardRoleAppointedPerson, Guid> wardRoleRepositiory)
        {
            _reportHelper = reportHelper;
            _wardRoleRepositiory = wardRoleRepositiory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        [HttpGet, Route("Reports")]
        public async Task<List<ReportResponseDto>> GetReport(RefListReportTypes reportType, Guid wardId, DateTime filterDate)
        {
            var reports = await _reportHelper.GetReportAsync(reportType, wardId, filterDate);

            return reports;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="wardId"></param>
        ///// <param name="reportDate"></param>
        ///// <returns></returns>
        //[HttpGet, Route("Dashboards")]
        //public async Task<List<DashboardResponseDto>> GetReport(Guid wardId, DateTime reportDate)
        //{
        //    var dashboards = await _reportHelper.GetDashboardAsync(wardId, reportDate);

        //    return dashboards;
        //}
    }
}
