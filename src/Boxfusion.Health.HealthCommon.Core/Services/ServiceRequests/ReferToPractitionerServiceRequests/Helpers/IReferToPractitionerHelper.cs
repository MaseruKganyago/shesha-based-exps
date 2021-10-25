using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.Domain;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferToPractitionerServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReferToPractitionerHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ReferToPractitionerServiceRequestResponse>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReferToPractitionerServiceRequestResponse> GetAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<ReferToPractitionerServiceRequestResponse>> GetByPatientAsync(Guid patientId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<ReferToPractitionerServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<ReferToPractitionerServiceRequestResponse> CreateAsync(ReferToPractitionerServiceRequestInput input, Person practitioner);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<ReferToPractitionerServiceRequestResponse> UpdateAsync(ReferToPractitionerServiceRequestInput input, Person practitioner);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}



