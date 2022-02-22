using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Administration.Services.HisPatients.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Boxfusion.Health.His.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Administration.Services.HisPatients
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/administrations/[controller]")]
    public class HisPatientsAppService : CdmAppServiceBase, IHisPatientsAppService
    {
        private readonly IHisPatientCrudHelper _hisPatientCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hisPatientCrudHelper"></param>
        public HisPatientsAppService(
            IHisPatientCrudHelper hisPatientCrudHelper)
        {
            _hisPatientCrudHelper = hisPatientCrudHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig PatientsIndex()
        {
            var table = new DataTableConfig<HisPatient, Guid>("Patients_Index");
            

            table.AddProperty(e => e.FullName, d => d.Caption("Name"));
            table.AddProperty(e => e.IdentityNumber, c => c.Caption("Identity Number"));

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<HisPatientResponse>> GetAllAsync()
        {
            return await _hisPatientCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<HisPatientResponse> GetAsync(Guid id)
        {
            return await _hisPatientCrudHelper.GetAsync(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{identityNumber}")]
        public async Task<HisPatientResponse> GetPatientByIdentityNumber(string identityNumber)
        {
            return await _hisPatientCrudHelper.GetByIdNumberAsync(identityNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<HisPatientResponse> CreateAsync(HisPatientInput input)
        {
            Validation.ValidateReflist(input?.IdentificationType, "Identityfication Type");
            Validation.ValidateReflist(input?.Gender, "Gender");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided && input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateText(input?.IdentityNumber, "I.D. No.");
                Validation.ValidateNullableType(input?.DateOfBirth, "Date of Birth");
                Validation.ValidateText(input?.HospitalPatientNumber, "Hospital Patient Number");
                Validation.ValidateText(input?.FirstName, "First Name");
                Validation.ValidateText(input?.HospitalPatientNumber, "Last Name");
                Validation.ValidateReflist(input?.PatientProvince, "Patient Province");
                Validation.ValidateReflist(input?.Nationality, "Nationality");

                if (input?.IdentificationType.ItemValue == (int)RefListIdentificationTypes.SAID)
                {
                    if (!Validation.IsValidIdentityNumber(input?.IdentityNumber))
                        throw new UserFriendlyException("The specified identify number is not a valid South African number.");
                }
            }

            return await _hisPatientCrudHelper.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<HisPatientResponse> UpdateAsync(HisPatientInput input)
        {
            Validation.ValidateReflist(input?.IdentificationType, "Identityfication Type");
            Validation.ValidateReflist(input?.Gender, "Gender");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided && input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateText(input?.IdentityNumber, "I.D. No.");
                Validation.ValidateNullableType(input?.DateOfBirth, "Date of Birth");
                Validation.ValidateText(input?.HospitalPatientNumber, "Hospital Patient Number");
                Validation.ValidateText(input?.FirstName, "First Name");
                Validation.ValidateText(input?.HospitalPatientNumber, "Last Name");
                Validation.ValidateReflist(input?.PatientProvince, "Patient Province");
                Validation.ValidateReflist(input?.Nationality, "Nationality");

                if (input?.IdentificationType.ItemValue == (int)RefListIdentificationTypes.SAID)
                {
                    if (!Validation.IsValidIdentityNumber(input?.IdentityNumber))
                        throw new UserFriendlyException("The specified identify number is not a valid South African number.");
                }
            }

            return await _hisPatientCrudHelper.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
