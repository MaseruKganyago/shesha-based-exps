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
using Boxfusion.Health.His.Admissions.Authorization;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Helpers.Dtos;

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
        private readonly IHisWardMidnightCensusReportsHelper _hisWardMidnightCensusReportsHelper;
        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
        private readonly IHisAdmissionAuditTrailService _hisAdmissionAuditTrailRepository;
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HisWard, Guid> _wardRepositiory;
        private readonly IHisAdmissPermissionChecker _hisAdmissPermissionChecker;

        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly ISessionDataProvider _sessionDataProvider;
        private readonly IWardCrudHelper _wardCrudHelper;

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
        /// <param name="sessionDataProvider"></param>
        /// <param name="wardCrudHelper"></param>
        public TempAdmissionsAppService(
            IRepository<WardAdmission, Guid> wardAdmissionRepository,
            IAdmissionCrudHelper admissionCrudHelper,
            IRepository<HisPatient, Guid> hisPatientRepositiory,
            IRepository<HisWard, Guid> wardRepositiory,
            IHisWardMidnightCensusReportsHelper hisWardMidnightCensusReportsHelper,
            IHisAdmissionAuditTrailService hisAdmissionAuditTrailRepository,
            IHisAdmissPermissionChecker hisAdmissPermissionChecker,
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport,
            ISessionDataProvider sessionDataProvider,
            IWardCrudHelper wardCrudHelper
            )
        {
            _admissionCrudHelper = admissionCrudHelper;
            _hisPatientRepositiory = hisPatientRepositiory;
            _wardAdmissionRepositiory = wardAdmissionRepository;
            _wardRepositiory = wardRepositiory;
            _hisWardMidnightCensusReportsHelper = hisWardMidnightCensusReportsHelper;
            _hisAdmissionAuditTrailRepository = hisAdmissionAuditTrailRepository;
            _hisAdmissPermissionChecker = hisAdmissPermissionChecker;
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _sessionDataProvider = sessionDataProvider;
            _wardCrudHelper = wardCrudHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("DailyReport")]
        [AbpAuthorize(PermissionNames.ReportsAndStats)]
        public async Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _wardCrudHelper.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital)
            {
                throw new UserFriendlyException("The Current User is not assigned to this hospital");
            }

            var isPersonAssignedToWard = await _wardCrudHelper.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard)
            {
                throw new UserFriendlyException("The Current User is not assigned to this ward");
            }

            var ward = await GetEntityAsync<HisWard>(input.WardId);
            var results = new WardMidnightCensusReport();
            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate && r.ReportType == His.Domain.Domain.Enums.RefListReportType.Daily);


            if (entity == null) //Create the report since it doesn't exist
            {
                //Calculate on the fly
                var inputObj = new TodaysAdmissionInput()
                {
                    ReportDate = input.ReportDate,
                    WardId = input.WardId,
                };

                var todaysAdmissions = await _sessionDataProvider.GetTodaysAdmission(inputObj);
                var midnightCounts = await _sessionDataProvider.GetMidnightCount(inputObj);
                var dayPatients = await _sessionDataProvider.GetDayPatients(inputObj);
                int todaysAdmission = 0;
                int midnightCount = 0;
                int dayPatient = 0;


                if (dayPatients.Any() && midnightCounts.Any() && todaysAdmissions.Any())
                {
                    todaysAdmission = (int)todaysAdmissions[0].TodaysAdmission;
                    midnightCount = (int)midnightCounts[0].MidnightCount;
                    dayPatient = (int)dayPatients[0].DayPatients;
                }

                var calculatedReport = await _sessionDataProvider.GetDailyStats(
                    new WardCensusInput2()
                    {
                        ReportDate = input.ReportDate,
                        WardId = input.WardId,
                        dayPatient = dayPatient,
                        midnightCount = midnightCount,
                        todaysAdmission = todaysAdmission,
                    });

                if (!calculatedReport.Any())
                {
                    results = new WardMidnightCensusReport()
                    {
                        ReportDate = input.ReportDate,
                        TotalBedAvailability = ward.NumberOfBeds,
                        NumBedsInWard = ward.NumberOfBeds
                    };
                }
                else
                {
                    var dailyStat = calculatedReport[0];

                    results = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(null, async (item) =>
                    {
                        ObjectMapper.Map(dailyStat, item);
                        item.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.Inprogress;
                        item.BedUtilisation = (double?)dailyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay;
                        item.ReportType = His.Domain.Domain.Enums.RefListReportType.Daily;
                        item.ReportDate = input.ReportDate;
                        item.Ward = ward;
                        item.TodaysAdmission = dailyStat.TodaysAdmission;
                    });
                    return ObjectMapper.Map<WardMidnightCensusReportResponse>(results);
                }
            }

            if (results.ApprovalStatus != His.Domain.Domain.Enums.RefListApprovalStatuses.approved)
            {
                //Calculate on the fly
                var inputObj = new TodaysAdmissionInput()
                {
                    ReportDate = input.ReportDate,
                    WardId = input.WardId,
                };

                var todaysAdmissions = await _sessionDataProvider.GetTodaysAdmission(inputObj);
                var midnightCounts = await _sessionDataProvider.GetMidnightCount(inputObj);
                var dayPatients = await _sessionDataProvider.GetDayPatients(inputObj);
                int todaysAdmission = 0;
                int midnightCount = 0;
                int dayPatient = 0;


                if (dayPatients.Any() && midnightCounts.Any() && todaysAdmissions.Any())
                {
                    todaysAdmission = (int)todaysAdmissions[0].TodaysAdmission;
                    midnightCount = (int)midnightCounts[0].MidnightCount;
                    dayPatient = (int)dayPatients[0].DayPatients;
                }

                var calculatedReport = await _sessionDataProvider.GetDailyStats(
                    new WardCensusInput2()
                    {
                        ReportDate = input.ReportDate,
                        WardId = input.WardId,
                        dayPatient = dayPatient,
                        midnightCount = midnightCount,
                        todaysAdmission = todaysAdmission,
                    });

                if (!calculatedReport.Any())
                {
                    results = new WardMidnightCensusReport()
                    {
                        ReportDate = input.ReportDate,
                        TotalBedAvailability = ward.NumberOfBeds,
                        NumBedsInWard = ward.NumberOfBeds
                    };
                }
                else
                {
                    var dailyStat = calculatedReport[0];

                    results = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(entity.Id, async item =>
                    {
                        item.ReportDate = input.ReportDate;
                        item.MidnightCount = dailyStat.MidnightCount;
                        item.TotalAdmittedPatients = dailyStat.TotalAdmittedPatients;
                        item.TotalSeparatedPatients = dailyStat.TotalSeparatedPatients;
                        item.TotalBedAvailability = dailyStat.TotalBedAvailability;
                        item.NumBedsInWard = dailyStat.TotalBedInWard;
                        item.BedUtilisation = (double?)dailyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay;
                        item.AverageBedAvailability = (float?)dailyStat.AverageLengthOfStay;
                        item.TodaysAdmission = dailyStat.TodaysAdmission;
                        item.ApprovalStatus = entity.ApprovalStatus;
                        item.ApprovalTime = entity.ApprovalTime;
                        item.ApprovalTime2 = entity.ApprovalTime2;
                        item.ApprovedBy = entity.ApprovedBy;
                        item.ApprovedBy2 = entity.ApprovedBy2;
                        item.RejectedBy = entity.RejectedBy;
                        item.RejectionComments = entity.RejectionComments;
                        item.ReportType = entity.ReportType;
                        item.Ward = entity.Ward;
                    });
                }
            }

            return ObjectMapper.Map<WardMidnightCensusReportResponse>(results);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("MonthlyReport")]
        public async Task<WardMidnightCensusReportResponse> GetWardMonthlyReport(WardCensusInput input)
        {
            var ward = await GetEntityAsync<HisWard>(input.WardId);

            var entity = await _wardMidnightCensusReport.
                FirstOrDefaultAsync(
                    r => r.Ward == ward && r.ReportDate.Value.Year == input.ReportDate.Value.Year && r.ReportDate.Value.Month == input.ReportDate.Value.Month && r.ReportType == His.Domain.Domain.Enums.RefListReportType.Monthly);

            if (entity == null)
            {
                var calculatedReport = await _sessionDataProvider.GetMonthlyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
                if (calculatedReport.Any())
                {
                    var monthlyStat = calculatedReport[0];

                    entity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(null, async (item) =>
                    {
                        item.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.Inprogress;
                        item.BedUtilisation = (double?)monthlyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)monthlyStat.AverageLengthOfStay;
                        item.ReportType = His.Domain.Domain.Enums.RefListReportType.Monthly;
                        item.ReportDate = input.ReportDate;
                        item.Ward = ward;
                        item.AverageBedAvailability = (float?)monthlyStat.AverageBedAvailability;
                        item.NumBedsInWard = monthlyStat.NumBedsInWard;
                        item.TotalBedAvailability = monthlyStat.TotalBedAvailability;
                        item.TotalAdmissions = (int?)monthlyStat.TotalAdmissions;
                        item.TotalSeparations = (int?)monthlyStat.TotalSeparations;
                    });
                }
                return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
            }
            else
            {
                var calculatedReport = await _sessionDataProvider.GetMonthlyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
                if (calculatedReport.Any())
                {
                    var monthlyStat = calculatedReport[0];

                    var resultsEntity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(entity.Id, async (item) =>
                    {
                        item.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.Inprogress;
                        item.BedUtilisation = (double?)monthlyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)monthlyStat.AverageLengthOfStay;
                        item.ReportType = His.Domain.Domain.Enums.RefListReportType.Monthly;
                        item.ReportDate = input.ReportDate;
                        item.Ward = ward;
                        item.AverageBedAvailability = (float?)monthlyStat.AverageBedAvailability;
                        item.NumBedsInWard = ward.NumberOfBeds;
                        item.TotalBedAvailability = monthlyStat.TotalBedAvailability;
                        item.TotalAdmissions = (int?)monthlyStat.TotalAdmissions;
                        item.TotalSeparations = (int?)monthlyStat.TotalSeparations;
                    });
                    return ObjectMapper.Map<WardMidnightCensusReportResponse>(resultsEntity);
                }
                return ObjectMapper.Map<WardMidnightCensusReportResponse>(null);
            }
        }
        /// <summary>
        /// Used to reject the report
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Reject")]
        [AbpAuthorize(PermissionNames.DisapproveReport)]
        public async Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _wardCrudHelper.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital)
            {
                throw new UserFriendlyException("The Current User is not assigned to this hospital");
            }

            var isPersonAssignedToWard = await _wardCrudHelper.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard)
            {
                throw new UserFriendlyException("The Current User is not assigned to this ward");
            }

            var ward = await GetEntityAsync<HisWard>(input.WardId);

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingApproval || entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingFinalApproval)
            {
                entity.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.Rejected;
                entity.RejectionComments = input.RejectionReason;
                entity.RejectedBy = await GetCurrentPersonAsync() as PersonFhirBase;

                await _wardMidnightCensusReport.UpdateAsync(entity);
            }
            else
            {
                throw new UserFriendlyException("Cannot reject report since it is not awaiting approaval");
            }

            return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("SubmitForApproval")]
        [AbpAuthorize(PermissionNames.SubmitsReportsForApproval)]
        public async Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _wardCrudHelper.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital) throw new UserFriendlyException("The Current User is not assigned to this hospital");

            var isPersonAssignedToWard = await _wardCrudHelper.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard) throw new UserFriendlyException("The Current User is not assigned to this ward");

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);
            //Check Midnight for the day.

            if (entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.Inprogress || entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.Rejected)
            {
                if (entity.Ward.MidnightCensusApprovalModel == His.Domain.Domain.Enums.RefListMidnightCensusApprovalModel.SingleApprover)
                {
                    entity.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingFinalApproval;
                }

                if (entity.Ward.MidnightCensusApprovalModel == His.Domain.Domain.Enums.RefListMidnightCensusApprovalModel.TwoApprover)
                {
                    entity.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingApproval;
                }

                await _wardMidnightCensusReport.UpdateAsync(entity);
            }
            else
            {
                throw new UserFriendlyException("Cannot submit report for approaval since it is not in-prograss or previously rejected");
            }

            return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
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

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput() { reportDate = (DateTime)admission.StartDateTime.Value.Date, wardId = (Guid)admission.Ward.Id });

            var wardAdmission = await GetEntityAsync<WardAdmission>(admission.Id);

            var admissionAudit = await _hisAdmissionAuditTrailRepository.GetAudit(input.Id ,admission.StartDateTime);

            if(admissionAudit != null)
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

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput() { reportDate = (DateTime)admission.StartDateTime.Value.Date, wardId = (Guid)admission.Ward.Id });

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

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput() { reportDate = (DateTime)admissionResponse.StartDateTime.Value.Date, wardId = (Guid)admissionResponse.Ward.Id });

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

            await _hisWardMidnightCensusReportsHelper.ResertReportAsync(new ResertReportInput() { reportDate = (DateTime)separation.StartDateTime.Value.Date, wardId = (Guid)separation.Ward.Id });

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
