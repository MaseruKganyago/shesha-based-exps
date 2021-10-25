using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.DiagnosticTestServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDiagnosticTestServiceRequestsAppService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<DiagnosticTestServiceRequestResponse>> GetAllDiagnosticTestServiceRequestsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> GetDiagnosticTestServiceRequestAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<DiagnosticTestServiceRequestResponse>> GetDiagnosticTestServiceRequestsByPatientAsync(Guid patientId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<DiagnosticTestServiceRequestResponse>> GetDiagnosticTestServiceRequestsByPratitionerAsync(Guid practitionerId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> CreateDiagnosticTestServiceRequestAsync(DiagnosticTestServiceRequestInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> UpdateDiagnosticTestServiceRequestAsync(DiagnosticTestServiceRequestUpdate input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteDiagnosticTestServiceRequestAsync(Guid id, Guid fileId);
    }
}
