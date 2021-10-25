using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Aspose.Words;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile;
using Boxfusion.Health.HealthCommon.Core.Helpers.ServiceAgents;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Reports;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Helper;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Services;
using Shesha.StoredFiles.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using shesha = Boxfusion.Health.HealthCommon.Core.Domain.Cdm;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class MedicationRequestsAppService : CdmAppServiceBase, IMedicationRequestsAppService
    {
        private readonly IMedicationRequestCrudHelper _medicationRequestCrudHelper;
        private readonly IDocumentProcessorHelper _documentProcessorHelper;
        private readonly ICdmSettings _cdmSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<StoredFile, Guid> _fileRepository;
        private readonly IRepository<Encounter, Guid> _encounterRepository;
        private readonly IStoredFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ISaveFileDocument _saveFileDocument;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicationRequestCrudHelper"></param>
        /// <param name="documentProcessorHelper"></param>
        /// <param name="cdmSettings"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="fileRepository"></param>
        /// <param name="encounterRepository"></param>
        /// <param name="fileService"></param>
        /// <param name="mapper"></param>
        /// <param name="saveFileDocument"></param>
        public MedicationRequestsAppService(
            IMedicationRequestCrudHelper medicationRequestCrudHelper, 
            IDocumentProcessorHelper documentProcessorHelper, 
            ICdmSettings cdmSettings, 
            IHttpContextAccessor httpContextAccessor, 
            IRepository<StoredFile, Guid> fileRepository,
            IRepository<Encounter, Guid> encounterRepository,
            IStoredFileService fileService,
            IMapper mapper,
            ISaveFileDocument saveFileDocument)
        {
            _medicationRequestCrudHelper = medicationRequestCrudHelper;
            _documentProcessorHelper = documentProcessorHelper;
            _cdmSettings = cdmSettings;
            _httpContextAccessor = httpContextAccessor;
            _fileRepository = fileRepository;
            _fileService = fileService;
            _mapper = mapper;
            _saveFileDocument = saveFileDocument;
            _encounterRepository = encounterRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[action]")]
        public Task<List<AutocompleteItemDto>> GetMedicationProducts(int pageIndex = 1, int pageSize = 100, string value = "")
        {
            var medicationProductList = _medicationRequestCrudHelper.GetMedpraxMedicationProductList(pageIndex, pageSize, value);
            return medicationProductList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<CdmMedicationRequestResponse>> GetMedicationRequests()
        {
            return await _medicationRequestCrudHelper.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<CdmMedicationRequestResponse> GetMedicationRequest(Guid id)
        {
            return await _medicationRequestCrudHelper.GetId(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]")]
        public async Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPatient(Guid patientId, Guid parentId)
        {
            return await _medicationRequestCrudHelper.GetMedicationRequestsByPatientId(patientId, parentId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]")]
        public async Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPractitioner(Guid practitionerId, Guid parentId)
        {
            return await _medicationRequestCrudHelper.GetMedicationRequestsByPractitionerId(practitionerId, parentId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<List<CdmMedicationRequestResponse>> CreateMedicationRequest(List<CdmMedicationRequestInput> input)
        {
            if ((!input.Any()))
                throw new UserFriendlyException("Medication request list cannot be empty");

            if ((input.Any(x => x?.Subject?.Id == null)))
                throw new UserFriendlyException("Subject Id cannot be empty");

            if ((input.Any(x => x?.Encounter?.Id == null)))
                throw new UserFriendlyException("Encounter Id cannot be empty");

            if (input.Any(x => string.IsNullOrWhiteSpace(x.MedicationCode)))
                throw new UserFriendlyException("Medication code cannot be empty");

            if (input.Any(x => string.IsNullOrWhiteSpace(x.MedicationName)))
                throw new UserFriendlyException("Medication name cannot be empty");

            var practitioner = await ValidatePermissionsOfCurrentLoggedInPerson();
            var output = await _medicationRequestCrudHelper.Create(input, practitioner); //create a referral service request as well as the document

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<CdmMedicationRequestResponse> UpdateMedicationRequest(CdmMedicationRequestUpdate input)
        {
            Validation.ValidateIdWithException(input?.Id, "Id cannot be empty");
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");
            Validation.ValidateIdWithException(input?.FileId, "FileId Id cannot be empty");

            var practitioner = await ValidatePermissionsOfCurrentLoggedInPerson(); //await GetCurrentPractitionerAsync();
            return await _medicationRequestCrudHelper.Update(input); //create a referral service request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async  Task DeleteMedicationRequest(Guid id)
        {
            await _medicationRequestCrudHelper.Delete(id);
        }
    }
}
