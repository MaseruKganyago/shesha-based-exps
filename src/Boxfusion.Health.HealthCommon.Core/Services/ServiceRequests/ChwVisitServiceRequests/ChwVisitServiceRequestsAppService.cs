using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ChwVisitServiceRequests.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ChwVisitServiceRequests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ChwVisitServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class ChwVisitServiceRequestsAppService : CdmAppServiceBase, IChwVisitServiceRequestsAppService
    {
        private readonly IChwVisitServiceRequestHelper _chwVisitServiceRequestHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chwVisitServiceRequestHelper"></param>
        public ChwVisitServiceRequestsAppService(
            IChwVisitServiceRequestHelper chwVisitServiceRequestHelper)
        {
            _chwVisitServiceRequestHelper = chwVisitServiceRequestHelper;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<ChwVisitServiceRequestsResponse>> GetAllChwVisitServiceRequestsAsync()
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _chwVisitServiceRequestHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<ChwVisitServiceRequestsResponse> GetChwVisitServiceRequestAsync(Guid id)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _chwVisitServiceRequestHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<ChwVisitServiceRequestsResponse>> GetChwVisitServiceRequestsByPatientAsync(Guid patientId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _chwVisitServiceRequestHelper.GetByPatientAsync(patientId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<ChwVisitServiceRequestsResponse>> GetChwVisitServiceRequestsByPratitionerAsync(Guid practitionerId)
        {
            return await _chwVisitServiceRequestHelper.GetByPratitionerAsync(practitionerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<ChwVisitServiceRequestsResponse> CreateChwVisitServiceRequestAsync(ChwVisitServiceRequestsInput input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _chwVisitServiceRequestHelper.CreateAsync(input, person); //create a ChwVisit service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<ChwVisitServiceRequestsResponse> UpdateChwVisitServiceRequestAsync(ChwVisitServiceRequestsInput input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var practitioner = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _chwVisitServiceRequestHelper.UpdateAsync(input, practitioner); //create a ChwVisit service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteChwVisitServiceRequestAsync(Guid id)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            await _chwVisitServiceRequestHelper.DeleteAsync(id);
        }
    }
}
