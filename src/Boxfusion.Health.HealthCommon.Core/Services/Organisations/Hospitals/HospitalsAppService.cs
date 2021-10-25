﻿using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Organisations.Hospitals;
using Boxfusion.Health.HealthCommon.Core.Services.Organisations.Hospitals.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Organisations.Hospitals
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class HospitalsAppService : CdmAppServiceBase, IHospitalsAppService
    {
        private readonly IHospitalCrudHelper _HospitalCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HospitalCrudHelper"></param>
        public HospitalsAppService(
            IHospitalCrudHelper HospitalCrudHelper)
        {
            _HospitalCrudHelper = HospitalCrudHelper;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<HospitalResponse>> GetHospitalsAsync()
        {
            return await _HospitalCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<HospitalResponse> GetHospitalAsync(Guid id)
        {
            return await _HospitalCrudHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<HospitalResponse> CreateHospitalAsync(HospitalInput input)
        {
            await ValidatePermissionsForAdmin();
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateReflist(input.OrganisationType, "OrganisationType");
            Validation.ValidateIdWithException(input?.PrimaryAddress?.Id, "Address cannot be empty");
            Validation.ValidateNullableType(input.Latitude, "Latitude");
            Validation.ValidateNullableType(input.Longitude, "Longitude");
            Validation.ValidateText(input?.PrimaryContactTelephone, "Contact Details");
            return await _HospitalCrudHelper.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<HospitalResponse> UpdateHospitalAsync(HospitalInput input)
        {
            await ValidatePermissionsForAdmin();
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateReflist(input.OrganisationType, "OrganisationType");
            Validation.ValidateIdWithException(input?.PrimaryAddress?.Id, "Address cannot be empty");
            Validation.ValidateNullableType(input.Latitude, "Latitude");
            Validation.ValidateNullableType(input.Longitude, "Longitude");
            Validation.ValidateText(input?.PrimaryContactTelephone, "Contact Details");
            return await _HospitalCrudHelper.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteHospitalAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "Hospital Id cannot be empty");
            await _HospitalCrudHelper.DeleteAsync(id);
        }
    }
}
