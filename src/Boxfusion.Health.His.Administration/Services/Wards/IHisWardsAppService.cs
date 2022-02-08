using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Administration.Services.Wards.Dtos;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    public interface  IHisWardsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<HisWardResponse>> GetAssignedWards();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<HospitalResponse>> GetAssignedHospitals();
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<HisWardResponse>> GetWardsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<HisWardResponse>> GetWardByHospitalAsync(Guid hospitalId);

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
        Task<HisWardResponse> GetWardAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<HisWardResponse> CreateWardAsync(HisWardInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<HisWardResponse> UpdateWardAsync(HisWardInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteWardAsync(Guid id);
    }
}
