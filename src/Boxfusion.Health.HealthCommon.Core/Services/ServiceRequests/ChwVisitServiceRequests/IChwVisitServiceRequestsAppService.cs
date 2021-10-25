using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ChwVisitServiceRequests.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ChwVisitServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    public interface IChwVisitServiceRequestsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ChwVisitServiceRequestsResponse>> GetAllChwVisitServiceRequestsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ChwVisitServiceRequestsResponse> GetChwVisitServiceRequestAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<ChwVisitServiceRequestsResponse>> GetChwVisitServiceRequestsByPatientAsync(Guid patientId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<ChwVisitServiceRequestsResponse>> GetChwVisitServiceRequestsByPratitionerAsync(Guid practitionerId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ChwVisitServiceRequestsResponse> CreateChwVisitServiceRequestAsync(ChwVisitServiceRequestsInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ChwVisitServiceRequestsResponse> UpdateChwVisitServiceRequestAsync(ChwVisitServiceRequestsInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteChwVisitServiceRequestAsync(Guid id);
    }
}
