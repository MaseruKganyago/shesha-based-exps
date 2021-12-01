using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    public interface  IHisWardsAppService : IApplicationService
    {
        Task<List<WardResponse>> GetAssignedWards();
        Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> ApproveLevel1(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> ApproveLevel2(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input);
    }
}
