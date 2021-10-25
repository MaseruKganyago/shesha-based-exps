using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Microsoft.AspNetCore.Mvc;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.AllergyIntolerances
{
	/// <summary>
	/// 
	/// </summary>
	public interface IAllergyIntoleranceAppService: IApplicationService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<AllergyIntoleranceResponse>> GetAllAllergyIntolerances();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<AllergyIntoleranceResponse> GetAllergyIntoleranceById([FromRoute] Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<AllergyIntoleranceResponse>> GetAllergyIntoleranceByPatient([FromRoute] Guid patientId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		Task<List<AllergyIntoleranceResponse>> GetAllergyIntoleranceByPratitioner(Guid practitionerId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="term"></param>
		/// <returns></returns>
		Task<List<EntityWithDisplayNameDto<Guid>>> AllergyIntoleranceCodeAutoCompleteList(string term);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<AllergyIntoleranceResponse> CreateAllergyIntolerance(AllergyIntoleranceInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<AllergyIntoleranceResponse> UpdateAllergyIntolerance([FromRoute] Guid id, AllergyIntoleranceInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteCondition(Guid id);

	}
}
