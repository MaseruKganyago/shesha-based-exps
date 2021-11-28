using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdmissionCrudHelper
    {
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
        /// <param name="currentLoggedInPerson"></param>
        /// <param name="hisPatient"></param>
        /// <returns></returns>
        Task<AdmissionResponse> CreateAsync(AdmissionInput input, PersonFhirBase currentLoggedInPerson, HisPatient hisPatient);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        Task<AdmissionResponse> UpdateAsync(AdmissionInput input, PersonFhirBase currentLoggedInPerson);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalAdmissionId"></param>
        /// <returns></returns>
        Task<List<AdmissionResponse>> GetWardAdmissions(Guid hospitalAdmissionId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<PatientResponse> GetPatient(Guid patientId);
    }
}
