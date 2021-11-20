using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdmissionCrudHelper
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //Task<List<AdmissionResponse>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <param name="currentWardId"></param>
        /// <returns></returns>
        Task ValidateIdentityNumber(string identityNumber, Guid currentWardId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AdmissionResponse> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AdmissionResponse> CreateAsync(AdmissionInput input, PersonFhirBase currentLoggedInPerson);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<AdmissionResponse> UpdateAsync(AdmissionInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
