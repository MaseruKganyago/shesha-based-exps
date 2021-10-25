using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Conditions
{
	/// <summary>
	/// 
	/// </summary>
	public interface IConditionAppService: IApplicationService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<ConditionResponse>> GetAllConditions();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ConditionResponse> GetCondtion([FromRoute] Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<ConditionResponse>> GetConditionsByPatient([FromRoute] Guid patientId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		Task<List<ConditionResponse>> GetConditionsByPratitioner(Guid practitionerId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<ConditionResponse> CreateCondition(ConditionInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<ConditionResponse> UpdateCondition([FromRoute] Guid id, ConditionInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteCondition(Guid id);
	}
}
