using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReferralServiceRequestsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ReferralServiceRequestResponse>> GetAllReferralServiceRequestsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> GetReferralServiceRequestAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<ReferralServiceRequestResponse>> GetReferralServiceRequestsByPatientAsync(Guid patientId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<ReferralServiceRequestResponse>> GetReferralServiceRequestsByPratitionerAsync(Guid practitionerId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> CreateReferralServiceRequestAsync(ReferralServiceRequestInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> UpdateReferralServiceRequestAsync(ReferralServiceRequestUpdate input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteReferralServiceRequestAsync(Guid id, Guid fileId);
    }
}
