using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Application.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Services.TempAdmissions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdmissionsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AcceptOrRejectTransfersResponse> AcceptOrRejectTransfers(AcceptOrRejectTransfersInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="admissionStatus"></param>
        /// <returns></returns>
        Task<List<AdmissionResponse>> GetAllByStatusAsync(Guid wardId, RefListAdmissionStatuses admissionStatus);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AdmissionResponse>> GetAllAsync(Guid wardId, DateTime admissionDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientIdGuid"></param>
        /// <param name="partOfId"></param>
        /// <returns></returns>
        Task<List<AdmissionResponse>> GetPatientAuditTrailAsync(Guid partOfId);

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
