using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.His.Admissions.Services.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Users.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHisUserCrudHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<HisUserResponse>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        Task<HisUserResponse> GetByIdNumberAsync(string identityNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HisUserResponse> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<HisUserResponse> CreateAsync(HisUserInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<HisUserResponse> UpdateAsync(HisUserInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
