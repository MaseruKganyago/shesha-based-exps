using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Microsoft.AspNetCore.Mvc;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Boxfusion.Health.HealthCommon.Core.Services;
using Abp.Runtime.Session;
using Boxfusion.Health.HealthCommon.Core;
using Shesha.Domain;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Domain.Domain;
using System.Linq;
using Boxfusion.Health.His.Admissions.Domain.Views;
using Boxfusion.Health.His.Administration.Services.Hospitals.Helpers;
using Boxfusion.Health.His.Contracts.Interfaces.Hospitals;

namespace Boxfusion.Health.His.Administration.Services.Hospitals
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/administrations/[controller]")]
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
            table.UseDtos = true;
            table.DetailsUrl = url => "/api/v1/admissions/HisHospitals";
            table.CreateUrl = url => "/api/v1/admissions/HisHospitals";
            table.UpdateUrl = url => "/api/v1/admissions/HisHospitals";
            table.DeleteUrl = url => "/api/v1/admissions/HisHospitals";

            table.AddProperty(e => e.Name, d => d.Caption("Facility Name"));
            table.AddProperty(e => e.Type, c => c.Caption("Facility Type"));
            table.AddProperty(e => e.Address, d => d.Caption("Address"));
            table.AddProperty(e => e.Latitude, d => d.Caption("Latitude"));
            table.AddProperty(e => e.Longitude, d => d.Caption("Longitude"));
            table.AddProperty(e => e.PrimaryContactTelephone, d => d.Caption("Contact Details"));
            table.OnRequestToFilterStaticAsync = async (criteria, form) =>
            {
                var _session = Abp.Dependency.IocManager.Instance.Resolve<IAbpSession>();
                var _permissionChecker = Abp.Dependency.IocManager.Instance.Resolve<ICdmPermissionChecker>();
                var personService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Person, Guid>>();
                var person = personService.FirstOrDefault(c => c.User.Id == _session.GetUserId());

                if (!await _permissionChecker.IsAdmin(person))
                {
                    var _hospitalRoleAppointedPersonRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();

                    var hospitalId = _hospitalRoleAppointedPersonRepository.GetAll().Where(s => s.Person == person).Select(s => s.Hospital.Id).FirstOrDefault();
                    criteria.FilterClauses.Add($"ent.Id = '{hospitalId}'");
                }

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
            //await ValidatePermissionsForAdmin();
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateReflist(input.FacilityType, "FacilityType");
            Validation.ValidateReflist(input.District, "District");
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
            //await ValidatePermissionsForAdmin();
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateReflist(input.FacilityType, "FacilityType");
            Validation.ValidateReflist(input.District, "District");
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
