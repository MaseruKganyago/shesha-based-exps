using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Aspose.Pdf;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferToPractitionerServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReferToPractitionerServiceRequestsAppService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ReferToPractitionerServiceRequestResponse>> GetReferToPractitionerServiceRequestsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReferToPractitionerServiceRequestResponse> GetReferToPractitionerServiceRequestAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<ReferToPractitionerServiceRequestResponse>> GetReferToPractitionerServiceRequestByPatientAsync(Guid patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        Task<List<ReferToPractitionerServiceRequestResponse>> GetReferToPractitionerServiceRequestByPractitionerAsync(Guid practitionerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ReferToPractitionerServiceRequestResponse> CreateReferToPractitionerServiceRequestAsync(ReferToPractitionerServiceRequestInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ReferToPractitionerServiceRequestResponse> UpdateReferToPractitionerServiceRequestAsync(ReferToPractitionerServiceRequestInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task DeleteReferToPractitionerServiceRequestAsync(Guid id);
    }
   
}

