using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReferralServiceRequestHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ReferralServiceRequestResponse>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> GetAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<ReferralServiceRequestResponse>> GetByPatientAsync(Guid patientId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<ReferralServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> CreateAsync(ReferralServiceRequestInput input, Person practitioner);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> UpdateAsync(ReferralServiceRequestUpdate input, Person practitioner);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, Guid fileId);
    }
}
