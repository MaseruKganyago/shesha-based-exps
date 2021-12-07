using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.His.Admissions.Domain.Views;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Admissions.Services.Hospitals.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Boxfusion.Health.HealthCommon.Core.Services;

namespace Boxfusion.Health.His.Admissions.Services.Hospitals.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/admissions/[controller]")]
    public class HisHospitalsAppService : CdmAppServiceBase, IHisHospitalsAppService
    {
        private readonly IHospitalCrudHelper _HospitalCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HospitalCrudHelper"></param>
        public HisHospitalsAppService(
            IHospitalCrudHelper HospitalCrudHelper)
        {
            _HospitalCrudHelper = HospitalCrudHelper;
        }

        //
        public static DataTableConfig IndexTable()
        {
            var table = new DataTableConfig<HospitalItems, Guid>("Hospitals_Index");

            table.AddProperty(e => e.Name, d => d.Caption("Facility Name"));
            table.AddProperty(e => e.Type, c => c.Caption("Facility Type"));
            table.AddProperty(e => e.Address, d => d.Caption("Address"));
            table.AddProperty(e => e.Latitude, d => d.Caption("Latitude"));
            table.AddProperty(e => e.Longitude, d => d.Caption("Longitude"));
            table.AddProperty(e => e.PrimaryContactTelephone, d => d.Caption("Contact Details"));
            table.OnRequestToFilter = (criteria, form) =>
            {
            };

            return table;
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
            //Validation.ValidateIdWithException(input?.PrimaryAddress?.Id, "Address cannot be empty");
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
