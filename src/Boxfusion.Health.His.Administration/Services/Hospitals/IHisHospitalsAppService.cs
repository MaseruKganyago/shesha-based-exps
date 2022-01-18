using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Contracts.Interfaces.Hospitals
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHisHospitalsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<HospitalResponse>> GetHospitalsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HospitalResponse> GetHospitalAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<HospitalResponse> CreateHospitalAsync(HospitalInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<HospitalResponse> UpdateHospitalAsync(HospitalInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteHospitalAsync(Guid id);
    }
}
