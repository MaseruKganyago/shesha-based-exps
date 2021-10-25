using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
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
	public interface IDiagnosisAppService: IApplicationService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<DiagnosisResponse>> GetAllDiagnosis();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<DiagnosisResponse> GetDiagnosisById(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<DiagnosisResponse> CreateDiagnosis(DiagnosisInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<DiagnosisResponse> UpdateDiagnosis([FromRoute] Guid id, DiagnosisInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteDiagnosis([FromRoute] Guid id);
	}
}
