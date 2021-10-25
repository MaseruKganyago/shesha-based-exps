using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.AllergyIntolerances.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public interface IAllergyIntoleranceCrudHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<AllergyIntoleranceResponse>> GetAllAsync();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<AllergyIntoleranceResponse> GetByIdAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<AllergyIntoleranceResponse>> GetByPatientIdAsync(Guid patientId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		Task<List<AllergyIntoleranceResponse>> GetByPratitionerIdAsync(Guid practitionerId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<AllergyIntoleranceResponse> CreateAsync(AllergyIntoleranceInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<AllergyIntoleranceResponse> UpdateAsync(AllergyIntoleranceInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);
	}
}
