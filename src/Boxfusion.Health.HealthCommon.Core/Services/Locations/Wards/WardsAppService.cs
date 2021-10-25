using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Locations.Wards.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Locations.Wards
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class WardsAppService : CdmAppServiceBase, IWardsAppService
    {
        private readonly IWardCrudHelper _WardCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WardCrudHelper"></param>
        public WardsAppService(
            IWardCrudHelper WardCrudHelper)
        {
            _WardCrudHelper = WardCrudHelper;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<WardResponse>> GetWardsAsync()
        {
            return await _WardCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<WardResponse> GetWardAsync(Guid id)
        {
            return await _WardCrudHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<WardResponse> CreateWardAsync(WardInput input)
        {
            await ValidatePermissionsForAdmin();
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateText(input.Description, "Description");
            Validation.ValidateNullableType(input.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");

            return await _WardCrudHelper.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<WardResponse> UpdateWardAsync(WardInput input)
        {
            await ValidatePermissionsForAdmin();
            Validation.ValidateIdWithException(input?.Id, "Ward Id cannot be empty");
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateText(input.Description, "Description");
            Validation.ValidateNullableType(input.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");

            return await _WardCrudHelper.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteWardAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "Ward Id cannot be empty");
            await _WardCrudHelper.DeleteAsync(id);
        }
    }
}
