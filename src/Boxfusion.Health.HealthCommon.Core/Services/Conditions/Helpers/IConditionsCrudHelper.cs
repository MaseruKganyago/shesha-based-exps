using Abp.Dependency;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public interface IConditionsCrudHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<ConditionResponse>> GetAllAsync();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ConditionResponse> GetByIdAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<ConditionResponse>> GetByPatientIdAsync(Guid patientId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		Task<List<ConditionResponse>> GetByPratitionerIdAsync(Guid practitionerId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<ConditionResponse> CreateAsync(ConditionInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<ConditionResponse> UpdateAsync(ConditionInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);
	}
}
