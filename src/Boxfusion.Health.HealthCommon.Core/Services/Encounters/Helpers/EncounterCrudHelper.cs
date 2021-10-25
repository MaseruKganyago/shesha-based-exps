using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Extensions;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	[ApiExplorerSettings(IgnoreApi = true)]
	public class EncounterCrudHelper<T> : SheshaAppServiceBase, ITransientDependency, IEncounterCrudHelper<T> where T : Encounter
	{
		private readonly IRepository<T, Guid> _repository;
		private readonly IRepository<Diagnosis, Guid> _diagnosisRespository;
		private readonly IRepository<EncounterLocation, Guid> _encounterLocationRepository;
		private readonly IRepository<FhirLocation, Guid> _locationRepository;
		private readonly IRepository<Participant, Guid> _participantRespository;
		private readonly ICdmSettings _cdmSettings;

		/// <summary>
		/// 
		/// </summary>
		public EncounterCrudHelper(IRepository<T, Guid> repository,
			IRepository<Diagnosis, Guid> diagnosisRespository,
			IRepository<EncounterLocation, Guid> encounterLocationRepository,
			IRepository<FhirLocation, Guid> locationRepository,
			IRepository<Participant, Guid> participantRespository,
			ICdmSettings cdmSettings)
		{
			_repository = repository;
			_diagnosisRespository = diagnosisRespository;
			_encounterLocationRepository = encounterLocationRepository;
			_participantRespository = participantRespository;
			_cdmSettings = cdmSettings;
			_locationRepository = locationRepository;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<List<T>> GetAllAsync()
		{
			return await _repository.GetAllListAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<T> GetByIdAsync(Guid id)
		{
			Validation.ValidateIdWithException(id, "Id cannot be empty");

			return await _repository.GetAsync(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		public async Task<List<T>> GetByPatientAsync(Guid patientId)
		{
			return await _repository.GetAllListAsync(x => x.Subject.Id == patientId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		public async Task<List<T>> GetByPratitionerAsync(Guid practitionerId)
		{
			return await _repository.GetAllListAsync(x => x.Performer.Id == practitionerId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <param name="entity"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public async Task<T> CreateOrUpdateAsync(FhirEncounterInput input, T entity, Func<Task> action = null)
		{
			var result = Validation.ValidateId(input.Id) == null ? await _repository.InsertAsync(entity) : await _repository.UpdateAsync(entity);

			#region Handles all BackboneElements related to encounter and other specified additional logic from Encounter or Encounter Sub-Classes Services as action
			//Participants BackboneElements list
			var participantsTasks = new List<Task<ParticipantResponse>>();
			if (input.Id == null)
			{
				var practitionerParticipant = new ParticipantInput() //create a new participant from perform(Practitioner)
				{
					Type = new ReferenceListItemValueDto() { ItemValue = (long?)RefListEncounterParticipantTypes.primaryPerformer },
					Individual = new EntityWithDisplayNameDto<Guid?>() { Id = input.Performer?.Id },
					Required = new ReferenceListItemValueDto() { ItemValue = (long?)RefListParticipantRequired.required },
					Status = new ReferenceListItemValueDto() { ItemValue = (long?)RefListParticipationStatus.accepted }
				};

				participantsTasks.Add(SaveOrUpdateParticipants(practitionerParticipant, result));
			}

			if (input?.Participants?.Count > 0)
			{
				input.Participants.ForEach(partiticipant => participantsTasks.Add(SaveOrUpdateParticipants(partiticipant, result)));
			}

			//Diagnosis BackboneElements list
			var diagnosisTasks = new List<Task<DiagnosisResponse>>();
			if (input?.Diagnosis?.Count > 0)
			{
				input.Diagnosis.ForEach(diagnosis => diagnosisTasks.Add(SaveOrUpdateDiagnosis(diagnosis, result)));
			}

			//EncounterLocation BackboneElement
			var fhirLocation = await _locationRepository.GetAsync(Guid.Parse(_cdmSettings.FacilityIdentifier));
			var encounterLocationTasks = new List<Task<EncounterLocationResponse>>();

			if (input.Id == null)
			{
				var encounterLocationInput = new EncounterLocationInput() //create a new participant from perform(Practitioner)
				{
					Status = new ReferenceListItemValueDto() { ItemValue = (long?)RefListEncounterLocationStatuses.active },
				    PhysicalType = new ReferenceListItemValueDto() { ItemValue = (long?)RefListLocationPhysicalTypes.vrt },
				    StartDateTime = DateTime.Now,
				    Location = new EntityWithDisplayNameDto<Guid?>(fhirLocation.Id, fhirLocation.Name),
				};

				encounterLocationTasks.Add(SaveOrUpdateLocationEncounter(encounterLocationInput, result, fhirLocation));
			}

			if((input?.Locations?.Count > 0))
            {
					input.Locations.ForEach(location => encounterLocationTasks.Add(SaveOrUpdateLocationEncounter(location, result, fhirLocation)));
			}

			if (input?.Participants?.Count > 0) await Task.WhenAll(participantsTasks);
			if (input?.Diagnosis?.Count > 0) await Task.WhenAll(diagnosisTasks);
			if (input?.Locations?.Count > 0) await Task.WhenAll(encounterLocationTasks);

			//Additional logic
			if (action != null) await action.Invoke();
			#endregion

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Guid id)
		{
			Validation.ValidateIdWithException(id, $"{typeof(T).Name} Id cannot be empty");

			var entity = await _repository.GetAsync(id);
			if (entity == null) throw new UserFriendlyException($"{typeof(T).Name} with specified id does not exist.");

			await _repository.DeleteAsync(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="result"></param>
		/// <returns></returns>
		public async Task MapEncounterBackboneElements<TResult>(TResult result) where TResult : FhirEncounterResponse
		{
			result.Diagnosis = ObjectMapper.Map<List<DiagnosisResponse>>(await _diagnosisRespository.GetAllListAsync(a => a.OwnerId == result.Id.ToString()));
			result.Locations = ObjectMapper.Map<List<EncounterLocationResponse>>(await _encounterLocationRepository.GetAllListAsync(a => a.OwnerId == result.Id.ToString()));
			result.Participants = ObjectMapper.Map<List<ParticipantResponse>>(await _participantRespository.GetAllListAsync(a => a.OwnerId == result.Id.ToString()));
		}

		private async Task<EncounterLocationResponse> SaveOrUpdateLocationEncounter<T>(EncounterLocationInput input, T ownerEntity, FhirLocation location = null) where T : Encounter
		{
			var entity = await SaveOrUpdateEntityAsync<EncounterLocation>((Guid?)Validation.ValidateId(input.Id), async item =>
			{
				ObjectMapper.Map(input, item);
				if (location != null) item.Location = location;
				item.OwnerId = ownerEntity.Id.ToString();
				item.OwnerType = ownerEntity.GetTypeShortAlias();
			});

			return ObjectMapper.Map<EncounterLocationResponse>(entity);
		}

		private async Task<DiagnosisResponse> SaveOrUpdateDiagnosis<T>(DiagnosisInput diagnosis, T ownerEntity) where T : Encounter
		{
			var entity = await SaveOrUpdateEntityAsync<Diagnosis>((Guid?)Validation.ValidateId(diagnosis.Id), async item =>
			{
				ObjectMapper.Map(diagnosis, item);
				item.OwnerId = ownerEntity.Id.ToString();
				item.OwnerType = ownerEntity.GetTypeShortAlias();
			});

			return ObjectMapper.Map<DiagnosisResponse>(entity);
		}

		private async Task<ParticipantResponse> SaveOrUpdateParticipants<T>(ParticipantInput partiticipant, T ownerEntity) where T : Encounter
		{
			var entity = await SaveOrUpdateEntityAsync<Participant>((Guid?)Validation.ValidateId(partiticipant.Id), async item =>
			{
				ObjectMapper.Map(partiticipant, item);
				item.OwnerId = ownerEntity.Id.ToString();
				item.OwnerType = ownerEntity.GetTypeShortAlias();
			});

			return ObjectMapper.Map<ParticipantResponse>(entity);
		}
	}
}