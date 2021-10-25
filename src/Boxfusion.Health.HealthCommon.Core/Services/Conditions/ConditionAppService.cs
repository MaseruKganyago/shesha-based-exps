using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers;
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
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	public class ConditionAppService: CdmAppServiceBase, IConditionAppService
	{
        private readonly IConditionsCrudHelper _conditionsAppServiceBase;
        /// <summary>
        /// 
        /// </summary>
        public ConditionAppService(IConditionsCrudHelper conditionsAppServiceBase)
		{
            _conditionsAppServiceBase = conditionsAppServiceBase;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<ConditionResponse>> GetAllConditions()
        {
            return await _conditionsAppServiceBase.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<ConditionResponse> GetCondtion([FromRoute]Guid id)
        {
            return await _conditionsAppServiceBase.GetByIdAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<ConditionResponse>> GetConditionsByPatient([FromRoute]Guid patientId)
        {
            return await _conditionsAppServiceBase.GetByPatientIdAsync(patientId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{practitionerId}")]
        public async Task<List<ConditionResponse>> GetConditionsByPratitioner(Guid practitionerId)
        {
            return await _conditionsAppServiceBase.GetByPratitionerIdAsync(practitionerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<ConditionResponse> CreateCondition(ConditionInput input)
        {
            return await _conditionsAppServiceBase.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<ConditionResponse> UpdateCondition([FromRoute]Guid id, ConditionInput input)
        {
            input.Id = id;
            return await _conditionsAppServiceBase.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteCondition(Guid id)
        {
            await _conditionsAppServiceBase.DeleteAsync(id);
        }
    }
}
