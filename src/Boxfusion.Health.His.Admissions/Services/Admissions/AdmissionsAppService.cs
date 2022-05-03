using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using local = Boxfusion.Health.His.Admissions.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boxfusion.Health.His.Admissions.Application.Hubs;
using Shesha.NHibernate;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Shesha.Web.DataTable;
using Boxfusion.Health.His.Admissions.Application.Domain.Views;
using Shesha.AutoMapper.Dto;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers;
using Shesha.Extensions;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Abp.Runtime.Session;
using Shesha.Domain;
using Boxfusion.Health.His.Domain.Helpers;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Helpers;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Authorization;
using Boxfusion.Health.His.Admissions.Domain.Dtos;
using Boxfusion.Health.His.Admissions.Application.Configuration;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Application.Helpers;
using AdmissionsUtilityHelper = Boxfusion.Health.His.Admissions.Application.Helpers.UtilityHelper;
using UtilityHelper = Boxfusion.Health.HealthCommon.Core.Helpers.UtilityHelper;
using Boxfusion.Health.His.Common.Domain.Domain;
using Shesha.DynamicEntities.Dtos;
using Boxfusion.Health.His.Common.Domain.Domain.ConditionIcdTenCodes;

namespace Boxfusion.Health.His.Admissions.Application.Services.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AdmissionsAppService : HisAppServiceBase
    {
        private readonly AdmissionsManager _admissionsManager;
        private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepository;
        private readonly ConditionIcdTenCodeManager _conditionIcdTenCodeManager;

        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
        private readonly IHisAdmissionAuditTrailService _hisAdmissionAuditTrailRepository;
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
        /// <param name="hisAdmissionAuditTrailRepository"></param>
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
            IHisAdmissionAuditTrailService hisAdmissionAuditTrailRepository,
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
            _hisAdmissionAuditTrailRepository = hisAdmissionAuditTrailRepository;
            //_hisAdmissPermissionChecker = hisAdmissPermissionChecker;
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _hisUserRepository = hisUserRepository;
            _icdTenCodeRepository = icdTenCodeRepository;
            _conditionIcdTenCodeManager = conditionIcdTenCodeManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig IndexTable()
        {
            var table = new DataTableConfig<AdmittedPatientItems, Guid>("AdmittedPatients_Index");

            table.UseDtos = true;
            table.UpdateUrl = url => "/api/v1/His/TempAdmissions";
            table.AddProperty(a => a.FacilityName, b => b.Caption("Facility Name"));
            table.AddProperty(a => a.IdentificationType, b => b.Caption("ID Type"));
            table.AddProperty(a => a.IdentityNumber, b => b.Caption("I.D No."));
            table.AddProperty(a => a.DateOfBirth, b => b.Caption("D.O.B").SortDescending().IsFilterable(true).Sortable(true));
            table.AddProperty(a => a.Gender, b => b.Caption("Gender"));
            table.AddProperty(a => a.StartDateTime, b => b.Caption("Admission Date").SortDescending().IsFilterable(true).Sortable(true));
            table.AddProperty(a => a.HospitalisationPatientNumber, b => b.Caption("Hospital Patient Number"));
            table.AddProperty(a => a.WardAdmissionNumber, b => b.Caption("Admission Number"));
            table.AddProperty(a => a.FirstName, b => b.Caption("Patient Name"));
            table.AddProperty(a => a.LastName, b => b.Caption("Patient Surname"));
            table.AddProperty(a => a.AdmissionType, b => b.Caption("Admission Type"));
            table.AddProperty(a => a.Speciality, b => b.Caption("Specialty"));
            table.AddProperty(a => a.Province, b => b.Caption("Patient Province"));
            table.AddProperty(a => a.Classification, b => b.Caption("Classification"));
            table.AddProperty(a => a.Nationality, b => b.Caption("Nationality"));
            table.AddProperty(a => a.OtherCategory, b => b.Caption("Other Categories"));
            table.AddProperty(a => a.AdmissionStatus, b => b.Caption("Admission Status"));
            table.AddProperty(a => a.SeparationDate, b => b.Caption("Separation Date"));
            table.AddProperty(a => a.Days, b => b.Caption("Inpatient Days"));

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
        [HttpGet, Route("wardadmissions/partof/{partOfId}")]
        public async Task<List<AdmissionResponse>> GetPatientAuditTrailAsync(Guid partOfId)
        {
            var admissions = await _admissionsManager.GetPatientAuditTrailAsync(partOfId);

            return ObjectMapper.Map<List<AdmissionResponse>>(admissions);
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
            var person = await GetCurrentLoggedPersonFhirBaseAsync();
            var codes = await _conditionIcdTenCodeManager.GetIcdTenCodes(input.Code.Select(a => (Guid)a.Id).ToList());

            var newWardAdmission = ObjectMapper.Map<WardAdmission>(input);
            var hospitalAdmission = ObjectMapper.Map<HospitalAdmission>(input);

            #region Validations for an admission
            ValidateWardAdmissionInput(input);

            if (await _admissionsManager.IsBedStillAvailable(newWardAdmission.Ward.Id))
                throw new UserFriendlyException("The total number of admitted patients has exceeded the total number of beds");
            #endregion

            newWardAdmission.Performer = person;
            var admission = await _admissionsManager.AdmitPatientAsync(newWardAdmission, hospitalAdmission, codes);

            var admissionAudit = await _hisAdmissionAuditTrailRepository.GetAudit(admission.Id, admission.StartDateTime);
            //Create or update AdmissionAuditTrail
            await SaveOrUpdateEntityAsync<HisAdmissionAuditTrail>(EntityId(admissionAudit?.Id), async item =>
            {
                item.Admission = admission;
                item.AdmissionStatus = admission.AdmissionStatus;
                item.AuditTime = admission.StartDateTime.Value.Date;
                item.Initiator = person;
            });

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
            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            var codes = await _conditionIcdTenCodeManager.GetIcdTenCodes(input.Code.Select(a => (Guid)a.Id).ToList());
            var wardAdmission = await _admissionsManager.GetWardAdmissionAsync(input.Id);
            var hospitalAdmission = await _admissionsManager.GetHospitalAdmissionAsync((Guid)input.PartOf?.Id);


            ObjectMapper.Map(input, wardAdmission);
            ObjectMapper.Map(input, hospitalAdmission);
            hospitalAdmission.Id = (Guid)input.PartOf.Id; //Manual assign hospitalAdmissionId back after automapping on line: 236

            wardAdmission.Performer = person;
            var admission = await _admissionsManager.UpdateAsync(wardAdmission, hospitalAdmission, codes);

            var admissionAudit = await _hisAdmissionAuditTrailRepository.GetAudit(admission.Id, admission.StartDateTime);
            await SaveOrUpdateEntityAsync<HisAdmissionAuditTrail>(EntityId(admissionAudit?.Id), async item =>
            {
                item.Admission = admission;
                item.AdmissionStatus = (RefListAdmissionStatuses?)admission.AdmissionStatus;
                item.AuditTime = admission.StartDateTime.Value.Date;
                item.Initiator = person;
            });

            return await MapToDynamicDtoAsync<WardAdmission, Guid>(admission);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("AcceptOrRejectTransfers")]
        public async Task<AcceptOrRejectTransfersResponse> AcceptOrRejectTransfers(AcceptOrRejectTransfersInput input)
        {
            var wardAdmissionService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<WardAdmission, Guid>>();
            var wardAdmission = await GetEntityAsync<WardAdmission>(input.WardAdmissionId);

            if (wardAdmission == null)
                throw new UserFriendlyException("The Patient was not found in the ward Admission register");

            var respose = new AcceptOrRejectTransfersResponse();

            if (input.AcceptanceDecision == RefListAcceptanceDecision.Accept)
            {
                if (wardAdmission.AdmissionStatus != RefListAdmissionStatuses.inTransit)
                    throw new UserFriendlyException("The Petient was not transfered from any ward");

                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.admitted;
                wardAdmission.AdmissionType = RefListAdmissionTypes.internalTransferIn;
                wardAdmission.StartDateTime = DateTime.Now;

                respose.Accepted = true;
            }
            else
            {
                if (wardAdmission?.InternalTransferOriginalWard?.Id == null)
                    throw new UserFriendlyException("The Previous ward record was not found");

                var originalWard = await wardAdmissionService.GetAsync(wardAdmission.InternalTransferOriginalWard.Id);
                wardAdmission.TransferRejectionReason = input?.TransferRejectionReason;
                wardAdmission.TransferRejectionReasonComment = input?.TransferRejectionReasonComment;
                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.rejected;

                originalWard.AdmissionStatus = RefListAdmissionStatuses.admitted;

                await wardAdmissionService.UpdateAsync(originalWard);
                await CurrentUnitOfWork.SaveChangesAsync();
                var _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
                await _sessionProvider.Session.Transaction.CommitAsync();
                respose.Rejected = true;
            }

            await wardAdmissionService.UpdateAsync(wardAdmission);

            var person = await GetCurrentPersonAsync();
            var admissionAudit = await _hisAdmissionAuditTrailRepository.GetAudit(wardAdmission.Id, wardAdmission.StartDateTime);

            if (admissionAudit != null)
            {
                await SaveOrUpdateEntityAsync<HisAdmissionAuditTrail>(admissionAudit.Id, async item =>
                {
                    item.Admission = wardAdmission;
                    item.AdmissionStatus = (RefListAdmissionStatuses?)wardAdmission.AdmissionStatus;
                    item.AuditTime = wardAdmission.StartDateTime.Value.Date;
                    item.Initiator = person;
                });
            }
            else
            {
                await _hisAdmissionAuditTrailRepository.CreateAudit(new HisAdmissionAuditTrail()
                {
                    Admission = wardAdmission,
                    AdmissionStatus = (RefListAdmissionStatuses?)wardAdmission.AdmissionStatus,
                    AuditTime = wardAdmission.StartDateTime.Value.Date,
                    Initiator = person
                });
            }

            return respose;
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

            var admissionResponse = await _admissionsManager.SeparatePatientAsync(input, person);

            return admissionResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admission"></param>
        /// <returns></returns>
        [HttpPut, Route("undoSeparation")]
        public async Task<AdmissionResponse> UndoSeparationAsync(UndoSeparationDto admission)
        {
            var _hisAdmissPermissionChecker = Abp.Dependency.IocManager.Instance.Resolve<IHisAdmissionPermissionChecker>();
            if (!await _hisAdmissPermissionChecker.IsApproverLevel1(await GetCurrentPersonAsync()))
            {
                throw new UserFriendlyException("The logged user is not a level 1 approver");
            }

            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            var separation = await _admissionsManager.UndoSeparation(admission, person);

            var wardAdmission = await GetEntityAsync<WardAdmission>((separation.Id));
            var admissionAudit = await _hisAdmissionAuditTrailRepository.GetAudit(wardAdmission.Id, wardAdmission.StartDateTime);

            if (admissionAudit != null)
            {
                await SaveOrUpdateEntityAsync<HisAdmissionAuditTrail>(admissionAudit.Id, async item =>
                {
                    item.Admission = wardAdmission;
                    item.AdmissionStatus = (RefListAdmissionStatuses?)wardAdmission.AdmissionStatus;
                    item.AuditTime = wardAdmission.StartDateTime.Value.Date;
                    item.Initiator = person;
                });
            }
            else
            {
                await _hisAdmissionAuditTrailRepository.CreateAudit(new HisAdmissionAuditTrail()
                {
                    Admission = wardAdmission,
                    AdmissionStatus = (RefListAdmissionStatuses?)wardAdmission.AdmissionStatus,
                    AuditTime = wardAdmission.StartDateTime.Value.Date,
                    Initiator = person
                });
            }

            return separation;
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

            if (EntityId(input.Subject?.Id) is null)
                throw new UserFriendlyException("Patient Id cannot be empty");
        }

        private Guid? EntityId(Guid? id)
        {
            if (id.HasValue) return id;
            else return null;
        }

    }
}
