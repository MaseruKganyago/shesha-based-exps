using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    public interface  IHisWardsAppService : IApplicationService
    {
        Task<List<WardResponse>> GetAssignedWards();
        Task<List<HospitalResponse>> GetAssignedHospitals();
        Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> ApproveLevel1(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> ApproveLevel2(WardCensusInput input);
        Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<WardResponse>> GetWardsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<WardResponse>> GetWardByHospitalAsync(Guid hospitalId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="term"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<AutocompleteItemDto>> GetWardByHospitalAutoCompleteAsync(Guid hospitalId, string term);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WardResponse> GetWardAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WardResponse> CreateWardAsync(WardInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WardResponse> UpdateWardAsync(WardInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteWardAsync(Guid id);
    }
}
