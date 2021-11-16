using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Boxfusion.Health.His.Admissions.Domain;
using Boxfusion.Health.His.Admissions.Domain.Views;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Extensions;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
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
		private readonly IEncounterCrudHelper<WardAdmission> _encounterCrudHelper;
		private readonly IRepository<HisPatient, Guid> _repository;
		private readonly IRepository<Ward, Guid> _wardRepository;
		private readonly IConditionsCrudHelper _conditionsCrudHelper;
		private readonly IRepository<Diagnosis, Guid> _diagnosisRepository;
		private readonly IRepository<ConditionIcdTenCode, Guid> _conditionIcdTenCodeRepository;
		private readonly IRepository<Hospital, Guid> _hosiptalRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encounterCrudHelper"></param>
		/// <param name="repository"></param>
		/// <param name="wardRepository"></param>
		/// <param name="conditionsCrudHelper"></param>
		/// <param name="diagnosisRepository"></param>
		/// <param name="conditionIcdTenCodeRepository"></param>
		/// <param name="hosiptalRepository"></param>
		public AdmissionsAppService(IEncounterCrudHelper<WardAdmission> encounterCrudHelper, 
			IRepository<HisPatient, Guid> repository,
			IRepository<Ward, Guid> wardRepository,
			IConditionsCrudHelper conditionsCrudHelper,
			IRepository<Diagnosis, Guid> diagnosisRepository,
			IRepository<ConditionIcdTenCode, Guid> conditionIcdTenCodeRepository,
			IRepository<Hospital, Guid> hosiptalRepository)
		{
			_encounterCrudHelper = encounterCrudHelper;
			_repository = repository;
			_wardRepository = wardRepository;
			_conditionsCrudHelper = conditionsCrudHelper;
			_diagnosisRepository = diagnosisRepository;
			_conditionIcdTenCodeRepository = conditionIcdTenCodeRepository;
			_hosiptalRepository = hosiptalRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static DataTableConfig IndexTable()
		{
			var table = new DataTableConfig<AdmittedPatientItems, Guid>("AdmittedPatients_Index");

			table.AddProperty(a => a.IdentificationType, b => b.Caption("ID Type"));
			table.AddProperty(a => a.IdentityNumber, b => b.Caption("I.D No."));
			table.AddProperty(a => a.DateOfBirth, b => b.Caption("D.O.B").SortDescending().IsFilterable(true).Sortable(true));
			table.AddProperty(a => a.Gender, b => b.Caption("Gender"));
			table.AddProperty(a => a.StartDateTime, b => b.Caption("Admission Date").SortDescending().IsFilterable(true).Sortable(true));
			table.AddProperty(a => a.HospitalisationPatientNumber, b => b.Caption("Hospital Patient Number"));
			table.AddProperty(a => a.PreAdmissionIdentifier, b => b.Caption("Admission Number"));
			table.AddProperty(a => a.FirstName, b => b.Caption("Patient Name"));
			table.AddProperty(a => a.LastName, b => b.Caption("Patient Surname"));
			table.AddProperty(a => a.AdmissionType, b => b.Caption("Admission Type"));
			table.AddProperty(a => a.Speciality, b => b.Caption("Specialty"));
			table.AddProperty(a => a.Province, b => b.Caption("Patient Province"));
			table.AddProperty(a => a.Classification, b => b.Caption("Classification"));
			table.AddProperty(a => a.Nationality, b => b.Caption("Nationality"));
			table.AddProperty(a => a.OtherCategories, b => b.Caption("Other Categories"));
			table.AddProperty(a => a.AdmissionStatus, b => b.Caption("Admission Status"));
			table.AddProperty(a => a.Days, b => b.Caption("Inpatient Days"));

			return table;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("AdmitPatient")]
		public async Task<AdmitPatientResponse> AdmitPatient(AdmitPatientInput input)
		{
			if (string.IsNullOrEmpty(input.Patient.IdentityNumber)) throw new UserFriendlyException("Patient IdentittyNumber can not be null.");

			var ward = input.WardAdmission.Locations.FirstOrDefault();
			Validation.ValidateIdWithException(ward.Location.Id, "Ward id cannot be null.");

			//Creates new AdmissionsPatient entity if doesn't already exist
			var patient = new HisPatient();
			patient = await _repository.FirstOrDefaultAsync(x => x.IdentityNumber == input.Patient.IdentityNumber);

			if (patient == null)
			{
				patient = await SaveOrUpdateEntityAsync<HisPatient>(null, async item =>
				{
					ObjectMapper.Map(input, item);
				});
			}

			#region Admit patient using HospitalisationEncounter
			var wardEntity = await _wardRepository.GetAsync((Guid)ward.Location.Id);
			ObjectMapper.Map(ward, input.WardAdmission);



			await MapAdmissionConstantValues(admission, patient, input);

			var admissionEntity = await SaveOrUpdateEntityAsync<WardAdmission>(null, async item =>
			{ObjectMapper.Map(input, item);
			});
			#endregion

			//Diagnosis BackboneElement
			var diagnosisResult = await SaveOrUpdateDiagnosis(admission.Diagnosis.FirstOrDefault(), admissionEntity);

			//Maps back patient-admission to AdmitPatientResponse
			var result = new AdmitPatientResponse();
			ObjectMapper.Map(patient, result);
			ObjectMapper.Map(admissionEntity, result);
			ObjectMapper.Map(ward, result);
			result.Code = diagnosisResult.Condition.Code;

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encounterId"></param>
		/// <returns></returns>
		[HttpGet, Route("AdmittedPatientDetails/{encounterId}")]
		public async Task<AdmitPatientResponse> GetAdmittedPatientDetails(Guid encounterId)
		{
			Validation.ValidateIdWithException(encounterId, "encounterId can not be null.");
			var admissionEntity = await _encounterCrudHelper.GetByIdAsync(encounterId);

			if (admissionEntity == null) throw new UserFriendlyException($"AdmittedPatientDetails with specified id: {encounterId} not found.");

			var hospital = new List<Hospital>();

			var patientEntity = await _repository.GetAsync(admissionEntity.Subject.Id);
			var diagnosis = await _diagnosisRepository.GetAllListAsync(a => a.OwnerId == encounterId.ToString());
			var wards = await _wardRepository.GetAllListAsync(a => a.Id.ToString() == admissionEntity.DestinationOwnerId);
			if (!string.IsNullOrEmpty(admissionEntity.OriginOwnerId)) hospital = await _hosiptalRepository.GetAllListAsync(a => a.Id.ToString() == admissionEntity.OriginOwnerId);

			var result = new AdmitPatientResponse();
			ObjectMapper.Map(patientEntity, result);
			ObjectMapper.Map(admissionEntity, result);
			ObjectMapper.Map(wards.FirstOrDefault(), result);
			ObjectMapper.Map(hospital.FirstOrDefault(), result);
			result.Code = await GetIcdCodes(diagnosis.FirstOrDefault());

			return result;
		}

		private async Task<List<EntityWithDisplayNameDto<Guid?>>> GetIcdCodes(Diagnosis diagnosis)
		{
			var list = await _conditionIcdTenCodeRepository.GetAllListAsync();
			list.RemoveAll(a => a.Condition?.Id != diagnosis.Condition?.Id);

			return ObjectMapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(list);
		}

		private async Task MapAdmissionConstantValues(HospitalisationEncounterInput admission, HisPatient patient, AdmitPatientInput input)
		{
			//Gets logged-in system user admitting patient
			var currentUser = await GetCurrentPersonAsync();

			var diagnosis = new DiagnosisInput();
			var condition = new ConditionInput();
			condition.Code = input.Code;
			condition.Recorder = new EntityWithDisplayNameDto<Guid?>(currentUser.Id, currentUser.FirstName);
			condition.Subject = new EntityWithDisplayNameDto<Guid?>(patient.Id, patient.FirstName);
			condition.Asserter = new EntityWithDisplayNameDto<Guid?>(currentUser.Id, currentUser.FirstName);

			diagnosis.Condition = condition;

			var diagnosisList = new List<DiagnosisInput>();
			diagnosisList.Add(diagnosis);

			admission.Diagnosis = diagnosisList;
			admission.Subject = new EntityWithDisplayNameDto<Guid?>(patient.Id, patient.FirstName);
		}

		private async Task<DiagnosisResponse> SaveOrUpdateDiagnosis(DiagnosisInput diagnosis, HospitalisationEncounter ownerEntity)
		{
			//Creates new Condition for Diagnosis if the was no existing condition to relate to the diagnosis
			var condition = new ConditionResponse();
			if (Validation.ValidateId(diagnosis.Condition.Id) == null)
			{
				condition = await _conditionsCrudHelper.CreateAsync(diagnosis.Condition);
				diagnosis.Condition.Id = condition.Id;
				diagnosis.Condition.Code = condition.Code;
			}

			var entity = await SaveOrUpdateEntityAsync<Diagnosis>((Guid?)Validation.ValidateId(diagnosis.Id), async item =>
			{
				ObjectMapper.Map(diagnosis, item);
				item.OwnerId = ownerEntity.Id.ToString();
				item.OwnerType = ownerEntity.GetTypeShortAlias();
			});

			var result = ObjectMapper.Map<DiagnosisResponse>(entity);
			result.Condition = condition;
			return result;
		}
	}
}
