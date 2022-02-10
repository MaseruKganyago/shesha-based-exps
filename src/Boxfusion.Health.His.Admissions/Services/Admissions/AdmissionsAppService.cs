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
using Boxfusion.Health.His.Admissions.Hubs;
using Boxfusion.Health.His.Admissions.Helpers;
using Shesha.NHibernate;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Shesha.Web.DataTable;
using Boxfusion.Health.His.Admissions.Domain.Views;
using Boxfusion.Health.His.Domain.Dtos;
using Shesha.AutoMapper.Dto;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers;
using Shesha.Extensions;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Abp.Runtime.Session;
using Shesha.Domain;
using Boxfusion.Health.His.Domain.Helpers;
using Boxfusion.Health.His.Admissions.Services.Reports.Helpers;
using Boxfusion.Health.His.Admissions.Services.Reports.Dto;
using Boxfusion.Health.His.Domain.Authorization;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AdmissionsAppService : CdmAppServiceBase, IAdmissionsAppService
    {
        private readonly IAdmissionCrudHelper _admissionCrudHelper;

        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
        private readonly IHisAdmissionAuditTrailService _hisAdmissionAuditTrailRepository;
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HisWard, Guid> _wardRepositiory;
        private readonly IHisPermissionChecker _hisAdmissPermissionChecker;
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly IHisWardMidnightCensusReportsHelper _hisWardMidnightCensusReportsHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmissionRepository"></param>
        /// <param name="admissionCrudHelper"></param>
        /// <param name="hisPatientRepositiory"></param>
        /// <param name="wardRepositiory"></param>
        /// <param name="hisWardMidnightCensusReportsHelper"></param>
        /// <param name="hisAdmissionAuditTrailRepository"></param>
        /// <param name="hisAdmissPermissionChecker"></param>
        /// <param name="wardMidnightCensusReport"></param>
        /// <param name="userAccessRightService"></param>
        public AdmissionsAppService(
            IRepository<WardAdmission, Guid> wardAdmissionRepository,
            IAdmissionCrudHelper admissionCrudHelper,
            IRepository<HisPatient, Guid> hisPatientRepositiory,
            IRepository<HisWard, Guid> wardRepositiory,
            IHisAdmissionAuditTrailService hisAdmissionAuditTrailRepository,
            IHisPermissionChecker hisAdmissPermissionChecker,
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport,
            IUserAccessRightService userAccessRightService,
            IHisWardMidnightCensusReportsHelper hisWardMidnightCensusReportsHelper
            )
        {
            _admissionCrudHelper = admissionCrudHelper;
            _hisPatientRepositiory = hisPatientRepositiory;
            _wardAdmissionRepositiory = wardAdmissionRepository;
            _wardRepositiory = wardRepositiory;
            _hisAdmissionAuditTrailRepository = hisAdmissionAuditTrailRepository;
            _hisAdmissPermissionChecker = hisAdmissPermissionChecker;
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _hisWardMidnightCensusReportsHelper = hisWardMidnightCensusReportsHelper;
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

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput{ reportDate = (DateTime)wardAdmission.StartDateTime.Value.Date, wardId = (Guid)wardAdmission.Ward.Id });

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
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{identityNumber}")]
        public async Task<HisPatientResponse> GetPatientByIdentityNumber([FromRoute] string identityNumber)
        {
            if (string.IsNullOrEmpty(identityNumber)) throw new UserFriendlyException("identityNumber can not be null.");

            var patient = await _hisPatientRepositiory.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
            if (patient == null) throw new UserFriendlyException("identityNumber can not be null.");

            return ObjectMapper.Map<HisPatientResponse>(patient);
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

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput{ reportDate = (DateTime)admission.StartDateTime.Value.Date, wardId = (Guid)admission.Ward.Id });

            var wardAdmission = await GetEntityAsync<WardAdmission>(admission.Id);

            var admissionAudit = await _hisAdmissionAuditTrailRepository.GetAudit(input.Id, admission.StartDateTime);

            if (admissionAudit != null)
            {
                await SaveOrUpdateEntityAsync<HisAdmissionAuditTrail>(admissionAudit.Id, async item =>
                {
                    item.Admission = wardAdmission;
                    item.AdmissionStatus = RefListAdmissionStatuses.admitted;
                    item.AuditTime = admission.StartDateTime.Value.Date;
                    item.Initiator = person;
                });
            }
            else
            {
                await _hisAdmissionAuditTrailRepository.CreateAudit(new HisAdmissionAuditTrail()
                {
                    Admission = wardAdmission,
                    AdmissionStatus = (RefListAdmissionStatuses?)admission.AdmissionStatus.ItemValue,
                    AuditTime = admission.StartDateTime.Value.Date,
                    Initiator = person
                });
            }

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

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput{ reportDate = (DateTime)admission.StartDateTime.Value.Date, wardId = (Guid)admission.Ward.Id });

            var wardAdmission = await GetEntityAsync<WardAdmission>(admission.Id);
            var admissionAudit = await _hisAdmissionAuditTrailRepository.GetAudit(wardAdmission.Id, admission.StartDateTime);

            if (admissionAudit != null)
            {
                await SaveOrUpdateEntityAsync<HisAdmissionAuditTrail>(admissionAudit.Id, async item =>
                {
                    item.Admission = wardAdmission;
                    item.AdmissionStatus = (RefListAdmissionStatuses?)admission.AdmissionStatus.ItemValue;
                    item.AuditTime = admission.StartDateTime.Value.Date;
                    item.Initiator = person;
                });
            }
            else
            {
                await _hisAdmissionAuditTrailRepository.CreateAudit(new HisAdmissionAuditTrail()
                {
                    Admission = wardAdmission,
                    AdmissionStatus = (RefListAdmissionStatuses?)admission.AdmissionStatus.ItemValue,
                    AuditTime = admission.StartDateTime.Value.Date,
                    Initiator = person
                });
            }

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

            var admissionResponse = await _admissionCrudHelper.SeparatePatientAsync(input, person);

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput{ reportDate = (DateTime)admissionResponse.StartDateTime.Value.Date, wardId = (Guid)admissionResponse.Ward.Id });

            await _hisWardMidnightCensusReportsHelper.CreateAdmissionAuditTrailAsync(new HisAdmissionAuditTrailInput()
            {
                Admission = input.Id,
                AdmissionStatus = RefListAdmissionStatuses.separated,
                AuditTime = admissionResponse.SeparationDate.Value.Date,
                Initiator = person.Id,
                UserId = person.User.Id
            });

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
            if (!await _hisAdmissPermissionChecker.IsApproverLevel1(await GetCurrentPersonAsync()))
            {
                throw new UserFriendlyException("The logged user is not a level 1 approver");
            }

            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            var separation = await _admissionCrudHelper.UndoSeparation(admission, person);

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput{ reportDate = (DateTime)separation.StartDateTime.Value.Date, wardId = (Guid)separation.Ward.Id });

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
