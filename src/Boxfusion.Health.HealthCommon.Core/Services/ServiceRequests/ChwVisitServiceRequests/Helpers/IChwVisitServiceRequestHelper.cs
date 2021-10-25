using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ChwVisitServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IChwVisitServiceRequestHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ChwVisitServiceRequestsResponse>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ChwVisitServiceRequestsResponse> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<ChwVisitServiceRequestsResponse>> GetByPatientAsync(Guid patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<ChwVisitServiceRequestsResponse>> GetByPratitionerAsync(Guid practitionerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<ChwVisitServiceRequestsResponse> CreateAsync(ChwVisitServiceRequestsInput input, Person practitioner);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task<ChwVisitServiceRequestsResponse> UpdateAsync(ChwVisitServiceRequestsInput input, Person practitioner);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
