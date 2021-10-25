using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.AmbulanceServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAmbulanceServiceRequestHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AmbulanceServiceRequestResponse>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmbulanceServiceRequestResponse> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<AmbulanceServiceRequestResponse>> GetByPatientAsync(Guid patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<AmbulanceServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<AmbulanceServiceRequestResponse> CreateAsync(AmbulanceServiceRequestInput input, Person practitioner);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<AmbulanceServiceRequestResponse> UpdateAsync(AmbulanceServiceRequestInput input, Person practitioner);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
