using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITempAdmissionsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AdmissionResponse>> GetAllAsync(Guid wardId, DateTime admissionDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<PatientAuditTrailDto>> GetPatientAuditTrailAsync(Guid patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ValidateIdentityNumber(ValidateIdDto input);

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
        Task<AdmissionResponse> CreateAsync(AdmissionInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
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
