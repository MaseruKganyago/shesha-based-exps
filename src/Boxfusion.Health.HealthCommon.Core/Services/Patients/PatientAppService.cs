using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Patients
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class PatientAppService : CdmAppServiceBase, IPatientAppService
	{
		private readonly IPatientCrudHelper<CdmPatient> _patientCrudHelper;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientCrudHelper"></param>
		public PatientAppService(IPatientCrudHelper<CdmPatient> patientCrudHelper)
		{
			_patientCrudHelper = patientCrudHelper;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
		public async Task<List<CdmPatientResponse>> GetAllCdmPatients()
		{
			return ObjectMapper.Map<List<CdmPatientResponse>>(await _patientCrudHelper.GetAllAsync());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, Route("{id}")]
		public async Task<CdmPatientResponse> GetCdmPatientById(Guid id)
		{
			return ObjectMapper.Map<CdmPatientResponse>(await _patientCrudHelper.GetByIdAsync(id));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("")]
		public async Task<CdmPatientResponse> CreateCdmPatient(CdmPatientInput input)
		{
			var newEntity = ObjectMapper.Map<CdmPatient>(input);

			return ObjectMapper.Map<CdmPatientResponse>(await _patientCrudHelper.CreateOrUpdateAsync(input, newEntity));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}")]
		public async Task<CdmPatientResponse> UpdateCdmPatient(CdmPatientInput input)
		{
			Validation.ValidateIdWithException((Guid)(input?.Id), "id can not be null.");

			var updatedEntity = ObjectMapper.Map<CdmPatient>(input);

			return ObjectMapper.Map<CdmPatientResponse>(await _patientCrudHelper.CreateOrUpdateAsync(input, updatedEntity));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete, Route("{id}")]
		public async Task DeleteCdmPatient([FromRoute]Guid id)
		{
			await _patientCrudHelper.DeleteAsync(id);
		}
	}
}
