using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.ConditionIcdTenCodes;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;
using local = Boxfusion.Health.His.Admissions.Application.Helpers;

namespace Boxfusion.Health.His.Admissions.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AdmissionsAppService : SheshaAppServiceBase
    {
        private readonly AdmissionsManager _admissionsManager;
        private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepository;
        private readonly ConditionIcdTenCodeManager _conditionIcdTenCodeManager;

        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HisWard, Guid> _wardRepositiory;
        //private readonly IHisAdmissionPermissionChecker _hisAdmissPermissionChecker;
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly IRepository<HisUser, Guid> _hisUserRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmissionRepository"></param>
        /// <param name="admissionsManager"></param>
        /// <param name="hisPatientRepositiory"></param>
        /// <param name="wardRepositiory"></param>
        /// <param name="wardMidnightCensusReport"></param>
        /// <param name="userAccessRightService"></param>
        /// <param name="hisUserRepository"></param>
        /// <param name="icdTenCodeRepository"></param>
        /// <param name="conditionIcdTenCodeManager"></param>
		public AdmissionsAppService(
            IRepository<WardAdmission, Guid> wardAdmissionRepository,
            AdmissionsManager admissionsManager,
            IRepository<HisPatient, Guid> hisPatientRepositiory,
            IRepository<HisWard, Guid> wardRepositiory,
            //IHisAdmissionPermissionChecker hisAdmissPermissionChecker,
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport,
            IUserAccessRightService userAccessRightService,
            IRepository<HisUser, Guid> hisUserRepository,
            IRepository<IcdTenCode, Guid> icdTenCodeRepository,
            ConditionIcdTenCodeManager conditionIcdTenCodeManager
            )
        {
            _admissionsManager = admissionsManager;
            _hisPatientRepositiory = hisPatientRepositiory;
            _wardAdmissionRepositiory = wardAdmissionRepository;
            _wardRepositiory = wardRepositiory;
            //_hisAdmissPermissionChecker = hisAdmissPermissionChecker;
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _hisUserRepository = hisUserRepository;
            _icdTenCodeRepository = icdTenCodeRepository;
            _conditionIcdTenCodeManager = conditionIcdTenCodeManager;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("[action]")]
        public async Task ValidateIdentityNumber(ValidateIdDto input)
        {
            await _admissionsManager.ValidateIdentityNumber(input?.IdentityNumber, (Guid)input?.CurrentWardId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Admissions/AdmitPatient")]
        public async Task<DynamicDto<WardAdmission, Guid>> AdmitPatientAsync(AdmissionInput input)
        {
            var person = await GetCurrentPersonAsync();
            var codes = await _conditionIcdTenCodeManager.GetIcdTenCodes(input.Code.Select(a => (Guid)a.Id).ToList());

            var newWardAdmission = ObjectMapper.Map<WardAdmission>(input);
            var hospitalAdmission = ObjectMapper.Map<HospitalAdmission>(input);

            #region Validations for an admission
            ValidateWardAdmissionInput(input);

            if (!(await _admissionsManager.IsBedStillAvailable(newWardAdmission.Ward.Id)))
                throw new UserFriendlyException("The total number of admitted patients has exceeded the total number of beds");
            #endregion

            newWardAdmission.Performer = person; //Manually assign current loggedIn person as performer
            var admission = await _admissionsManager.AdmitPatientAsync(newWardAdmission, hospitalAdmission, codes);

            return await MapToDynamicDtoAsync<WardAdmission, Guid>(admission);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut, Route("Admissions/UpdateAdmission")]
        public async Task<DynamicDto<WardAdmission, Guid>> UpdateAdmissionAsync(AdmissionInput input)
        {
            ValidateWardAdmissionInput(input);
            var person = await GetCurrentPersonAsync();

            var codes = await _conditionIcdTenCodeManager.GetIcdTenCodes(input.Code.Select(a => (Guid)a.Id).ToList());
            var wardAdmission = await _admissionsManager.GetWardAdmissionAsync(input.Id);
            var hospitalAdmission = await _admissionsManager.GetHospitalAdmissionAsync((Guid)input.PartOf?.Id);


            ObjectMapper.Map(input, wardAdmission);
            ObjectMapper.Map(input, hospitalAdmission);
            hospitalAdmission.Id = (Guid)input.PartOf.Id; //Manual assign hospitalAdmissionId back after automapping on line: 236

            wardAdmission.Performer = person; //Manually assign current loggedId person as performer
            var admission = await _admissionsManager.UpdateAsync(wardAdmission, hospitalAdmission, codes);

            return await MapToDynamicDtoAsync<WardAdmission, Guid>(admission);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("Admissions/SeparatePatient")]
        public async Task<DynamicDto<WardAdmission, Guid>> SeparatePatientAsync(SeparationDto input)
        {
            Validation.ValidateIdWithException(input.Id, "Admission Id cannot be empty.");
            var admission = await _admissionsManager.GetWardAdmissionAsync(input.Id);

            ValidateAdmissionDischargeInputs(input, admission);

            var person = await GetCurrentPersonAsync();
            var hospitalAdmission = await _admissionsManager.GetHospitalAdmissionAsync(admission.PartOf.Id);
            var codes = await _conditionIcdTenCodeManager.GetIcdTenCodes(input.SeparationCodes.Select(a => (Guid)a.Id).ToList());

            ObjectMapper.Map(input, admission);
            ObjectMapper.Map(input, hospitalAdmission);
            admission.Performer = person; //Manually assign current loggedIn person as performer
            var separatedAdmission = await _admissionsManager.SeparatePatientAsync(admission, hospitalAdmission, codes);

            return await MapToDynamicDtoAsync<WardAdmission, Guid>(separatedAdmission);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        [HttpPut, Route("Admissions/UndoSeparation/{admissionId}")]
        public async Task<DynamicDto<WardAdmission, Guid>> UndoSeparationAsync([FromRoute]Guid admissionId)
        {
            var person = await GetCurrentPersonAsync();

            var reAdmission = await _admissionsManager.UndoSeparation(admissionId, person);

            return await MapToDynamicDtoAsync<WardAdmission, Guid>(reAdmission);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("AcceptOrRejectTransfers")]
        public async Task<AcceptOrRejectTransfersResponse> AcceptOrRejectTransfers(AcceptOrRejectTransfersInput input)
        {
            var wardAdmission = await GetEntityAsync<WardAdmission>(input.WardAdmissionId);

            if (wardAdmission == null)
                throw new UserFriendlyException("The Patient was not found in the ward Admission register");

            var admissionEntity = await _admissionsManager.AcceptOrRejectTransfers((RefListAcceptanceDecision)input.AcceptanceDecision, wardAdmission,
																			(RefListTransferRejectionReasons)input.TransferRejectionReason, input.TransferRejectionReasonComment);

            var response = new AcceptOrRejectTransfersResponse();
            if (admissionEntity.AdmissionStatus.Equals(RefListAdmissionStatuses.admitted)) response.Accepted = true;
            else if (admissionEntity.AdmissionStatus.Equals(RefListAdmissionStatuses.rejected)) response.Rejected = true;

            return response;
        }


        private void ValidateWardAdmissionInput(AdmissionInput input)
        {
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

            if ((bool)(!input.Subject?.Id.HasValue))
                throw new UserFriendlyException("Patient Id cannot be empty");
        }

        private void ValidateAdmissionDischargeInputs(SeparationDto input, WardAdmission admission)
        {
            Validation.ValidateReflist(input?.SeparationType, "Separation Type");
            Validation.ValidateNullableType(input?.SeparationDate, "Separation Date");
            Validation.ValidateEntityWithDisplayNameDto(input?.SeparationCodes, "Separation Code");

            if (admission?.Subject?.DateOfBirth != null)
            {
                if (local.UtilityHelper.GetAge(admission.Subject.DateOfBirth.Value) < 5)
                {
                    Validation.ValidateReflist(input?.SeparationChildHealth, "Separation Child Health");
                }
            }

            if (input?.SeparationType?.ItemValue == (int)RefListSeparationTypes.internalTransfer)
                Validation.ValidateEntityWithDisplayNameDto(input?.SeparationDestinationWard, "Ward");
            if (input?.SeparationType?.ItemValue == (int)RefListSeparationTypes.externalTransfer)
            {
                if (input.IsGautengGovFacility)
                {
                    Validation.ValidateEntityWithDisplayNameDto(input?.TransferToHospital, "Transfer to hospital");
                }
                else
                {
                    Validation.ValidateText(input?.TransferToNonGautengHospital, "Transfer To Non Gauteng Hospital");
                }
            }
        }

    }
}
