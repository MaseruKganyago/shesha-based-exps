using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admissionCrudHelper"></param>
        /// <param name="hisPatientRepositiory"></param>
        public TempAdmissionsAppService(
            IAdmissionCrudHelper admissionCrudHelper,
            IRepository<HisPatient, Guid> hisPatientRepositiory)
        {
            _admissionCrudHelper = admissionCrudHelper;
            _hisPatientRepositiory = hisPatientRepositiory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<AdmissionResponse>> GetAllAsync(Guid wardId, DateTime admissionDate)
        {
            var admissions = await _admissionCrudHelper.GetAllAsync(wardId, admissionDate);

            return admissions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{patientId}/patient")]
        public async Task<List<PatientAuditTrailDto>> GetPatientAuditTrailAsync(Guid patientId)
        {
            var admissions = await _admissionCrudHelper.GetPatientAuditTrailAsync(patientId);

            return admissions;
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
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("[action]")]
        public async Task ValidateIdentityNumber(ValidateIdDto input)
        {
            await _admissionCrudHelper.ValidateIdentityNumber(input?.IdentityNumber, (Guid)input?.CurrentWardId);
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
            Validation.ValidateEntityWithDisplayNameDto(input?.Ward, "Ward");
            Validation.ValidateEntityWithDisplayNameDto(input.Subject, "Patient");
            Validation.ValidateNullableType(input?.StartDateTime, "Admission Date");
            Validation.ValidateText(input?.HospitalAdmissionNumber, "Hospital Admission Number");
            Validation.ValidateText(input?.WardAdmissionNumber, "Ward Admission Number");
            Validation.ValidateReflist(input?.AdmissionType, "Admission Type");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided || input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateReflist(input?.Classification, "Classification");
                Validation.ValidateReflist(input?.OtherCategory, "Other Categories");
            }

            var patient = await _hisPatientRepositiory.GetAsync(input.Subject.Id.Value);
            if (patient == null)
                throw new UserFriendlyException("Patient Id cannot be empty");

            var admission = await _admissionCrudHelper.CreateAsync(input, person, patient);

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
            Validation.ValidateEntityWithDisplayNameDto(input?.Ward, "Ward");
            Validation.ValidateEntityWithDisplayNameDto(input?.Subject, "Patient");
            Validation.ValidateNullableType(input?.StartDateTime, "Admission Date");
            Validation.ValidateText(input?.HospitalAdmissionNumber, "Hospital Admission Number");
            Validation.ValidateText(input?.WardAdmissionNumber, "Ward Admission Number");
            Validation.ValidateReflist(input?.AdmissionType, "Admission Type");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided || input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateReflist(input?.Classification, "Classification");
                Validation.ValidateReflist(input?.OtherCategory, "Other Categories");
            }

            var patient = await _hisPatientRepositiory.GetAsync(input.Subject.Id.Value);
            if (patient == null)
                throw new UserFriendlyException("Patient Id cannot be empty");

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("wardAdmission/{id}")]
        public async Task<AdmissionResponse> GetWardAdmission(Guid id)
        {
            var wardAdmission = await _admissionCrudHelper.GetAsync(id);
            return wardAdmission;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet, Route("patient/{id}")]
        //public async Task<PatientResponse> GetPatient(Guid id)
        //{
        //    var patient = await _hisPatientRepositiory.GetAsync(id);
        //    return patient;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("wardAdmissions/{id}")]
        public async Task<List<AdmissionResponse>> GetWardAdmissions(Guid id)
        {
            var wardAdmissions = await _admissionCrudHelper.GetWardAdmissions(id);
            return wardAdmissions;
        }


    }
}
