using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Admissions.Authorization;
using Boxfusion.Health.His.Admissions.Helpers;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Admissions.Services.Separations.Helpers;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/PatientSeparation")]
    public class SeparationsAppSerives : CdmAppServiceBase, ISeparationsAppService
    {
        private readonly ISeparationService _separationService;
        private readonly IHisAdmissPermissionChecker _hisAdmissPermissionChecker;
        private readonly IHisWardMidnightCensusReportsHelper _hisWardMidnightCensusReportsHelper;
        private readonly IRepository<HisAdmissionAuditTrail, Guid> _hisAdmissionAuditTrailRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="separationService"></param>
        /// <param name="hisAdmissPermissionChecker"></param>
        /// <param name="hisWardMidnightCensusReportsHelper"></param>
        /// <param name="hisAdmissionAuditTrailRepository"></param>
        public SeparationsAppSerives(ISeparationService separationService, 
            IHisAdmissPermissionChecker hisAdmissPermissionChecker,
            IHisWardMidnightCensusReportsHelper hisWardMidnightCensusReportsHelper,
            IRepository<HisAdmissionAuditTrail, Guid> hisAdmissionAuditTrailRepository)
        {
            _separationService = separationService;
            _hisAdmissPermissionChecker = hisAdmissPermissionChecker;
            _hisWardMidnightCensusReportsHelper = hisWardMidnightCensusReportsHelper;
            _hisAdmissionAuditTrailRepository = hisAdmissionAuditTrailRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<AdmissionResponse> CreateAsync(SeparationInput input)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            Validation.ValidateReflist(input?.SeparationType, "Separation Type");

            Validation.ValidateNullableType(input?.SeparationDate, "Separation Date");
            Validation.ValidateNullableType(input?.Code, "Icd-10 Code");


            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.internalTransfer)
            {
                Validation.ValidateNullableType(input?.SeparationDestinationWard, "Separation Destination Ward");
            }

            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.externalTransfer)
            {
                if (input.IsGautengGovFacility)
                    Validation.ValidateNullableType(input?.TransferToHospital, "Gauteng Government Destination Hospital");

                if (!input.IsGautengGovFacility)
                    Validation.ValidateText(input?.TransferToNonGautengHospital, "None Gauteng Government Destination Hospital");
            }

            // var separation = await _separationCrudHelper.CreateAsync(input, person);
            var separation = await _separationService.CreateAsync(input, person);

            return separation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("undoSeparation/{id}")]
        public async Task<AdmissionResponse> UndoSeparationAsync(Guid id)
        {
            if (!await _hisAdmissPermissionChecker.IsApproverLevel1(await GetCurrentPersonAsync()))
            {
                throw new UserFriendlyException("The logged user is not a level 1 approver");
            }

            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            var separation = await _separationService.UndoSeparation(id, person);

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput() { reportDate = (DateTime)separation.StartDateTime.Value.Date, wardId = (Guid)separation.Ward.Id });

            var wardAdmission = ObjectMapper.Map<WardAdmission>(separation.Id);
            await _hisAdmissionAuditTrailRepository.InsertOrUpdateAsync(new HisAdmissionAuditTrail()
            {
                Admission = wardAdmission,
                AdmissionStatus = wardAdmission.AdmissionStatus,
                AuditTime = wardAdmission.StartDateTime,
                Initiator = person
            });

            return separation;
        }
    }
}
