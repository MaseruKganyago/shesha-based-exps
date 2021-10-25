using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Services.AllergyIntolerances.Helpers;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.AllergyIntolerances
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class AllergyIntoleranceAppService : CdmAppServiceBase, IAllergyIntoleranceAppService
    {
        private readonly IAllergyIntoleranceCrudHelper _allergyIntoleranceAppServiceBase;
        private readonly IRepository<AllergyIntoleranceCode, Guid> _allergyIntoleranceCodeRepository;

        /// <summary>
        /// 
        /// </summary>
        public AllergyIntoleranceAppService(IAllergyIntoleranceCrudHelper allergyIntoleranceAppServiceBase,
            IRepository<AllergyIntoleranceCode, Guid> allergyIntoleranceCodeRepository)
        {
            _allergyIntoleranceAppServiceBase = allergyIntoleranceAppServiceBase;
            _allergyIntoleranceCodeRepository = allergyIntoleranceCodeRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<AllergyIntoleranceResponse>> GetAllAllergyIntolerances()
        {
            return await _allergyIntoleranceAppServiceBase.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<AllergyIntoleranceResponse> GetAllergyIntoleranceById([FromRoute] Guid id)
        {
            return await _allergyIntoleranceAppServiceBase.GetByIdAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{patientId}")]
        public async Task<List<AllergyIntoleranceResponse>> GetAllergyIntoleranceByPatient([FromRoute] Guid patientId)
        {
            return await _allergyIntoleranceAppServiceBase.GetByPatientIdAsync(patientId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{practitionerId}")]
        public async Task<List<AllergyIntoleranceResponse>> GetAllergyIntoleranceByPratitioner(Guid practitionerId)
        {
            return await _allergyIntoleranceAppServiceBase.GetByPratitionerIdAsync(practitionerId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet, Route("Autocomplete")]
        public async Task<List<EntityWithDisplayNameDto<Guid>>> AllergyIntoleranceCodeAutoCompleteList(string term)
        {
            term = (term ?? "").ToLower();

            var codes = await _allergyIntoleranceCodeRepository.GetAll()
                             .Where(a => (a.Code ?? "").ToLower().Contains(term) || (a.Description ?? "").ToLower().Contains(term))
                             .Take(10).ToListAsync();

            var output = new List<EntityWithDisplayNameDto<Guid>>();
            codes.ForEach(code =>
            {
                output.Add(new EntityWithDisplayNameDto<Guid>(code.Id, $"{code.Code} {code.Description}"));
            });

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<AllergyIntoleranceResponse> CreateAllergyIntolerance(AllergyIntoleranceInput input)
        {
            return await _allergyIntoleranceAppServiceBase.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        public async Task<AllergyIntoleranceResponse> UpdateAllergyIntolerance([FromRoute] Guid id, AllergyIntoleranceInput input)
        {
            input.Id = id;
            return await _allergyIntoleranceAppServiceBase.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteCondition(Guid id)
        {
            await _allergyIntoleranceAppServiceBase.DeleteAsync(id);
        }
    }
}
