using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Users.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Users
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class PersonFhirBasesAppService : CdmAppServiceBase, IPersonFhirBasesAppService
    {
        private readonly IPersonFhirBaseCrudHelper<PersonFhirBase, PersonFhirBaseResponse> _personFhirBaseCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personFhirBaseCrudHelper"></param>
        public PersonFhirBasesAppService(
            IPersonFhirBaseCrudHelper<PersonFhirBase, PersonFhirBaseResponse> personFhirBaseCrudHelper)
        {
            _personFhirBaseCrudHelper = personFhirBaseCrudHelper;
        }

        //public static DataTableConfig IndexTable()
        //{
        //    var table = new DataTableConfig<AgentItems, Guid>("Agents_Index");

        //    table.AddProperty(e => e.FirstName, d => d.Caption("Name"));
        //    table.AddProperty(e => e.LastName, d => d.Caption("Surname"));
        //    table.AddProperty(e => e.Roles, d => d.Caption("Roles"));
        //    table.AddProperty(e => e.UserName, d => d.Caption("Username"));
        //    table.AddProperty(e => e.EmailAddress1, d => d.Caption("Email Address"));
        //    table.AddProperty(e => e.MobileNumber1, d => d.Caption("Mobile Number"));

        //    table.OnRequestToFilter = (criteria, form) => { };
        //    return table;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<PersonFhirBaseResponse>> GetAllAsync()
        {
            return await _personFhirBaseCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<PersonFhirBaseResponse> GetAsync(Guid id)
        {
            return await _personFhirBaseCrudHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{identityNumber}")]
        public async Task<PersonFhirBaseResponse> GetByIdNumberAsync(string identityNumber)
        {
            return await _personFhirBaseCrudHelper.GetByIdNumberAsync(identityNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<PersonFhirBaseResponse> CreateAsync(PersonFhirBaseInput input)
        {
            await ValidatePermissionsForAdmin(); //validate that system administrator is only person that can create users

            Validation.ValidateText(input?.User?.Name, "Name");
            Validation.ValidateText(input?.User?.Surname, "Surname");
            Validation.ValidateText(input?.User?.UserName, "Username");
            Validation.ValidateText(input?.User?.Password, "Password");
            Validation.ValidateText(input?.ConfirmPassword, "ConfirmPassword");
            Validation.ValidateHospital(input?.Hospitals);
            Validation.ValidateWard(input);
            Validation.ValidateRole(input.Roles);
            Validation.ValidateConfirmPassword(input?.User?.Password, input?.ConfirmPassword);
            Validation.ValidateNumberOfHospitalsForNonCEO(input);
            Validation.ValidateRolesNotToAssignWard(input);

            var personFhirBase = ObjectMapper.Map<PersonFhirBase>(input);
            return await _personFhirBaseCrudHelper.CreateAsync(input, personFhirBase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<PersonFhirBaseResponse> UpdateAsync(PersonFhirBaseInput input)
        {
            await ValidatePermissionsForAdmin(); //validate that system administrator is only person that can create users

            Validation.ValidateText(input?.User?.Name, "Name");
            Validation.ValidateText(input?.User?.Surname, "Surname");
            Validation.ValidateText(input?.User?.UserName, "Username");
            Validation.ValidateText(input?.User?.Password, "Password");
            Validation.ValidateText(input?.ConfirmPassword, "ConfirmPassword");
            Validation.ValidateHospital(input?.Hospitals);
            Validation.ValidateWard(input);
            Validation.ValidateRole(input.Roles);
            Validation.ValidateConfirmPassword(input?.User?.Password, input?.ConfirmPassword);
            Validation.ValidateNumberOfHospitalsForNonCEO(input);
            Validation.ValidateRolesNotToAssignWard(input);

            return await _personFhirBaseCrudHelper.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _personFhirBaseCrudHelper.DeleteAsync(id);
        }
    }
}
