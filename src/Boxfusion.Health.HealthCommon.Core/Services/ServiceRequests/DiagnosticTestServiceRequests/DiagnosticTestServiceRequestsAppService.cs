using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Aspose.Words;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Reports;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.DiagnosticTestServiceRequests.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha;
using Shesha.Domain;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.DiagnosticTestServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class DiagnosticTestServiceRequestsAppService : CdmAppServiceBase, IDiagnosticTestServiceRequestsAppService
    {
        private readonly IDiagnosticTestServiceRequestHelper _diagnosticTestServiceRequestHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagnosticTestServiceRequestHelper"></param>
        /// <param name="encounterRepository"></param>
        public DiagnosticTestServiceRequestsAppService(
            IDiagnosticTestServiceRequestHelper diagnosticTestServiceRequestHelper
            )
        {
            _diagnosticTestServiceRequestHelper = diagnosticTestServiceRequestHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<DiagnosticTestServiceRequestResponse>> GetAllDiagnosticTestServiceRequestsAsync()
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _diagnosticTestServiceRequestHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<DiagnosticTestServiceRequestResponse> GetDiagnosticTestServiceRequestAsync(Guid id)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _diagnosticTestServiceRequestHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<DiagnosticTestServiceRequestResponse>> GetDiagnosticTestServiceRequestsByPatientAsync(Guid patientId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _diagnosticTestServiceRequestHelper.GetByPatientAsync(patientId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{practitionerId}")]
        public async Task<List<DiagnosticTestServiceRequestResponse>> GetDiagnosticTestServiceRequestsByPratitionerAsync(Guid practitionerId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _diagnosticTestServiceRequestHelper.GetByPratitionerAsync(practitionerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<DiagnosticTestServiceRequestResponse> CreateDiagnosticTestServiceRequestAsync(DiagnosticTestServiceRequestInput input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();

            return await _diagnosticTestServiceRequestHelper.CreateAsync(input, person); //create a diagnostic test service request
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<DiagnosticTestServiceRequestResponse> UpdateDiagnosticTestServiceRequestAsync(DiagnosticTestServiceRequestUpdate input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");
            Validation.ValidateIdWithException(input?.FileId, "FileId cannot be empty");

            if (input.FileId == null || input.FileId is Guid guid && guid == Guid.Empty)
                throw new UserFriendlyException((int)HttpStatusCode.BadRequest, "FileId cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return  await _diagnosticTestServiceRequestHelper.UpdateAsync(input, person); //create a diagnostic test service request    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteDiagnosticTestServiceRequestAsync(Guid id, Guid fileId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            await _diagnosticTestServiceRequestHelper.DeleteAsync(id, fileId);
        }
    }
}
