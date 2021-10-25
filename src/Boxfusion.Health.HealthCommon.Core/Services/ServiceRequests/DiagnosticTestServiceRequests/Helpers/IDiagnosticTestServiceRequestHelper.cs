using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.DiagnosticTestServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDiagnosticTestServiceRequestHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<DiagnosticTestServiceRequestResponse>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> GetAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<DiagnosticTestServiceRequestResponse>> GetByPatientAsync(Guid patientId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<DiagnosticTestServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> CreateAsync(DiagnosticTestServiceRequestInput input, Person practitioner);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> UpdateAsync(DiagnosticTestServiceRequestUpdate input, Person practitioner);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, Guid fileId);
    }
}
