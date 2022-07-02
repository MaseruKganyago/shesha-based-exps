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
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Domain.Helpers;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Authorization;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports.Dtos;
using Shesha.DynamicEntities.Dtos;

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
             WardMidnightCensusReportManager wardMidnightCensusReportManager,
            IUserAccessRightService userAccessRightService,
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport)
        {
            _userAccessRightService = userAccessRightService;
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _wardMidnightCensusReportManager = wardMidnightCensusReportManager;
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
        /// Initial submission of the Census Report for approval.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("SubmitForApproval")]
        public async Task<DynamicDto<WardMidnightCensusReport, Guid>> SubmitForApproval(WardCensusQueryInput input)
        {
            await validateUserAssignedToWard(input);

            var censusReport = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);
            //Check Midnight for the day.

            if (censusReport.ApprovalStatus != RefListApprovalStatuses.Inprogress || censusReport.ApprovalStatus != RefListApprovalStatuses.Rejected)
                throw new UserFriendlyException("Cannot submit report for approaval since it is not in-prograss or previously rejected");

            // TODO: CALCULATE STATS AND SAVE & FREEZE

            if (censusReport.Ward.MidnightCensusApprovalModel == RefListMidnightCensusApprovalModel.SingleApprover)
            {
                censusReport.ApprovalStatus = RefListApprovalStatuses.awaitingFinalApproval;
            }
            else if (censusReport.Ward.MidnightCensusApprovalModel == RefListMidnightCensusApprovalModel.TwoApprover)
            {
                censusReport.ApprovalStatus = RefListApprovalStatuses.awaitingApproval;
            }

            censusReport = await _wardMidnightCensusReport.UpdateAsync(censusReport);

            return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(censusReport);  
        }

        /// <summary>
        /// Only valid if Approval Model requires Two Approvers.
        /// Provides first approval of a Two-step approval process for the Census report.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("ApproveLevel1")]
        public async Task<DynamicDto<WardMidnightCensusReport, Guid>> ApproveLevel1(WardCensusQueryInput input)
        {
            await validateUserAssignedToWard(input);

            var censusReport = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);
            if (censusReport.ApprovalStatus != RefListApprovalStatuses.awaitingApproval
                || censusReport.Ward.MidnightCensusApprovalModel != RefListMidnightCensusApprovalModel.TwoApprover)
                throw new UserFriendlyException("Cannot reject report since it is not awaiting approval");

            
            censusReport.ApprovalStatus = RefListApprovalStatuses.awaitingFinalApproval;
            censusReport.ApprovedBy = await GetCurrentPersonAsync() as PersonFhirBase;
            censusReport.ApprovalTime = DateTime.Now;

            censusReport = await _wardMidnightCensusReport.UpdateAsync(censusReport);

            return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(censusReport);
        }

        /// <summary>
        /// Final Approval of Census Report
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("ApproveLevel2")]
        public async Task<DynamicDto<WardMidnightCensusReport, Guid>> ApproveLevel2(WardCensusQueryInput input)
        {
            await validateUserAssignedToWard(input);

            var censusReport = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);

            if (censusReport.ApprovalStatus != RefListApprovalStatuses.awaitingFinalApproval)
                throw new UserFriendlyException("Cannot approve report since it is not awaiting final approval");

            censusReport.ApprovalStatus = RefListApprovalStatuses.approved;
            censusReport.ApprovedBy2 = await GetCurrentPersonAsync() as PersonFhirBase;
            censusReport.ApprovalTime2 = DateTime.Now;

            //Calculate stats for the day and save to the WardReport table
            //TODO: var dailyStats = await CalculateDailyStats(input);

            censusReport = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(censusReport.Id, async (item) =>
            {
                item.ApprovalStatus = RefListApprovalStatuses.approved;
                //item.BedUtilisation = (double?)dailyStats.BedUtilisation;
                //item.AverageLengthofStay = (float?)dailyStats.AverageLengthOfStay;
                item.ReportType = RefListReportType.Daily;
                item.ReportDate = input.ReportDate;
                item.Ward.Id = input.WardId;
            });

            return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(censusReport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("DailyReport")]
        public async Task<DynamicDto<WardMidnightCensusReport, Guid>> GetWardDailyReport(WardCensusQueryInput input)
        {
            await validateUserAssignedToWard(input);
            if (input.ReportDate == null) throw new ArgumentNullException(nameof(input.ReportDate));

            var ward = await GetEntityAsync<HisWard>(input.WardId);
            var wardMidnightCensusReport = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate && r.ReportType == RefListReportType.Daily);


            if (wardMidnightCensusReport != null 
                   && (wardMidnightCensusReport.ApprovalStatus == RefListApprovalStatuses.awaitingApproval 
                   || wardMidnightCensusReport.ApprovalStatus == RefListApprovalStatuses.awaitingFinalApproval
                   || wardMidnightCensusReport.ApprovalStatus == RefListApprovalStatuses.approved))
            {
                // Stats have previously been calculated and saved to DB
                return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(wardMidnightCensusReport);
            }

            if (wardMidnightCensusReport == null)
            {
                // Need to create the Daily Report as its has not been added to the DB yet.
                wardMidnightCensusReport = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(null, async (item) =>
                {
                    item.ApprovalStatus = RefListApprovalStatuses.Inprogress;
                    item.ReportType = RefListReportType.Daily;
                    item.ReportDate = input.ReportDate;
                    item.Ward = ward;
                });
            };

            
            var dailyStats = await _wardMidnightCensusReportManager.GetDailyStats(input.WardId, input.ReportDate.Value.Date);
            ObjectMapper.Map(dailyStats, wardMidnightCensusReport);

            return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(wardMidnightCensusReport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("MonthlyReport")]
        public async Task<DynamicDto<WardMidnightCensusReport, Guid>> GetWardMonthlyReport(WardCensusQueryInput input)
        {
            var monthlyStat = await _wardMidnightCensusReportManager.GetMonthlyStats(
                new WardCensusQueryInput() { ReportDate = input.ReportDate, WardId = input.WardId });

            if (monthlyStat == null)            
                return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(null);

            var ward = await GetEntityAsync<HisWard>(input.WardId);
            var wardMidnightCensus = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate.Value.Year == input.ReportDate.Value.Year 
                                                                                            && r.ReportDate.Value.Month == input.ReportDate.Value.Month 
                                                                                            && r.ReportType == RefListReportType.Monthly);
                        
            if(wardMidnightCensus == null)
            {
                var wardMidnightCensusReport = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(null, async (item) =>
                {
                    item.ApprovalStatus = RefListApprovalStatuses.Inprogress;
                    item.ReportType = RefListReportType.Monthly;
                    item.ReportDate = input.ReportDate;
                    item.Ward = ward;
                    ObjectMapper.Map(monthlyStat, item);
                });
                return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(wardMidnightCensusReport);
            }
            else
            {

                var resultsEntity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(wardMidnightCensus.Id, async (item) =>
                {
                    ObjectMapper.Map(monthlyStat, item);
                });
                return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(resultsEntity);
            }
        }

        /// <summary>
        /// Used to reject the report
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Reject")]
        public async Task<DynamicDto<WardMidnightCensusReport, Guid>> Reject(RejectReportInput input)
        {
            await validateUserAssignedToWard(input);

            var ward = await GetEntityAsync<HisWard>(input.WardId);

            var wardMidnightCensus = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (wardMidnightCensus.ApprovalStatus != RefListApprovalStatuses.awaitingApproval || wardMidnightCensus.ApprovalStatus != RefListApprovalStatuses.awaitingFinalApproval)
                throw new UserFriendlyException("Cannot reject report since it is not awaiting approaval");

                wardMidnightCensus.ApprovalStatus = RefListApprovalStatuses.Rejected;
                wardMidnightCensus.RejectionComments = input.RejectionReason;
                wardMidnightCensus.RejectedBy = await GetCurrentPersonAsync() as PersonFhirBase;
                wardMidnightCensus = await _wardMidnightCensusReport.UpdateAsync(wardMidnightCensus);
           
            return await MapToDynamicDtoAsync<WardMidnightCensusReport, Guid>(wardMidnightCensus);
        }

        private async Task validateUserAssignedToWard(WardCensusQueryInput input)
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
