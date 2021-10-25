using Boxfusion.Health.HealthCommon.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationStatements.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public interface IMedicationStatementsCrudHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<MedicationStatementResponse>> GetAllAsync();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<MedicationStatementResponse> GetByIdAsync(Guid id);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<MedicationStatementResponse>> GetByPatientIdAsync(Guid patientId);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		Task<List<MedicationStatementResponse>> GetByPractitionerIdAsync(Guid practitionerId);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<MedicationStatementResponse> CreateOrUpdateAsync(MedicationStatementInput input);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);
	}
}
