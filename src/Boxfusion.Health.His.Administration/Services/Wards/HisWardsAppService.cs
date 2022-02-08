using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Administration.Domain.Views;
using Boxfusion.Health.His.Administration.Services.Wards.Dtos;
using Boxfusion.Health.His.Domain.Authorization;
using Boxfusion.Health.His.Admissions.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Utilities;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/administrations/[controller]")]
    public class HisWardsAppService : CdmAppServiceBase, IHisWardsAppService
    {
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly IUserAccessRightService _userAccessRightService;
        private readonly IWardCrudHelper _wardCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardMidnightCensusReport"></param>
        /// <param name="userAccessRightService"></param>
        /// <param name="wardCrudHelper"></param>
        public HisWardsAppService(
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport,
            IUserAccessRightService userAccessRightService,
            IWardCrudHelper wardCrudHelper)
        {
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _userAccessRightService = userAccessRightService;
            _wardCrudHelper = wardCrudHelper;
        }

        /// <summary>
        /// Ward index table
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig IndexTable()
        {
            var table = new DataTableConfig<WardItems, Guid>("Wards_Index");

            table.AddProperty(e => e.Speciality, c => c.Caption("Ward Speciality"));
            table.AddProperty(e => e.Name, d => d.Caption("Ward Name"));
            table.AddProperty(e => e.Description, d => d.Caption("Ward Description"));
            table.AddProperty(e => e.NumberOfBeds, d => d.Caption("No. of Beds"));
            table.OnRequestToFilterStaticAsync = async (criteria, form) =>
            {
                var _session = Abp.Dependency.IocManager.Instance.Resolve<IAbpSession>();
                var _hisAdmissPermissionChecker = Abp.Dependency.IocManager.Instance.Resolve<IHisPermissionChecker>();
                var personService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Person, Guid>>();
                var _hospitalRoleAppointedPersonRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
                var _wardRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HisWard, Guid>>();
                var person = personService.FirstOrDefault(c => c.User.Id == _session.GetUserId());
                var hospitalId = _hospitalRoleAppointedPersonRepository.GetAll().Where(s => s.Person == person).Select(s => s.Hospital.Id).FirstOrDefault();
                var isAdmin = await _hisAdmissPermissionChecker.IsAdmin(person);

                if (!isAdmin)
                {
                    criteria.FilterClauses.Add($"ent.HospitalId = '{hospitalId}'");
                }
            };

            return table;
        }

        /// <summary>
        /// Speciality
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig SpecialityIndexTable()
        {
            var table = new DataTableConfig<SpecialityItems, Guid>("Specialities_Index");

            table.AddProperty(e => e.Speciality, c => c.Caption("Specialities"));
            table.AddProperty(e => e.NumberOfBedsInSpeciality, d => d.Caption("No. of Beds"));
            table.OnRequestToFilterStaticAsync = async (criteria, form) =>
            {
                var session = Abp.Dependency.IocManager.Instance.Resolve<IAbpSession>();
                var _hisAdmissPermissionChecker = Abp.Dependency.IocManager.Instance.Resolve<IHisPermissionChecker>();
                var personService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Person, Guid>>();
                var hisHospitalRoleAppointedPersonService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();

                var person = personService.FirstOrDefault(c => c.User.Id == session.UserId);
                var hospital = hisHospitalRoleAppointedPersonService.GetAll().Where(s => s.Person == person).Select(s => s.Hospital).FirstOrDefault();
                var isAdmin = await _hisAdmissPermissionChecker.IsAdmin(person);

                if (!isAdmin)
                {
                    criteria.FilterClauses.Add($"ent.HospitalId = '{hospital.Id}'");
                }
            };

            return table;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("AssignedHospitals")]
        public async Task<List<HospitalResponse>> GetAssignedHospitals()
        {
            var currentPerson = await GetCurrentPersonAsync();
            var appointmentService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
            var hisAdmissPermissionChecker = Abp.Dependency.IocManager.Instance.Resolve<IHisPermissionChecker>();
            var hospitals = new List<HisHospital>();

            if (!await hisAdmissPermissionChecker.IsAdmin(currentPerson))
            {
                hospitals = await appointmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Hospital).ToListAsync();
            }
            else
            {
                var hospitalService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HisHospital, Guid>>();
                hospitals = await hospitalService.GetAll().ToListAsync();
            }

            return ObjectMapper.Map<List<HospitalResponse>>(hospitals);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("AssignedWards")]
        public async Task<List<HisWardResponse>> GetAssignedWards()
        {
            var currentPerson = await GetCurrentPersonAsync();
            var appointmentService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<WardRoleAppointedPerson, Guid>>();
            var wards = await appointmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Ward).ToListAsync();

            return ObjectMapper.Map<List<HisWardResponse>>(wards);
        }
  
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<HisWardResponse>> GetWardsAsync()
        {
            return await _wardCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{hospitalId}")]
        public async Task<List<HisWardResponse>> GetWardByHospitalAsync(Guid hospitalId)
        {
            return await _wardCrudHelper.GetWardByHospitalAsync(hospitalId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerOrganisationId"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet, Route("ownerOrganisation/{ownerOrganisationId}")]
        public async Task<List<AutocompleteItemDto>> GetWardByHospitalAutoCompleteAsync(Guid ownerOrganisationId, string term = null)
        {
            term = (term ?? "").ToLower();
            return ObjectMapper.Map<List<AutocompleteItemDto>>(await _wardCrudHelper.GetWardByHospitalAutoCompleteAsync(term, ownerOrganisationId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<HisWardResponse> GetWardAsync(Guid id)
        {
            return await _wardCrudHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [AbpAuthorize(PermissionNames.CreateFacility)]
        public async Task<HisWardResponse> CreateWardAsync(HisWardInput input)
        {
            Validation.ValidateText(input?.Name, "Name");
            Validation.ValidateText(input?.Description, "Description");
            Validation.ValidateNullableType(input?.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");

            var hospitals = await GetAssignedHospitals();
            if (hospitals.Any())
            {
                input.OwnerOrganisation = new EntityWithDisplayNameDto<Guid?>()
                {
                    DisplayText = hospitals[0].Name,
                    Id = hospitals[0].Id
                };
            }
            else
            {
                Validation.ValidateEntityWithDisplayNameDto(input?.OwnerOrganisation, "OwnerOrganisation");
            }

            return await _wardCrudHelper.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<HisWardResponse> UpdateWardAsync(HisWardInput input)
        {
            Validation.ValidateIdWithException(input?.Id, "Ward Id cannot be empty");
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateText(input.Description, "Description");
            Validation.ValidateNullableType(input.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");

            var hospitals = await GetAssignedHospitals();
            if (hospitals.Any())
            {
                input.OwnerOrganisation = new EntityWithDisplayNameDto<Guid?>()
                {
                    DisplayText = hospitals[0].Name,
                    Id = hospitals[0].Id
                };
            }
            else
            {
                Validation.ValidateEntityWithDisplayNameDto(input?.OwnerOrganisation, "OwnerOrganisation");
            }

            return await _wardCrudHelper.UpdateAsync(input);
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
            await _wardCrudHelper.DeleteAsync(id);
        }                
    }
}
