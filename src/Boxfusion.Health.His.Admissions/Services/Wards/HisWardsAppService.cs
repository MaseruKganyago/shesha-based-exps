using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Helpers;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/admissions/[controller]")]
    public class HisWardsAppService : SheshaAppServiceBase, IHisWardsAppService
    {
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly ISessionDataProvider _sessionDataProvider;

        public HisWardsAppService(IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport, ISessionDataProvider sessionDataProvider)
        {
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _sessionDataProvider = sessionDataProvider;
        }

        [HttpGet, Route("ApproveLevel1")]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel1(WardCensusInput input)
        {
            var approvalModel = await _sessionDataProvider.GetApprovalModels(input.WardId);
            if (!approvalModel.Any()) throw new UserFriendlyException("The spacified ward doesn't have MidnightCensusApprovalModel");
            var approval = approvalModel[0];

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);

            if (entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingApproval && approval.His_MidnightCensusApprovalModelLkp == (float)His.Domain.Domain.Enums.RefListMidnightCensusApprovalModel.TwoApprover)
            {
                entity.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingFinalApproval;
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
        [HttpGet, Route("ApproveLevel2")]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel2(WardCensusInput input)
        {
            var ward = await GetEntityAsync<Ward>(input.WardId);

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingFinalApproval)
            {
                entity.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.approved;
                entity.ApprovedBy2 = await GetCurrentPersonAsync() as PersonFhirBase;
                entity.ApprovalTime2 = DateTime.Now;

                //Todo: Calculate stats for the day and save to the WardReport table
                var calculatedReport = await _sessionDataProvider.GetDailyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
                if (!calculatedReport.Any())
                {
                    throw new UserFriendlyException("No records found for the ward and date specified");
                }
                var dailyStat = calculatedReport[0];

                entity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(entity.Id, async (item) =>
                {
                    ObjectMapper.Map(dailyStat, item);
                    item.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.Inprogress;
                    item.BedUtilisation = (double?)dailyStat.BedUtilisation;
                    item.AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay;
                    item.ReportType = His.Domain.Domain.Enums.RefListReportType.Daily;
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
        /// <returns></returns>
        [HttpGet, Route("AssignedWards")]
        public async Task<List<WardResponse>> GetAssignedWards()
        {
            var currentPerson = await GetCurrentPersonAsync();
            var appointmentService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<WardRoleAppointedPerson, Guid>>();
            var wards = await appointmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Ward).ToListAsync();

            return ObjectMapper.Map<List<WardResponse>>(wards);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("DailyReport")]
        public async Task<WardMidnightCensusReportResponse> GetWardDailyReport(WardCensusInput input)
        {
            var ward = await GetEntityAsync<Ward>(input.WardId);

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (entity == null) //Create the report since it doesn't exist
            {
                //Calculate on the fly
                var calculatedReport = await _sessionDataProvider.GetDailyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
                if (!calculatedReport.Any())
                {
                    throw new UserFriendlyException("No records found for the ward and date specified");
                }
                var dailyStat = calculatedReport[0];

                entity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(null, async (item) =>
                {
                    ObjectMapper.Map(dailyStat, item);
                    item.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.Inprogress;
                    item.BedUtilisation = (double?)dailyStat.BedUtilisation;
                    item.AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay;
                    item.ReportType = His.Domain.Domain.Enums.RefListReportType.Daily;
                    item.ReportDate = input.ReportDate;
                    item.Ward = ward;
                });
                return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
            }

            if (entity.ApprovalStatus != His.Domain.Domain.Enums.RefListApprovalStatuses.approved)
            {
                //Calculate on the fly
                var calculatedReport = await _sessionDataProvider.GetDailyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
                if (!calculatedReport.Any())
                {
                    throw new UserFriendlyException("No records found for the ward and date specified");
                }
                var dailyStat = calculatedReport[0];
                entity = new WardMidnightCensusReport()
                {
                    ReportDate = input.ReportDate,
                    MidnightCount = dailyStat.MidnightCount,//Owe Migration
                    TotalAdmittedPatients = dailyStat.TotalAdmittedPatients,// owe
                    TotalSeparatedPatients = dailyStat.TotalSeparatedPatients,//owe
                    TotalBedAvailability = dailyStat.TotalBedAvailability,//owe
                    NumBedsInWard = dailyStat.TotalBedInWard, //owe and mappings
                    BedUtilisation = (double?)dailyStat.BedUtilisation,
                    AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay,
                    AverageBedAvailability = (float?)dailyStat.AverageLengthOfStay
                };
            }
            
            return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
        }
        /// <summary>
        /// Used to reject the report
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("Reject")]
        public async Task<WardMidnightCensusReportResponse> Reject(RejectReportInput input)
        {
            var ward = await GetEntityAsync<Ward>(input.WardId);

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
        public async Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input)
        {
            var approvalModel = await _sessionDataProvider.GetApprovalModels(input.WardId);
            if(!approvalModel.Any()) throw new UserFriendlyException("The spacified ward doesn't have MidnightCensusApprovalModel");

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);
            //Check Midnight for the day.

            if (entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.Inprogress || entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.Rejected)
            {
                var approval = approvalModel[0];
                if (approval.His_MidnightCensusApprovalModelLkp == (float)His.Domain.Domain.Enums.RefListMidnightCensusApprovalModel.SingleApprover)
                {
                    entity.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingFinalApproval;
                }
                if (approval.His_MidnightCensusApprovalModelLkp == (float)His.Domain.Domain.Enums.RefListMidnightCensusApprovalModel.TwoApprover)
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
    }
}
