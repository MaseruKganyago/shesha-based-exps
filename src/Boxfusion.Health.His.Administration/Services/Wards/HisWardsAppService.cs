﻿using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Admissions.Authorization;
using Boxfusion.Health.His.Admissions.Domain.Views;
using Boxfusion.Health.His.Admissions.Helpers;
using Boxfusion.Health.His.Admissions.Helpers.Dtos;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
using Boxfusion.Health.His.Admissions.Services.Wards.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Utilities;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/admissions/[controller]")]
    public class HisWardsAppService : CdmAppServiceBase, IHisWardsAppService
    {
        private readonly IRepository<WardMidnightCensusReport, Guid> _wardMidnightCensusReport;
        private readonly ISessionDataProvider _sessionDataProvider;
        private readonly IWardCrudHelper _wardCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardMidnightCensusReport"></param>
        /// <param name="sessionDataProvider"></param>
        /// <param name="wardCrudHelper"></param>
        public HisWardsAppService(
            IRepository<WardMidnightCensusReport, Guid> wardMidnightCensusReport,
            ISessionDataProvider sessionDataProvider,
            IWardCrudHelper wardCrudHelper)
        {
            _wardMidnightCensusReport = wardMidnightCensusReport;
            _sessionDataProvider = sessionDataProvider;
            _wardCrudHelper = wardCrudHelper;
        }

        /// <summary>
        /// Ward index table
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig IndexTable()
        {
            var table = new DataTableConfig<WardItems, Guid>("Wards_Index");

            table.AddProperty(e => e.Speciality, c => c.Caption("Ward Speciality"));
            table.AddProperty(e => e.Name, d => d.Caption("Ward Name"));
            table.AddProperty(e => e.Description, d => d.Caption("Ward Description"));
            table.AddProperty(e => e.NumberOfBeds, d => d.Caption("No. of Beds"));
            table.OnRequestToFilterStaticAsync = async (criteria, form) =>
            {
                var _session = Abp.Dependency.IocManager.Instance.Resolve<IAbpSession>();
                var _hisAdmissPermissionChecker = Abp.Dependency.IocManager.Instance.Resolve<IHisAdmissPermissionChecker>();
                var personService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Person, Guid>>();
                var _hospitalRoleAppointedPersonRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
                var _wardRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HisWard, Guid>>();


                var person = personService.FirstOrDefault(c => c.User.Id == _session.GetUserId());
                var hospitalId = _hospitalRoleAppointedPersonRepository.GetAll().Where(s => s.Person == person).Select(s => s.Hospital.Id).FirstOrDefault();
                var isAdmin = await _hisAdmissPermissionChecker.IsAdmin(person);

                if (!isAdmin)
                {
                    criteria.FilterClauses.Add($"ent.HospitalId = '{hospitalId}'");
                }

            };

            return table;
        }

        /// <summary>
        /// Speciality
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig SpecialityIndexTable()
        {
            var table = new DataTableConfig<SpecialityItems, Guid>("Specialities_Index");

            table.AddProperty(e => e.Speciality, c => c.Caption("Specialities"));
            table.AddProperty(e => e.NumberOfBedsInSpeciality, d => d.Caption("No. of Beds"));

            table.OnRequestToFilterStaticAsync = async (criteria, form) =>
            {
                var session = Abp.Dependency.IocManager.Instance.Resolve<IAbpSession>();
                var _hisAdmissPermissionChecker = Abp.Dependency.IocManager.Instance.Resolve<IHisAdmissPermissionChecker>();
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
        [HttpPost, Route("ApproveLevel1")]
        [AbpAuthorize(PermissionNames.ApproveReport)]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel1(WardCensusInput input)
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

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward.Id == input.WardId && r.ReportDate == input.ReportDate);

            if (entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingApproval && entity.Ward.MidnightCensusApprovalModel == His.Domain.Domain.Enums.RefListMidnightCensusApprovalModel.TwoApprover)
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
        [HttpPost, Route("ApproveLevel2")]
        [AbpAuthorize(PermissionNames.ApproveReport)]
        public async Task<WardMidnightCensusReportResponse> ApproveLevel2(WardCensusInput input)
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

            if (entity.ApprovalStatus == His.Domain.Domain.Enums.RefListApprovalStatuses.awaitingFinalApproval)
            {
                entity.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.approved;
                entity.ApprovedBy2 = await GetCurrentPersonAsync() as PersonFhirBase;
                entity.ApprovalTime2 = DateTime.Now;

                //Todo: Calculate stats for the day and save to the WardReport table

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
                    throw new UserFriendlyException("No records found for the ward and date specified");
                }
                var dailyStat = calculatedReport[0];

                entity = await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(entity.Id, async (item) =>
                {
                    ObjectMapper.Map(dailyStat, item);
                    item.ApprovalStatus = His.Domain.Domain.Enums.RefListApprovalStatuses.approved;
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
        [HttpGet, Route("AssignedHospitals")]
        public async Task<List<HospitalResponse>> GetAssignedHospitals()
        {
            var currentPerson = await GetCurrentPersonAsync();
            var appointmentService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
            var hisAdmissPermissionChecker = Abp.Dependency.IocManager.Instance.Resolve<IHisAdmissPermissionChecker>();
            var hospitals = new List<HisHospital>();

            if (!await hisAdmissPermissionChecker.IsAdmin(currentPerson))
            {
                hospitals = await appointmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Hospital).ToListAsync();
            }
            else
            {
                var hospitalService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HisHospital, Guid>>();
                hospitals = await hospitalService.GetAll().ToListAsync();
            }

            return ObjectMapper.Map<List<HospitalResponse>>(hospitals);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("AssignedWards")]
        public async Task<List<HisWardResponse>> GetAssignedWards()
        {
            var currentPerson = await GetCurrentPersonAsync();
            var appointmentService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<WardRoleAppointedPerson, Guid>>();
            var wards = await appointmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Ward).ToListAsync();

            return ObjectMapper.Map<List<HisWardResponse>>(wards);
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

                    results =  await SaveOrUpdateEntityAsync<WardMidnightCensusReport>(entity.Id, async item =>
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

            if(entity == null)
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
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<HisWardResponse>> GetWardsAsync()
        {
            return await _wardCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{hospitalId}")]
        public async Task<List<HisWardResponse>> GetWardByHospitalAsync(Guid hospitalId)
        {
            return await _wardCrudHelper.GetWardByHospitalAsync(hospitalId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerOrganisationId"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet, Route("ownerOrganisation/{ownerOrganisationId}")]
        public async Task<List<AutocompleteItemDto>> GetWardByHospitalAutoCompleteAsync(Guid ownerOrganisationId, string term = null)
        {
            term = (term ?? "").ToLower();
            return ObjectMapper.Map<List<AutocompleteItemDto>>(await _wardCrudHelper.GetWardByHospitalAutoCompleteAsync(term, ownerOrganisationId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<HisWardResponse> GetWardAsync(Guid id)
        {
            return await _wardCrudHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [AbpAuthorize(PermissionNames.CreateFacility)]
        public async Task<HisWardResponse> CreateWardAsync(HisWardInput input)
        {
            Validation.ValidateText(input?.Name, "Name");
            Validation.ValidateText(input?.Description, "Description");
            Validation.ValidateNullableType(input?.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");

            var hospitals = await GetAssignedHospitals();
            if (hospitals.Any())
            {
                input.OwnerOrganisation = new EntityWithDisplayNameDto<Guid?>()
                {
                    DisplayText = hospitals[0].Name,
                    Id = hospitals[0].Id
                };
            }
            else
            {
                Validation.ValidateEntityWithDisplayNameDto(input?.OwnerOrganisation, "OwnerOrganisation");
            }

            return await _wardCrudHelper.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<HisWardResponse> UpdateWardAsync(HisWardInput input)
        {
            Validation.ValidateIdWithException(input?.Id, "Ward Id cannot be empty");
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateText(input.Description, "Description");
            Validation.ValidateNullableType(input.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");

            var hospitals = await GetAssignedHospitals();
            if (hospitals.Any())
            {
                input.OwnerOrganisation = new EntityWithDisplayNameDto<Guid?>()
                {
                    DisplayText = hospitals[0].Name,
                    Id = hospitals[0].Id
                };
            }
            else
            {
                Validation.ValidateEntityWithDisplayNameDto(input?.OwnerOrganisation, "OwnerOrganisation");
            }

            return await _wardCrudHelper.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public async Task DeleteWardAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "Ward Id cannot be empty");
            await _wardCrudHelper.DeleteAsync(id);
        }                
    }
}