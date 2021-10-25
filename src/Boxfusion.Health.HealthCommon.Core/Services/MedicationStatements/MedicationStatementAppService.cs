using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.MedicationStatements.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationStatements
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	public class MedicationStatementAppService: SheshaAppServiceBase, IMedicationStatementAppService
	{
		private readonly IMedicationStatementsCrudHelper _medicationStatementCrudHelper;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="medicationStatementCrudHelper"></param>
		public MedicationStatementAppService(IMedicationStatementsCrudHelper medicationStatementCrudHelper)
		{
			_medicationStatementCrudHelper = medicationStatementCrudHelper;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
		public async Task<List<MedicationStatementResponse>> GetAllMedicationStatements()
		{
			return await _medicationStatementCrudHelper.GetAllAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, Route("{id}")]
		public async Task<MedicationStatementResponse> GetMedicationStatement([FromRoute] Guid id)
		{
			return await _medicationStatementCrudHelper.GetByIdAsync(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		[HttpGet, Route("[action]/{patientId}")]
		public async Task<List<MedicationStatementResponse>> GetMedicationStatementsByPatientId([FromRoute] Guid patientId)
		{
			return await _medicationStatementCrudHelper.GetByPatientIdAsync(patientId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		[HttpGet, Route("[action]/{practitionerId}")]
		public async Task<List<MedicationStatementResponse>> GetMedicationStatementsByPractitionerId([FromRoute] Guid practitionerId)
		{
			return await _medicationStatementCrudHelper.GetByPractitionerIdAsync(practitionerId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("")]
		public async Task<MedicationStatementResponse> CreateMedicationStatement(MedicationStatementInput input)
		{
			return await _medicationStatementCrudHelper.CreateOrUpdateAsync(input);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}")]
		public async Task<MedicationStatementResponse> UpdateMedicationStatement([FromRoute] Guid id, MedicationStatementInput input)
		{
			Validation.ValidateIdWithException(id, $"id can not be null.");

			return await _medicationStatementCrudHelper.CreateOrUpdateAsync(input);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete, Route("{id}")]
		public async Task DeleteMedicationStatement([FromRoute] Guid id)
		{
			await _medicationStatementCrudHelper.DeleteAsync(id);
		}
	}
}
