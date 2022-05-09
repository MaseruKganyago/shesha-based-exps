using Abp.Application.Services;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports.Dtos;
using Boxfusion.Health.His.Common.Enums;
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
        Task<WardMidnightCensusReportResponse> ApproveLevel1(WardCensusInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WardMidnightCensusReportResponse> ApproveLevel2(WardCensusInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WardMidnightCensusReportResponse> GetWardMonthlyReport(WardCensusInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input);
    }
}
