using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Helpers;
using local = Boxfusion.Health.His.Admissions.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HisWard, Guid> _wardRepositiory;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmissionRepository"></param>
        /// <param name="admissionCrudHelper"></param>
        /// <param name="hisPatientRepositiory"></param>
        /// <param name="wardRepositiory"></param>
        public TempAdmissionsAppService(
            IRepository<WardAdmission, Guid> wardAdmissionRepository,
            IAdmissionCrudHelper admissionCrudHelper,
            IRepository<HisPatient, Guid> hisPatientRepositiory,
            IRepository<HisWard, Guid> wardRepositiory)
        {
            _admissionCrudHelper = admissionCrudHelper;
            _hisPatientRepositiory = hisPatientRepositiory;
            _wardAdmissionRepositiory = wardAdmissionRepository;
            _wardRepositiory = wardRepositiory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="admissionStatus"></param>
        /// <returns></returns>
        [HttpGet, Route("GetAllByAdmissionStatus")]
        public async Task<List<AdmissionResponse>> GetAllByStatusAsync(Guid wardId, RefListAdmissionStatuses admissionStatus)
        {
            var admissions = await _wardAdmissionRepositiory.GetAllListAsync(r => r.Ward != null && r.Ward.Id == wardId && r.AdmissionStatus == admissionStatus);

             return ObjectMapper.Map<List<AdmissionResponse>>(admissions);
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
        [HttpGet, Route("wardadmissions/partof/{partOfId}")]
        public async Task<List<AdmissionResponse>> GetPatientAuditTrailAsync(Guid partOfId)
        {
            var admissions = await _admissionCrudHelper.GetPatientAuditTrailAsync(partOfId);

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
            Validation.ValidateEntityWithDisplayNameDto(input?.Subject, "Patient");
            Validation.ValidateNullableType(input?.StartDateTime, "Admission Date");
            Validation.ValidateText(input?.WardAdmissionNumber, "Ward Admission Number");
            Validation.ValidateReflist(input?.AdmissionType, "Admission Type");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided && input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateReflist(input?.Classification, "Classification");
                Validation.ValidateText(input?.HospitalAdmissionNumber, "Hospital Admission Number");
            }

            var patient = await _hisPatientRepositiory.GetAsync(input.Subject.Id.Value);
            if (patient == null)
                throw new UserFriendlyException("Patient Id cannot be empty");

            var wardAdmissionCount = await _wardAdmissionRepositiory.GetAll().Where(x => x.AdmissionStatus == RefListAdmissionStatuses.admitted && x.IsDeleted == false && x.Ward.Id == input.Ward.Id.Value).ToListAsync();
            var wardCount = await _wardRepositiory.GetAsync(input.Ward.Id.Value);

            if (wardAdmissionCount.Count() >= wardCount.NumberOfBeds)
                throw new UserFriendlyException("The total number of admitted patients has exceeded the total number of beds");

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
            Validation.ValidateEntityWithDisplayNameDto(input?.PartOf, "Hospital Admission");
            Validation.ValidateNullableType(input?.StartDateTime, "Admission Date");
            Validation.ValidateText(input?.WardAdmissionNumber, "Ward Admission Number");
            Validation.ValidateReflist(input?.AdmissionType, "Admission Type");

            if (input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.NotProvided && input?.IdentificationType?.ItemValue != (int)RefListIdentificationTypes.Other)
            {
                Validation.ValidateText(input?.HospitalAdmissionNumber, "Hospital Admission Number");
                Validation.ValidateReflist(input?.Classification, "Classification");
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
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("separate")]
        public async Task<AdmissionResponse> SeparatePatientAsync(AdmissionInput input)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();
            Validation.ValidateIdWithException(input?.Id, "Admission Id cannot be empty.");
            Validation.ValidateReflist(input?.SeparationType, "Separation Type");
            Validation.ValidateNullableType(input?.SeparationDate, "Separation Date");
            Validation.ValidateEntityWithDisplayNameDto(input?.SeparationCode, "Separation Code");

            var admission = await _wardAdmissionRepositiory.FirstOrDefaultAsync(x => x.Id == input.Id);

            if(admission?.Subject?.DateOfBirth != null)
            {
                if(local.UtilityHelper.GetAge(admission.Subject.DateOfBirth.Value) < 5)
                {
                    Validation.ValidateReflist(input?.SeparationChildHealth, "Separation Child Health");
                }
            }

            if(input?.SeparationType?.ItemValue == (int)RefListSeparationTypes.internalTransfer)
                Validation.ValidateEntityWithDisplayNameDto(input?.SeparationDestinationWard, "Ward");
            if (input?.SeparationType?.ItemValue == (int)RefListSeparationTypes.externalTransfer)
                Validation.ValidateEntityWithDisplayNameDto(input?.TransferToHospital, "Transfer to hospital");

            var admissionResponse = await _admissionCrudHelper.SeparatePatientAsync(input, person);

            return admissionResponse;
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
