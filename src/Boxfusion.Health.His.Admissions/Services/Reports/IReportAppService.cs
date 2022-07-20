using Abp.Application.Services;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports.Dtos;
using Boxfusion.Health.His.Common.Enums;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Services 
{ 
    /// <summary>
    /// 
    /// </summary>
    public interface IReportAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        Task<List<ReportResponseDto>> GetReport(RefListReportTypes reportType, Guid wardId, DateTime filterDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<DashboardResponseDto>> GetDashboard(Guid? hospitalId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardMidnightCensusReport, Guid>> ApproveLevel1(WardCensusQueryInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardMidnightCensusReport, Guid>> ApproveLevel2(WardCensusQueryInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardMidnightCensusReport, Guid>> GetWardDailyReport(WardCensusQueryInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardMidnightCensusReport, Guid>> GetWardMonthlyReport(WardCensusQueryInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardMidnightCensusReport, Guid>> SubmitForApproval(WardCensusQueryInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardMidnightCensusReport, Guid>> Reject(RejectReportInput input);
    }
}
