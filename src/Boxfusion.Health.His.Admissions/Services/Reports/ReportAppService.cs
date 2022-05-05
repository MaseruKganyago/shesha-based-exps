using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Patients;
using Boxfusion.Health.His.Admissions.Application.Domain;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.UI;
using Boxfusion.Health.His.Admissions.Application.Services.Reports.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Domain.Helpers;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Authorization;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisAdmis/[controller]")]
    public class ReportAppService : CdmAppServiceBase,  IReportAppService
    {
        private readonly IReportHelper _reportHelper;
        private readonly IHisWardMidnightCensusReportsHelper _hisWardMidnightCensusReportsHelper;
        private readonly ISessionDataProvider _sessionDataProvider;
        private readonly IUserAccessRightService _userAccessRightService;
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportHelper"></param>
        /// <param name="hisWardMidnightCensusReportsHelper"></param>
        /// <param name="sessionDataProvider"></param>
        /// <param name="userAccessRightService"></param>
        /// <param name="wardMidnightCensusReport"></param>
        public ReportAppService(
            IReportHelper reportHelper, 
            IHisWardMidnightCensusReportsHelper hisWardMidnightCensusReportsHelper, 
            ISessionDataProvider sessionDataProvider, 
            IUserAccessRightService userAccessRightService, 
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport)
        {
            _reportHelper = reportHelper;
            _hisWardMidnightCensusReportsHelper = hisWardMidnightCensusReportsHelper;
            _sessionDataProvider = sessionDataProvider;
            _userAccessRightService = userAccessRightService;
            _wardMidnightCensusReport = wardMidnightCensusReport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        [HttpGet, Route("Reports")]
        public async Task<List<ReportResponseDto>> GetReport(RefListReportTypes reportType, Guid wardId, DateTime filterDate)
        {
            var reports = await _reportHelper.GetReportAsync(reportType, wardId, filterDate);

            return reports;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet, Route("Dashboards")]
        public async Task<List<DashboardResponseDto>> GetDashboard(Guid? hospitalId)
        {
            var dashboards = await _reportHelper.GetDashboardAsync(hospitalId);

            return dashboards;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("ApproveLevel1")]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel1(WardCensusInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _userAccessRightService.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital)
            {
                throw new UserFriendlyException("The Current User is not assigned to this hospital");
            }

            var isPersonAssignedToWard = await _userAccessRightService.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard)
            {
                throw new UserFriendlyException("The Current User is not assigned to this ward");
            }

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);

            if (entity.ApprovalStatus == RefListApprovalStatuses.awaitingApproval && entity.Ward.MidnightCensusApprovalModel == RefListMidnightCensusApprovalModel.TwoApprover)
            {
                entity.ApprovalStatus = RefListApprovalStatuses.awaitingFinalApproval;
                entity.ApprovedBy = await GetCurrentPersonAsync() as PersonFhirBase;
                entity.ApprovalTime = DateTime.Now;

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
        [HttpPost, Route("ApproveLevel2")]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel2(WardCensusInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _userAccessRightService.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital)
            {
                throw new UserFriendlyException("The Current User is not assigned to this hospital");
            }

            var isPersonAssignedToWard = await _userAccessRightService.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard)
            {
                throw new UserFriendlyException("The Current User is not assigned to this ward");
            }

            var ward = await GetEntityAsync<HisWard>(input.WardId);

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (entity.ApprovalStatus == RefListApprovalStatuses.awaitingFinalApproval)
            {
                entity.ApprovalStatus = RefListApprovalStatuses.approved;
                entity.ApprovedBy2 = await GetCurrentPersonAsync() as PersonFhirBase;
                entity.ApprovalTime2 = DateTime.Now;

                //Todo: Calculate stats for the day and save to the WardReport table

                var inputObj = new TodaysAdmissionInput
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
                    throw new UserFriendlyException("No records found for the ward and date specified");
                }
                var dailyStat = calculatedReport[0];

                entity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(entity.Id, async (item) =>
                {
                    ObjectMapper.Map(dailyStat, item);
                    item.ApprovalStatus = RefListApprovalStatuses.approved;
                    item.BedUtilisation = (double?)dailyStat.BedUtilisation;
                    item.AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay;
                    item.ReportType = RefListReportType.Daily;
                    item.ReportDate = input.ReportDate;
                    item.Ward = ward;
                });
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
        [HttpGet, Route("DailyReport")]
        public async Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _userAccessRightService.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital)
            {
                throw new UserFriendlyException("The Current User is not assigned to this hospital");
            }

            var isPersonAssignedToWard = await _userAccessRightService.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard)
            {
                throw new UserFriendlyException("The Current User is not assigned to this ward");
            }

            var ward = await GetEntityAsync<HisWard>(input.WardId);
            var results = new WardMidnightCensusReport();
            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate && r.ReportType == RefListReportType.Daily);


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
                        item.ApprovalStatus = RefListApprovalStatuses.Inprogress;
                        item.BedUtilisation = (double?)dailyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay;
                        item.ReportType = RefListReportType.Daily;
                        item.ReportDate = input.ReportDate;
                        item.Ward = ward;
                        item.TodaysAdmission = dailyStat.TodaysAdmission;
                    });
                    return ObjectMapper.Map<WardMidnightCensusReportResponse>(results);
                }
            }

            if (results.ApprovalStatus != RefListApprovalStatuses.approved)
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
                    r => r.Ward == ward && r.ReportDate.Value.Year == input.ReportDate.Value.Year && r.ReportDate.Value.Month == input.ReportDate.Value.Month && r.ReportType == RefListReportType.Monthly);

            if (entity == null)
            {
                var inputObj = new TodaysAdmissionInput()
                {
                    ReportDate = input.ReportDate,
                    WardId = input.WardId,
                };
                var totalAdmissions = await _sessionDataProvider.GetMonthlyTotalAdmissions(inputObj);
                int TotalAdmissions = 0;

                if (totalAdmissions.Any())
                {
                    TotalAdmissions = (int)totalAdmissions[0].TotalAdmissions;
                }

                var calculatedReport = await _sessionDataProvider.GetMonthlyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId, TotalMonthlyAdmissions = TotalAdmissions });
                if (calculatedReport.Any())
                {
                    var monthlyStat = calculatedReport[0];

                    entity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(null, async (item) =>
                    {
                        item.ApprovalStatus = RefListApprovalStatuses.Inprogress;
                        item.BedUtilisation = (double?)monthlyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)monthlyStat.AverageLengthOfStay;
                        item.ReportType = RefListReportType.Monthly;
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
                var inputObj = new TodaysAdmissionInput()
                {
                    ReportDate = input.ReportDate,
                    WardId = input.WardId,
                };
                var totalAdmissions = await _sessionDataProvider.GetMonthlyTotalAdmissions(inputObj);
                int TotalAdmissions = 0;

                if (totalAdmissions.Any())
                {
                    TotalAdmissions = (int)totalAdmissions[0].TotalAdmissions;
                }

                var calculatedReport = await _sessionDataProvider.GetMonthlyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId, TotalMonthlyAdmissions = TotalAdmissions });
                if (calculatedReport.Any())
                {
                    var monthlyStat = calculatedReport[0];

                    var resultsEntity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(entity.Id, async (item) =>
                    {
                        item.ApprovalStatus = RefListApprovalStatuses.Inprogress;
                        item.BedUtilisation = (double?)monthlyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)monthlyStat.AverageLengthOfStay;
                        item.ReportType = RefListReportType.Monthly;
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
        public async Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _userAccessRightService.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital)
            {
                throw new UserFriendlyException("The Current User is not assigned to this hospital");
            }

            var isPersonAssignedToWard = await _userAccessRightService.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard)
            {
                throw new UserFriendlyException("The Current User is not assigned to this ward");
            }

            var ward = await GetEntityAsync<HisWard>(input.WardId);

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (entity.ApprovalStatus == RefListApprovalStatuses.awaitingApproval || entity.ApprovalStatus == RefListApprovalStatuses.awaitingFinalApproval)
            {
                entity.ApprovalStatus = RefListApprovalStatuses.Rejected;
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
        public async Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input)
        {
            var currentPerson = await GetCurrentPersonAsync();
            var isPersonAssignedToHospital = await _userAccessRightService.IsPersonAssignedToHospital(input.WardId, currentPerson);
            if (!isPersonAssignedToHospital) throw new UserFriendlyException("The Current User is not assigned to this hospital");

            var isPersonAssignedToWard = await _userAccessRightService.IsPersonAssignedToWard(input.WardId, currentPerson);
            if (!isPersonAssignedToWard) throw new UserFriendlyException("The Current User is not assigned to this ward");

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);
            //Check Midnight for the day.

            if (entity.ApprovalStatus == RefListApprovalStatuses.Inprogress || entity.ApprovalStatus == RefListApprovalStatuses.Rejected)
            {
                if (entity.Ward.MidnightCensusApprovalModel == RefListMidnightCensusApprovalModel.SingleApprover)
                {
                    entity.ApprovalStatus = RefListApprovalStatuses.awaitingFinalApproval;
                }

                if (entity.Ward.MidnightCensusApprovalModel == RefListMidnightCensusApprovalModel.TwoApprover)
                {
                    entity.ApprovalStatus = RefListApprovalStatuses.awaitingApproval;
                }

                await _wardMidnightCensusReport.UpdateAsync(entity);
            }
            else
            {
                throw new UserFriendlyException("Cannot submit report for approaval since it is not in-prograss or previously rejected");
            }

            return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
        }
    }
}
