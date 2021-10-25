using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.AmbulanceServiceRequests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.AmbulanceServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class AmbulanceServiceRequestAppService: CdmAppServiceBase, IAmbulanceServiceRequestAppService
    {
        private readonly IAmbulanceServiceRequestHelper _ambulanceServiceRequestHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ambulanceServiceRequestHelper"></param>
        public AmbulanceServiceRequestAppService(
            IAmbulanceServiceRequestHelper ambulanceServiceRequestHelper)
        {
            _ambulanceServiceRequestHelper = ambulanceServiceRequestHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<AmbulanceServiceRequestResponse>> GetAllAmbulanceServiceRequestsAsync()
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _ambulanceServiceRequestHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<AmbulanceServiceRequestResponse> GetAmbulanceServiceRequestAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "Ambulance Service Request Id cannot be empty");
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _ambulanceServiceRequestHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<AmbulanceServiceRequestResponse>> GetAmbulanceServiceRequestsByPatientAsync(Guid patientId)
        {
            Validation.ValidateIdWithException(patientId, "Patient Id cannot be empty");
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _ambulanceServiceRequestHelper.GetByPatientAsync(patientId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<AmbulanceServiceRequestResponse>> GetAmbulanceServiceRequestsByPratitionerAsync(Guid practitionerId)
        {
            Validation.ValidateIdWithException(practitionerId, "Practitioner Id cannot be empty");
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _ambulanceServiceRequestHelper.GetByPratitionerAsync(practitionerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<AmbulanceServiceRequestResponse> CreateAmbulanceServiceRequestAsync(AmbulanceServiceRequestInput input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _ambulanceServiceRequestHelper.CreateAsync(input, person); //create a ambulance service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<AmbulanceServiceRequestResponse> UpdateAmbulanceServiceRequestAsync(AmbulanceServiceRequestInput input)
        {
            Validation.ValidateIdWithException(input?.Id, "Ambulance Service Request Id cannot be empty");
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _ambulanceServiceRequestHelper.UpdateAsync(input, person); //create a ambulance service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteAmbulanceServiceRequestAsync(Guid id)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            await _ambulanceServiceRequestHelper.DeleteAsync(id);
        }
    }
}
