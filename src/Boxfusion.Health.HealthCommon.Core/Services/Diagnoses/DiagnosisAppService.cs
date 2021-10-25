using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Diagnoses
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	public class DiagnosisAppService: CdmAppServiceBase, IDiagnosisAppService
	{
		private readonly IRepository<Diagnosis, Guid> _repository;
		private readonly IConditionsCrudHelper _conditionsAppServiceBase;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="conditionsAppServiceBase"></param>
		public DiagnosisAppService(IRepository<Diagnosis, Guid> repository, IConditionsCrudHelper conditionsAppServiceBase)
		{
			_repository = repository;
			_conditionsAppServiceBase = conditionsAppServiceBase;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
		public async Task<List<DiagnosisResponse>> GetAllDiagnosis()
		{
			return ObjectMapper.Map<List<DiagnosisResponse>>(await _repository.GetAllListAsync());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, Route("{id}")]
		public async Task<DiagnosisResponse> GetDiagnosisById(Guid id)
		{
			if (id == null || id == Guid.Empty) throw new UserFriendlyException("id can not be null.");

			var entity = await _repository.GetAsync(id);
			if (entity == null) throw new UserFriendlyException($"Diagnosis with specified id:`{id}` does not exist.");

			return ObjectMapper.Map<DiagnosisResponse>(entity);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("")]
		public async Task<DiagnosisResponse> CreateDiagnosis(DiagnosisInput input)
		{
			//Creates new Condition for Diagnosis if the was no existing condition to relate to the diagnosis
			var condition = new ConditionResponse();
			if (Validation.ValidateId(input.Condition.Id) == null)
			{
				condition = await _conditionsAppServiceBase.CreateAsync(input.Condition);
				input.Condition.Id = condition.Id;
				input.Condition.Code = condition.Code;
			}

			var entity = await SaveOrUpdateEntityAsync<Diagnosis>(null, async item =>
			{
				ObjectMapper.Map(input, item);
			});

			var result = ObjectMapper.Map<DiagnosisResponse>(entity);
			result.Condition = Validation.ValidateId(condition.Id) == null ? await _conditionsAppServiceBase.GetByIdAsync(input.Condition.Id) : condition;

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}")]
		public async Task<DiagnosisResponse> UpdateDiagnosis([FromRoute]Guid id, DiagnosisInput input)
		{
			if (Validation.ValidateId(id) == null) throw new UserFriendlyException("id can not be null.");

			var entity = await SaveOrUpdateEntityAsync<Diagnosis>(id, async item =>
			{
				ObjectMapper.Map(input, item);
			});

			var result = ObjectMapper.Map<DiagnosisResponse>(entity);
			result.Condition = await _conditionsAppServiceBase.GetByIdAsync(input.Condition.Id);

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete, Route("{id}")]
		public async Task DeleteDiagnosis([FromRoute]Guid id)
		{
			if (id == null || id == Guid.Empty) throw new UserFriendlyException("id can not be null.");

			var entity = await _repository.GetAsync(id);
			if (entity == null) throw new UserFriendlyException($"Diagnosis with specified id:`{id}` does not exist.");

			await _repository.DeleteAsync(id);
		}
	}
}
