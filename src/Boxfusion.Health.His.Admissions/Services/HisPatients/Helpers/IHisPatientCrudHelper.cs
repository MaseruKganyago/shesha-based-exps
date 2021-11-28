using Boxfusion.Health.His.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.HisPatients.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHisPatientCrudHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<HisPatientResponse>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        Task<HisPatientResponse> GetByIdNumberAsync(string identityNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HisPatientResponse> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<HisPatientResponse> CreateAsync(HisPatientInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<HisPatientResponse> UpdateAsync(HisPatientInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
