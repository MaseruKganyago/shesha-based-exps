using Abp.Application.Services;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdmissionsAppService : IApplicationService
    {
        /// <summary>
        /// This function is used for Accepting and Rejecting Transfers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AcceptOrRejectTransfersResponse> AcceptOrRejectTransfers(AcceptOrRejectTransfersInput input);
        Task<WardCensusResponse> GetWardCensusDailyStats(WardCensusInput input);
        Task<WardCensusResponse> GetWardCensusMonthlyStats(WardCensusInput input);
    }
}
