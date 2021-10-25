using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Enums;
using Microsoft.AspNetCore.Mvc;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	public class ConsultationEncounterAppService : CdmAppServiceBase, IConsultationEncounterAppService
	{
		private readonly IEncounterCrudHelper<ConsultationEncounter> _encounterCrudHelper;

		private readonly IRepository<ConsultationEncounter, Guid> _repository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encounterCrudHelper"></param>
		/// <param name="repository"></param>
		public ConsultationEncounterAppService(IEncounterCrudHelper<ConsultationEncounter> encounterCrudHelper,
			IRepository<ConsultationEncounter, Guid> repository)
		{
			_encounterCrudHelper = encounterCrudHelper;
			_repository = repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
		public async Task<List<ConsultationEncounterResponse>> GetAllConsultationEncounters()
		{
			return await ConsultationEncounterUtilityHelper.GetAllConsultationEncountersWithBackboneElements(RefListFilterIdType.none, Guid.Empty);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, Route("{id}")]
		public async Task<ConsultationEncounterResponse> GetConsultationEncounterById(Guid id)
		{
			var entityResult = ObjectMapper.Map<ConsultationEncounterResponse>(await _encounterCrudHelper.GetByIdAsync(id));

			//Gets all BackboneElements related to ConsultationEncounter
			await _encounterCrudHelper.MapEncounterBackboneElements<ConsultationEncounterResponse>(entityResult);

			return entityResult;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		[HttpGet, Route("[action]/{patientId}")]
		public async Task<List<ConsultationEncounterResponse>> GetConsultationEncounterssByPatient(Guid patientId)
		{
			Validation.ValidateIdWithException(patientId, "patientId can not be null.");

			return await ConsultationEncounterUtilityHelper.GetAllConsultationEncountersWithBackboneElements(RefListFilterIdType.patientId, patientId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		[HttpGet, Route("[action]/{practitionerId}")]
		public async Task<List<ConsultationEncounterResponse>> GetConsultationEncountersByPractitioner(Guid practitionerId)
		{
			Validation.ValidateIdWithException(practitionerId, "practitionerId can not be null.");

			return await ConsultationEncounterUtilityHelper.GetAllConsultationEncountersWithBackboneElements(RefListFilterIdType.practitionerId, practitionerId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("")]
		public async Task<ConsultationEncounterResponse> CreateConsultationEncounter(ConsultationEncounterInput input)
		{
			var entityResult = ObjectMapper.Map<ConsultationEncounterResponse>(await _encounterCrudHelper.CreateOrUpdateAsync(input, ObjectMapper.Map<ConsultationEncounter>(input)));

			//Gets all BackboneElements related to ConsultationEncounter
			if (entityResult != null) await _encounterCrudHelper.MapEncounterBackboneElements<ConsultationEncounterResponse>(entityResult);

			return entityResult;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}")]
		public async Task<ConsultationEncounterResponse> UpdateConsultationEncounter(ConsultationEncounterInput input)
		{
			Validation.ValidateIdWithException((Guid)(input?.Id), "Id can not be null");
			var updatedEntityResult = ObjectMapper.Map<ConsultationEncounterResponse>(await _encounterCrudHelper.CreateOrUpdateAsync(input, ObjectMapper.Map<ConsultationEncounter>(input)));

			//Gets all BackboneElements related to ConsultationEncounter
			if (updatedEntityResult != null) await _encounterCrudHelper.MapEncounterBackboneElements<ConsultationEncounterResponse>(updatedEntityResult);

			return updatedEntityResult;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encounterId"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("[action]/{encounterId}")]
		public async Task<ConsultationEncounterResponse> ScheduleFollowUp([FromRoute] Guid encounterId, FollowUpInput input)
		{
			Validation.ValidateIdWithException(encounterId, "encounterId can not be null.");

			var entity = await _encounterCrudHelper.GetByIdAsync(encounterId);
			ObjectMapper.Map(input, entity);

			switch ((RefListFollowUpDay)input.FollowUpDay.ItemValue)
			{
				case RefListFollowUpDay.oneDay:
					var date = DateTime.Now.AddDays(1);
					entity.FollowUpDate = date;
					break;

				case RefListFollowUpDay.threeDays:
					var date3 = DateTime.Now.AddDays(3);
					entity.FollowUpDate = date3;
					break;

				case RefListFollowUpDay.sevenDays:
					var date7 = DateTime.Now.AddDays(7);
					entity.FollowUpDate = date7;
					break;

				default:
					break;
			}

			var updatedEntity = ObjectMapper.Map<ConsultationEncounterResponse>(await _repository.UpdateAsync(entity));

			//Gets all BackboneElements related to ConsultationEncounter
			if (updatedEntity != null) await _encounterCrudHelper.MapEncounterBackboneElements<ConsultationEncounterResponse>(updatedEntity);

			return updatedEntity;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="encounterId"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("[action]/{encounterId}")]
		public async Task<ConsultationEncounterResponse> FollowUpFeedback([FromRoute] Guid encounterId, FollowUpFeedbackInput input)
		{
			Validation.ValidateIdWithException(encounterId, "encounterId can not be null.");

			var entity = await _encounterCrudHelper.GetByIdAsync(encounterId);
			ObjectMapper.Map(input, entity);

			var updatedEntity = ObjectMapper.Map<ConsultationEncounterResponse>(await _repository.UpdateAsync(entity));

			//Gets all BackboneElements related to ConsultationEncounter
			if (updatedEntity != null) await _encounterCrudHelper.MapEncounterBackboneElements<ConsultationEncounterResponse>(updatedEntity);

			return updatedEntity;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete, Route("")]
		public async Task DeleteConsultationEncounter(Guid id)
		{
			await _encounterCrudHelper.DeleteAsync(id);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("[action]{id}")]
		public async Task<ConsultationEncounterResponse> ConsultationFeedback(FeedBackInput input)
		{
			Validation.ValidateIdWithException((Guid)(input?.Encounter?.Id), "Id cannot be empty");

			var dbConsultationEncounter = await _encounterCrudHelper.GetByIdAsync(input.Encounter.Id.Value);
			ObjectMapper.Map(input, dbConsultationEncounter);
			var entityInput = ObjectMapper.Map<ConsultationEncounterInput>(dbConsultationEncounter);
			var updatedEntityResult = ObjectMapper.Map<ConsultationEncounterResponse>(await _encounterCrudHelper.CreateOrUpdateAsync(entityInput, dbConsultationEncounter));

            return updatedEntityResult;
		}
	}
}
