using Boxfusion.Health.His.Admissions.Services.Reports.Dto;
using Boxfusion.Health.His.Domain.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReportHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        Task<List<ReportResponseDto>> GetReportAsync(RefListReportTypes reportType, Guid wardId, DateTime filterDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<DashboardResponseDto>> GetDashboardAsync(Guid? hospitalId);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //Task<WardMidnightCensusReportResponse> GetWardMonthlyReport(WardCensusInput input);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input);
    }
}
