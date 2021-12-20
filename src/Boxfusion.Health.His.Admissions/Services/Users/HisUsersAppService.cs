using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Dashboard;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.SQL;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.HealthCommon.Core.Services.Users.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.Users.Helpers;
using Boxfusion.Health.His.Admissions.Services.Users.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha.Authorization.Users;
using Shesha.Domain;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Users
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/admissions/[controller]")]
    public class HisUsersAppService : CdmAppServiceBase, IHisUsersAppService
    {
        private readonly IHisUserCrudHelper _hisUserCrudHelper;
        private readonly IRepository<PersonFhirBase, Guid> _personRepository;
        private readonly IRepository<User, long> _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hisUserCrudHelper"></param>
        /// <param name="personRepository"></param>
        /// <param name="userRepository"></param>
        public HisUsersAppService(
            IHisUserCrudHelper hisUserCrudHelper, 
            IRepository<PersonFhirBase, Guid> personRepository, 
            IRepository<User, long> userRepository)
        {
            _hisUserCrudHelper = hisUserCrudHelper;
            _personRepository = personRepository;
            _userRepository = userRepository;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig IndexTable()
        {
            var table = new DataTableConfig<UserItems, Guid>("MidnightCensusUsers_Index");

            table.AddProperty(e => e.FirstName, d => d.Caption("Name"));
            table.AddProperty(e => e.LastName, d => d.Caption("Surname"));
            table.AddProperty(e => e.UserName, d => d.Caption("UserName"));
            //table.AddProperty(e => e.Supervisor, d => d.Caption("Supervisor"));
            table.OnRequestToFilterStaticAsync = async (criteria, form) => 
            {
                var _session = Abp.Dependency.IocManager.Instance.Resolve<IAbpSession>();
                var _permissionChecker = Abp.Dependency.IocManager.Instance.Resolve<ICdmPermissionChecker>();
                var personService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Person, Guid>>();
                var person = personService.FirstOrDefault(c => c.User.Id == _session.GetUserId());

                if (!await _permissionChecker.IsAdmin(person))
                {
                    var _hospitalRoleAppointedPersonRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
                    var _wardRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Ward, Guid>>();

                    var hospitalId = _hospitalRoleAppointedPersonRepository.GetAll().Where(s => s.Person == person).Select(s => s.Hospital.Id).FirstOrDefault();
                    criteria.FilterClauses.Add($"ent.HospitalId = '{hospitalId}'");
                }
                
            };
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<HisUserResponse>> GetAllAsync()
        {
            return await _hisUserCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<HisUserResponse> GetAsync(Guid id)
        {
            return await _hisUserCrudHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{identityNumber}")]
        public async Task<HisUserResponse> GetByIdNumberAsync(string identityNumber)
        {
            return await _hisUserCrudHelper.GetByIdNumberAsync(identityNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [AbpAuthorize(Shesha.Authorization.PermissionNames.Pages_Users)]
        public async Task<HisUserResponse> CreateAsync(HisUserInput input)
        {
           // await ValidatePermissionsForAdmin(); //validate that system administrator is only person that can create users
            Validation.ValidateText(input?.User?.Name, "Name");
            Validation.ValidateText(input?.User?.Surname, "Surname");
            Validation.ValidateText(input?.User?.UserName, "Username");
            Validation.ValidateText(input?.User?.Password, "Password");
            Validation.ValidateText(input?.ConfirmPassword, "ConfirmPassword");
            Validation.ValidateEntityWithDisplayNameDto(input?.Hospitals, "Hospital");
            //Validation.ValidateEntityWithDisplayNameDto(input?.Wards, "Ward");
            Validation.ValidateEntityWithDisplayNameDto(input.Roles, "Role");
            Validation.ValidateConfirmPassword(input?.User?.Password, input?.ConfirmPassword);

            //Validate if identity number already exists
            if (!string.IsNullOrWhiteSpace(input.IdentityNumber))
            {
                var personExist = await _personRepository.FirstOrDefaultAsync(x => x.IdentityNumber == input.IdentityNumber);
                if (personExist != null)
                    throw new UserFriendlyException("User with provided identity number already exists");
            }

            //Validate if username already exists
            if (!string.IsNullOrWhiteSpace(input?.User?.UserName))
            {
                var userExist = await _userRepository.FirstOrDefaultAsync(x => x.UserName == input.User.UserName);
                if (userExist != null)
                    throw new UserFriendlyException("User with provided username already exists");
            }

            //Validate if email already exists
            if (!string.IsNullOrWhiteSpace(input?.User?.EmailAddress))
            {
                var personExist = await _personRepository.FirstOrDefaultAsync(x => x.EmailAddress1 == input.User.EmailAddress);
                if (personExist != null)
                    throw new UserFriendlyException("User with provided email address already exists");
            }

            Validation.ValidateNumberOfHospitalsForNonCEO(input);
            Validation.ValidateRolesNotToAssignWard(input);

            //var personFhirBase = ObjectMapper.Map<PersonFhirBase>(input);
            return await _hisUserCrudHelper.CreateAsync(input);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<HisUserResponse> UpdateAsync(HisUserInput input)
        {
            //await ValidatePermissionsForAdmin(); //validate that system administrator is only person that can create users
            Validation.ValidateText(input?.User?.Name, "Name");
            Validation.ValidateText(input?.User?.Surname, "Surname");
            Validation.ValidateText(input?.User?.UserName, "Username");
            //Validation.ValidateText(input?.User?.Password, "Password");
            //Validation.ValidateText(input?.ConfirmPassword, "ConfirmPassword");
            Validation.ValidateEntityWithDisplayNameDto(input?.Hospitals, "Hospital");
            //Validation.ValidateEntityWithDisplayNameDto(input?.Wards, "Ward");
            Validation.ValidateEntityWithDisplayNameDto(input.Roles, "Role");
            //Validation.ValidateConfirmPassword(input?.User?.Password, input?.ConfirmPassword);
            Validation.ValidateNumberOfHospitalsForNonCEO(input);
            Validation.ValidateRolesNotToAssignWard(input);

            return await _hisUserCrudHelper.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _hisUserCrudHelper.DeleteAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Supervisor")]
        public async Task<List<SupervisorDto>> GetSupervisor(Guid hospitalId)
        {
            var dataService = Abp.Dependency.IocManager.Instance.Resolve<ISessionDataProvider>();
            return await dataService.GetSupervisor(hospitalId);
        }
    }
}
