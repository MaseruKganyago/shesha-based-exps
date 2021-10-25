using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.ServiceAgents;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class EncountersAppService : CdmAppServiceBase, IEncountersAppService
    {
        private readonly IEncounterCrudHelper<Encounter> _encounterCrudHelper;
        private readonly IRepository<EncounterLocation, Guid> _encounterLocationRepository;
        private readonly ICdmSettings _cdmSettings;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterCrudHelper"></param>
        /// <param name="encounterLocationRepository"></param>
        /// <param name="cdmSettings"></param>
        public EncountersAppService(
            IEncounterCrudHelper<Encounter> encounterCrudHelper,
            IRepository<EncounterLocation, Guid> encounterLocationRepository,
            ICdmSettings cdmSettings)
        {
            _encounterCrudHelper = encounterCrudHelper;
            _encounterLocationRepository = encounterLocationRepository;
            _cdmSettings = cdmSettings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<FhirEncounterResponse>> GetAllEncountersAsync(Guid patientId)
        {
            //var person = await GetCurrentPersonAsync();
            var encouters = await _encounterCrudHelper.GetByPatientAsync(patientId);
            var fhirEncounterResponses = ObjectMapper.Map<List<FhirEncounterResponse>>(encouters);
            var encounterLocation = await _encounterLocationRepository.FirstOrDefaultAsync(x => x.Location.Id == Guid.Parse(_cdmSettings.FacilityIdentifier));


            var list = new List<EncounterLocationResponse>();
            list.Add(ObjectMapper.Map<EncounterLocationResponse>(encounterLocation));
            if (fhirEncounterResponses.Any())
                fhirEncounterResponses.ForEach(x => x.Locations = list);

            var temp = ObjectMapper.Map<EncounterLocationResponse>(encounterLocation);
            await ServiceBusHelper.SendAsync("LocationRetrieved", temp, encounterLocation.Id);
            return fhirEncounterResponses;
        }

       
    }
}
