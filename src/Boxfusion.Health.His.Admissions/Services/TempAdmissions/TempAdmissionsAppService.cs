using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Helpers;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class TempAdmissionsAppService : CdmAppServiceBase, ITempAdmissionsAppService
    {
        private readonly IAdmissionCrudHelper _admissionCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admissionCrudHelper"></param>
        public TempAdmissionsAppService(
            IAdmissionCrudHelper admissionCrudHelper)
        {
            _admissionCrudHelper = admissionCrudHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<AdmissionResponse> GetAsync(Guid id)
        {
            var admission = await _admissionCrudHelper.GetAsync(id);

            return admission;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <param name="currentWardId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{identityNumber}")]
        public async Task ValidateIdentityNumber(string identityNumber, Guid currentWardId)
        {
            await _admissionCrudHelper.ValidateIdentityNumber(identityNumber, currentWardId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<AdmissionResponse> CreateAsync(AdmissionInput input)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();
            Validation.ValidateReflist(input?.IdentificationType, "Identityfication Type");
            Validation.ValidateEntityWithDisplayNameDto(input?.Ward, "Ward");
            Validation.ValidateReflist(input?.Gender, "Gender");
            Validation.ValidateNullableType(input?.StartDateTime, "Admission Date");
            Validation.ValidateText(input?.HospitalAdmissionNumber, "Hospital Admission Number");
            Validation.ValidateText(input?.WardAdmissionNumber, "Ward Admission Number");
            Validation.ValidateReflist(input?.AdmissionType, "Admission Type");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided || input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateText(input?.IdentityNumber, "I.D. No.");
                Validation.ValidateNullableType(input?.DateOfBirth, "Date of Birth");
                Validation.ValidateText(input?.HospitalPatientNumber, "Hospital Patient Number");
                Validation.ValidateText(input?.FirstName, "First Name");
                Validation.ValidateText(input?.HospitalPatientNumber, "Last Name");
                Validation.ValidateReflist(input?.PatientProvince, "Patient Province");
                Validation.ValidateReflist(input?.Classification, "Classification");
                Validation.ValidateReflist(input?.Nationality, "Nationality");
                Validation.ValidateReflist(input?.OtherCategory, "Other Categories");

                if (input?.IdentificationType.ItemValue == (int)RefListIdentificationTypes.SAID)
                {
                    if (!Validation.IsValidIdentityNumber(input?.IdentityNumber))
                        throw new UserFriendlyException("The specified identify number is not a valid South African number.");
                }
            }

            var admission = await _admissionCrudHelper.CreateAsync(input, person);

            return admission;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[HttpPut, Route("")]
        public async Task<AdmissionResponse> UpdateAsync(AdmissionInput input)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();
            Validation.ValidateReflist(input?.IdentificationType, "Identityfication Type");
            Validation.ValidateEntityWithDisplayNameDto(input?.Ward, "Ward");
            Validation.ValidateReflist(input?.Gender, "Gender");
            Validation.ValidateNullableType(input?.StartDateTime, "Admission Date");
            Validation.ValidateText(input?.HospitalAdmissionNumber, "Hospital Admission Number");
            Validation.ValidateText(input?.WardAdmissionNumber, "Ward Admission Number");
            Validation.ValidateReflist(input?.AdmissionType, "Admission Type");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided || input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateText(input?.IdentityNumber, "I.D. No.");
                Validation.ValidateNullableType(input?.DateOfBirth, "Date of Birth");
                Validation.ValidateText(input?.HospitalPatientNumber, "Hospital Patient Number");
                Validation.ValidateText(input?.FirstName, "First Name");
                Validation.ValidateText(input?.HospitalPatientNumber, "Last Name");
                Validation.ValidateReflist(input?.PatientProvince, "Patient Province");
                Validation.ValidateReflist(input?.Classification, "Classification");
                Validation.ValidateReflist(input?.Nationality, "Nationality");
                Validation.ValidateReflist(input?.OtherCategory, "Other Categories");

                if (input?.IdentificationType.ItemValue == (int)RefListIdentificationTypes.SAID)
                {
                    if (!Validation.IsValidIdentityNumber(input?.IdentityNumber))
                        throw new UserFriendlyException("The specified identify number is not a valid South African number.");
                }
            }

            var admission = await _admissionCrudHelper.UpdateAsync(input, person);

            return admission;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
 		[HttpDelete, Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _admissionCrudHelper.DeleteAsync(id);
        }
    }
}
