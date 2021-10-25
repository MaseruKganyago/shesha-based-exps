using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using Aspose.Words;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Extentions;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Reports;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helper;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha.Authorization.Users;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class ReferralServiceRequestsAppService : CdmAppServiceBase, IReferralServiceRequestsAppService
    {
        private readonly IReferralServiceRequestHelper _referralServiceRequestHelper;
        private readonly ICdmPermissionChecker _cdmPermissionChecker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referralServiceRequestHelper"></param>
        /// <param name="cdmPermissionChecker"></param>
        public ReferralServiceRequestsAppService(
            IReferralServiceRequestHelper referralServiceRequestHelper,
            ICdmPermissionChecker cdmPermissionChecker)
        {
            _referralServiceRequestHelper = referralServiceRequestHelper;
            _cdmPermissionChecker = cdmPermissionChecker;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<ReferralServiceRequestResponse>> GetAllReferralServiceRequestsAsync()
        {
           await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referralServiceRequestHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<ReferralServiceRequestResponse> GetReferralServiceRequestAsync(Guid id)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referralServiceRequestHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<ReferralServiceRequestResponse>> GetReferralServiceRequestsByPatientAsync(Guid patientId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referralServiceRequestHelper.GetByPatientAsync(patientId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{practitionerId}")]
        public async Task<List<ReferralServiceRequestResponse>> GetReferralServiceRequestsByPratitionerAsync(Guid practitionerId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referralServiceRequestHelper.GetByPratitionerAsync(practitionerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<ReferralServiceRequestResponse> CreateReferralServiceRequestAsync(ReferralServiceRequestInput input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referralServiceRequestHelper.CreateAsync(input, person); //create a referral service request
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<ReferralServiceRequestResponse> UpdateReferralServiceRequestAsync(ReferralServiceRequestUpdate input)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");
            Validation.ValidateIdWithException(input?.FileId, "FileId cannot be empty");
            Validation.ValidateIdWithException(input?.DocumentId, "DocumentId cannot be empty");

            var person = await ValidatePermissionsOfCurrentLoggedInPerson();
            return await _referralServiceRequestHelper.UpdateAsync(input, person); //create a referral service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteReferralServiceRequestAsync(Guid id, Guid fileId)
        {
            await ValidatePermissionsOfCurrentLoggedInPerson();
            await _referralServiceRequestHelper.DeleteAsync(id, fileId);
        } 
    }
}
