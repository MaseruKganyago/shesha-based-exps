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
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports.Dtos;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisAdmis/[controller]")]
    public class ReportAppService : CdmAppServiceBase, IReportAppService
    {
        private readonly IHisWardMidnightCensusReportsHelper _hisWardMidnightCensusReportsHelper;
        private readonly WardMidnightCensusReportManager _wardMidnightCensusReportManager;
        private readonly IUserAccessRightService _userAccessRightService;
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hisWardMidnightCensusReportsHelper"></param>
        /// <param name="wardMidnightCensusReportManager"></param>
        /// <param name="userAccessRightService"></param>
        /// <param name="wardMidnightCensusReport"></param>
        public ReportAppService(
            IHisWardMidnightCensusReportsHelper hisWardMidnightCensusReportsHelper,
             WardMidnightCensusReportManager wardMidnightCensusReportManager,
            IUserAccessRightService userAccessRightService,
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport)
        {
            _hisWardMidnightCensusReportsHelper = hisWardMidnightCensusReportsHelper;
            _hisWardMidnightCensusReportsHelper = hisWardMidnightCensusReportsHelper;
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
            return ObjectMapper.Map<List<ReportResponseDto>>(await _wardMidnightCensusReportManager.GetReportAsync(reportType, wardId, filterDate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet, Route("Dashboards")]
        public async Task<List<DashboardResponseDto>> GetDashboard(Guid? hospitalId)
        {
            return ObjectMapper.Map<List<DashboardResponseDto>>(await _wardMidnightCensusReportManager.GetDashboardAsync(hospitalId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("ApproveLevel1")]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel1(WardCensusInput input)
        {
            await validateUserAssignedToWard(input);

            var censusReport = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);
            if (censusReport.ApprovalStatus != RefListApprovalStatuses.awaitingApproval
                || censusReport.Ward.MidnightCensusApprovalModel != RefListMidnightCensusApprovalModel.TwoApprover)
                throw new UserFriendlyException("Cannot reject report since it is not awaiting approval");

            
            censusReport.ApprovalStatus = RefListApprovalStatuses.awaitingFinalApproval;
            censusReport.ApprovedBy = await GetCurrentPersonAsync() as PersonFhirBase;
            censusReport.ApprovalTime = DateTime.Now;

            await _wardMidnightCensusReport.UpdateAsync(censusReport);

            return ObjectMapper.Map<WardMidnightCensusReportResponse>(censusReport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("ApproveLevel2")]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel2(WardCensusInput input)
        {
            await validateUserAssignedToWard(input);

            var ward = await GetEntityAsync<HisWard>(input.WardId);

            var censusReport = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (censusReport.ApprovalStatus != RefListApprovalStatuses.awaitingFinalApproval)
                throw new UserFriendlyException("Cannot approve report since it is not awaiting final approval");
            
                censusReport.ApprovalStatus = RefListApprovalStatuses.approved;
                censusReport.ApprovedBy2 = await GetCurrentPersonAsync() as PersonFhirBase;
                censusReport.ApprovalTime2 = DateTime.Now;

                //Calculate stats for the day and save to the WardReport table
                var dailyStats = await CalculateDailyStats(input);

                censusReport = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(censusReport.Id, async (item) =>
                {
                    item.ApprovalStatus = RefListApprovalStatuses.approved;
                    item.BedUtilisation = (double?)dailyStats.BedUtilisation;
                    item.AverageLengthofStay = (float?)dailyStats.AverageLengthOfStay;
                    item.ReportType = RefListReportType.Daily;
                    item.ReportDate = input.ReportDate;
                    item.Ward = ward;
                });

            return ObjectMapper.Map<WardMidnightCensusReportResponse>(censusReport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("DailyReport")]
        public async Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input)
        {
            await validateUserAssignedToWard(input);

            var ward = await GetEntityAsync<HisWard>(input.WardId);
            var results = new WardMidnightCensusReport();
            var wardMidnightCensusReport = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate && r.ReportType == RefListReportType.Daily);

            var dailyStat = await CalculateDailyStats(input);

            if (wardMidnightCensusReport == null) //Create the report since it doesn't exist
            {
                if (dailyStat == null)
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
                if (dailyStat == null)
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
                    results = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(wardMidnightCensusReport.Id, async item =>
                    {
                        item.ReportDate = input.ReportDate;
                        item.MidnightCount = dailyStat.MidnightCount;
                        item.TotalAdmittedPatients = dailyStat.TotalAdmittedPatients;
                        item.TotalSeparatedPatients = dailyStat.TotalSeparatedPatients;
                        item.TotalBedAvailability = dailyStat.TotalBedAvailability;
                        item.NumBedsInWard = dailyStat.NumBedsInWard;
                        item.BedUtilisation = (double?)dailyStat.BedUtilisation;
                        item.AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay;
                        item.TodaysAdmission = dailyStat.TodaysAdmission;
                        item.ApprovalStatus = wardMidnightCensusReport.ApprovalStatus;
                        item.ApprovalTime = wardMidnightCensusReport.ApprovalTime;
                        item.ApprovalTime2 = wardMidnightCensusReport.ApprovalTime2;
                        item.ApprovedBy = wardMidnightCensusReport.ApprovedBy;
                        item.ApprovedBy2 = wardMidnightCensusReport.ApprovedBy2;
                        item.RejectedBy = wardMidnightCensusReport.RejectedBy;
                        item.RejectionComments = wardMidnightCensusReport.RejectionComments;
                        item.ReportType = wardMidnightCensusReport.ReportType;
                        item.Ward = wardMidnightCensusReport.Ward;
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

            var wardMidnightCunsus = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate.Value.Year == input.ReportDate.Value.Year && r.ReportDate.Value.Month == input.ReportDate.Value.Month && r.ReportType == RefListReportType.Monthly);

            var inputObj = new TodaysAdmissionInput()
            {
                ReportDate = input.ReportDate,
                WardId = input.WardId,
            };

            var TotalAdmissions = await _wardMidnightCensusReportManager.GetMonthlyTotalAdmissions(inputObj);  
            var monthlyStat = await _wardMidnightCensusReportManager.GetMonthlyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId, TotalMonthlyAdmissions = TotalAdmissions });

            if (monthlyStat != null)
            {
                var wardMidnightCensusReport = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(null, async (item) =>
                {
                    item.ApprovalStatus = RefListApprovalStatuses.Inprogress;
                    item.ReportType = RefListReportType.Monthly;
                    item.ReportDate = input.ReportDate;
                    item.Ward = ward;
                    ObjectMapper.Map(monthlyStat, item);
                });

                if (wardMidnightCunsus == null)
                {
                    return ObjectMapper.Map<WardMidnightCensusReportResponse>(wardMidnightCensusReport);
                }
                else
                {
                    var resultsEntity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(wardMidnightCunsus.Id, async (item) =>
                    {
                        ObjectMapper.Map(wardMidnightCensusReport, item);
                    });
                    return ObjectMapper.Map<WardMidnightCensusReportResponse>(resultsEntity);
                }
            }
            return ObjectMapper.Map<WardMidnightCensusReportResponse>(null);
        }
        /// <summary>
        /// Used to reject the report
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Reject")]
        public async Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input)
        {
            await validateUserAssignedToWard(input);

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
            await validateUserAssignedToWard(input);

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);
            //Check Midnight for the day.

            if (entity.ApprovalStatus != RefListApprovalStatuses.Inprogress || entity.ApprovalStatus != RefListApprovalStatuses.Rejected)
                throw new UserFriendlyException("Cannot submit report for approaval since it is not in-prograss or previously rejected");
           
                if (entity.Ward.MidnightCensusApprovalModel == RefListMidnightCensusApprovalModel.SingleApprover)
                {
                    entity.ApprovalStatus = RefListApprovalStatuses.awaitingFinalApproval;
                }

                if (entity.Ward.MidnightCensusApprovalModel == RefListMidnightCensusApprovalModel.TwoApprover)
                {
                    entity.ApprovalStatus = RefListApprovalStatuses.awaitingApproval;
                }

                await _wardMidnightCensusReport.UpdateAsync(entity);
          
            return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
        }


        private async Task<WardCensusDailyStats> CalculateDailyStats(WardCensusInput input)
        {
            var inputObj = new TodaysAdmissionInput
            {
                ReportDate = input.ReportDate,
                WardId = input.WardId,
            };

            var calculatedReport = await _wardMidnightCensusReportManager.GetDailyStats(
                new WardCensusInput2()
                {
                    ReportDate = input.ReportDate,
                    WardId = input.WardId,
                    dayPatient = await _wardMidnightCensusReportManager.GetDayPatients(inputObj),
                    midnightCount = await _wardMidnightCensusReportManager.GetMidnightCount(inputObj),
                    todaysAdmission = await _wardMidnightCensusReportManager.GetTodaysAdmission(inputObj),
                });

            return calculatedReport;
        }

        private async Task validateUserAssignedToWard(WardCensusInput input)
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
        }
    }
}
