using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Boxfusion.Health.His.Admissions.Domain;
using Boxfusion.Health.His.Admissions.Domain.Enums;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Admissions
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/HisAdmis/[controller]")]
	public class AdmissionsAppService: SheshaAppServiceBase, IAdmissionsAppService
	{
		private readonly IEncounterCrudHelper<HospitalisationEncounter> _encounterCrudHelper;
		private readonly IRepository<AdmissionsPatient, Guid> _repository;
		private readonly IRepository<Ward, Guid> _wardRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encounterCrudHelper"></param>
		/// <param name="repository"></param>
		/// <param name="wardRepository"></param>
		public AdmissionsAppService(IEncounterCrudHelper<HospitalisationEncounter> encounterCrudHelper, 
			IRepository<AdmissionsPatient, Guid> repository,
			IRepository<Ward, Guid> wardRepository)
		{
			_encounterCrudHelper = encounterCrudHelper;
			_repository = repository;
			_wardRepository = wardRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("AdmitPatient")]
		public async Task<AdmitPatientResponse> AdmitPatient(AdmitPatientInput input)
		{
			if (string.IsNullOrEmpty(input.IdentityNumber)) throw new UserFriendlyException("Patient IdentittyNumber can not be null.");
			Validation.ValidateIdWithException(input.Ward?.Id, "Ward id cannot be null.");

			//Creates new AdmissionsPatient entity if doesn't already exist
			var patient = new AdmissionsPatient();
			patient = await _repository.FirstOrDefaultAsync(x => x.IdentityNumber == input.IdentityNumber);

			if (patient == null)
			{
				patient = await SaveOrUpdateEntityAsync<AdmissionsPatient>(null, async item =>
				{
					ObjectMapper.Map(input, item);
					item.AdmissionStatus = RefListAdmissionStatus.admitted;
				});
			}

			//Admit patient using HospitalisationEncounter
			var ward = await _wardRepository.GetAsync((Guid)input.Ward.Id);

			var admission = new HospitalisationEncounterInput();
			ObjectMapper.Map(input, admission);
			ObjectMapper.Map(ward, admission);
			admission.Class = new ReferenceListItemValueDto() { ItemValue = (long?)RefListRefListEncounterClasses.PRENC };

			await MapAdmissionConstantValues(admission, patient, input);
			var admissionEntity = await _encounterCrudHelper.CreateOrUpdateAsync(admission, ObjectMapper.Map<HospitalisationEncounter>(admission));

			//Maps back patient-admission to AdmitPatientResponse
			var result = new AdmitPatientResponse();

			ObjectMapper.Map(patient, result);
			ObjectMapper.Map(admissionEntity, result);

			return result;
		}

		private async Task MapAdmissionConstantValues(HospitalisationEncounterInput admission, AdmissionsPatient patient, AdmitPatientInput input)
		{
			//Gets logged-in system user admitting patient
			var currentUser = await GetCurrentPersonAsync();

			var diagnosis = new DiagnosisInput();
			diagnosis.Condition.Code = input.Code;
			diagnosis.Condition.Subject = new EntityWithDisplayNameDto<Guid?>(patient.Id, patient.FirstName);
			diagnosis.Condition.Recorder = new EntityWithDisplayNameDto<Guid?>(currentUser.Id, currentUser.FirstName);
			diagnosis.Condition.Asserter = new EntityWithDisplayNameDto<Guid?>(currentUser.Id, currentUser.FirstName);

			var diagnosisList = new List<DiagnosisInput>();
			diagnosisList.Add(diagnosis);

			admission.Diagnosis = diagnosisList;
		}
	}
}
