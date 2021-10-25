using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferToPractitionerServiceRequests.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferToPractitionerServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class ReferToPractitionerServiceRequestsAppService: CdmAppServiceBase, IReferToPractitionerServiceRequestsAppService
    {
       /// <summary>
       /// 
       /// </summary>
        private readonly IReferToPractitionerHelper _referToPractitionerAppServiceBase;
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="referToPractitionerAppServiceBase"></param>
        public ReferToPractitionerServiceRequestsAppService(
            IReferToPractitionerHelper referToPractitionerAppServiceBase      
            )
        {
            _referToPractitionerAppServiceBase = referToPractitionerAppServiceBase;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<ReferToPractitionerServiceRequestResponse>> GetReferToPractitionerServiceRequestsAsync()
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referToPractitionerAppServiceBase.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<ReferToPractitionerServiceRequestResponse> GetReferToPractitionerServiceRequestAsync(Guid id)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referToPractitionerAppServiceBase.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<ReferToPractitionerServiceRequestResponse>> GetReferToPractitionerServiceRequestByPatientAsync(Guid patientId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referToPractitionerAppServiceBase.GetByPatientAsync(patientId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{practitionerId}")]
        public async Task<List<ReferToPractitionerServiceRequestResponse>> GetReferToPractitionerServiceRequestByPractitionerAsync(Guid practitionerId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referToPractitionerAppServiceBase.GetByPratitionerAsync(practitionerId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<ReferToPractitionerServiceRequestResponse> CreateReferToPractitionerServiceRequestAsync(ReferToPractitionerServiceRequestInput input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referToPractitionerAppServiceBase.CreateAsync(input, person); //create a referral service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<ReferToPractitionerServiceRequestResponse> UpdateReferToPractitionerServiceRequestAsync(ReferToPractitionerServiceRequestInput input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referToPractitionerAppServiceBase.UpdateAsync(input, person); //create a referral service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteReferToPractitionerServiceRequestAsync(Guid id)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            await _referToPractitionerAppServiceBase.DeleteAsync(id);
        }    
    }
}

