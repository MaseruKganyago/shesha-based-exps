using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.AmbulanceServiceRequests
{
	/// <summary>
	/// 
	/// </summary>
	public interface IAmbulanceServiceRequestAppService: IApplicationService
	{
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AmbulanceServiceRequestResponse>> GetAllAmbulanceServiceRequestsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmbulanceServiceRequestResponse> GetAmbulanceServiceRequestAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<AmbulanceServiceRequestResponse>> GetAmbulanceServiceRequestsByPatientAsync(Guid patientId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<AmbulanceServiceRequestResponse>> GetAmbulanceServiceRequestsByPratitionerAsync(Guid practitionerId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AmbulanceServiceRequestResponse> CreateAmbulanceServiceRequestAsync(AmbulanceServiceRequestInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AmbulanceServiceRequestResponse> UpdateAmbulanceServiceRequestAsync(AmbulanceServiceRequestInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteAmbulanceServiceRequestAsync(Guid id);
    }
}
