using Abp.Authorization;
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
            table.OnRequestToFilter = (criteria, form) =>
            {
                var _session = Abp.Dependency.IocManager.Instance.Resolve<IAbpSession>();
                var personService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Person, Guid>>();
                var _hospitalRoleAppointedPersonRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
                var _wardRepository = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Ward, Guid>>();


                var person = personService.FirstOrDefault(c => c.User.Id == _session.GetUserId());
                var wardsId = new List<string>() { $"ent.Id='{Guid.Empty}'" };
                var hospitalIds = _hospitalRoleAppointedPersonRepository.GetAll().Where(x => x.Person.Id != person.Id).Select(x => x.Hospital.Id);
                wardsId.AddRange(_wardRepository.GetAll().Where(x => hospitalIds.Contains(x.OwnerOrganisation.Id)).Select(x => $"ent.Id='{x.Id}'"));

                var applicationsFilter = $"{wardsId.Delimited(" or ")}";
                criteria.FilterClauses.Add(applicationsFilter);
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
            table.OnRequestToFilter = (criteria, form) =>
            {
            };

            return table;
        }

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
            var hospitals = new List<Hospital>();

            if ( !await hisAdmissPermissionChecker.IsAdmin(currentPerson))
            {
                hospitals = await appointmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Hospital).ToListAsync();
            }
            else
            {
                var hospitalService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<Hospital, Guid>>();
                hospitals = await hospitalService.GetAll().ToListAsync();
            }

            return ObjectMapper.Map<List<HospitalResponse>>(hospitals);
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

            var ward = await GetEntityAsync<Ward>(input.WardId);

            var entity = await _wardMidnightCensusReport.FirstOrDefaultAsync(r => r.Ward == ward && r.ReportDate == input.ReportDate);

            if (entity == null) //Create the report since it doesn't exist
            {
                //Calculate on the fly
                var calculatedReport = await _sessionDataProvider.GetDailyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
                if (!calculatedReport.Any())
                {
                    entity = new WardMidnightCensusReport()
                    {
                        ReportDate = input.ReportDate,
                        TotalBedAvailability = ward.NumberOfBeds,
                        NumBedsInWard = ward.NumberOfBeds
                    };
                }
                else
                {
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
                        item.TodaysAdmission = dailyStat.TodaysAdmission;
                    });
                }
                return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
            }

            if (entity.ApprovalStatus != His.Domain.Domain.Enums.RefListApprovalStatuses.approved)
            {
                //Calculate on the fly
                var calculatedReport = await _sessionDataProvider.GetDailyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
                if (!calculatedReport.Any())
                {
                    entity = new WardMidnightCensusReport()
                    {
                        ReportDate = input.ReportDate,
                        TotalBedAvailability = ward.NumberOfBeds,
                        NumBedsInWard = ward.NumberOfBeds
                    };
                }
                else
                {
                    var dailyStat = calculatedReport[0];
                    entity = new WardMidnightCensusReport()
                    {
                        ReportDate = input.ReportDate,
                        MidnightCount = dailyStat.MidnightCount,
                        TotalAdmittedPatients = dailyStat.TotalAdmittedPatients,
                        TotalSeparatedPatients = dailyStat.TotalSeparatedPatients,
                        TotalBedAvailability = dailyStat.TotalBedAvailability,
                        NumBedsInWard = dailyStat.TotalBedInWard,
                        BedUtilisation = (double?)dailyStat.BedUtilisation,
                        AverageLengthofStay = (float?)dailyStat.AverageLengthOfStay,
                        AverageBedAvailability = (float?)dailyStat.AverageLengthOfStay,
                        TodaysAdmission = dailyStat.TodaysAdmission,
                        ApprovalStatus = entity.ApprovalStatus,
                        ApprovalTime = entity.ApprovalTime,
                        ApprovalTime2 = entity.ApprovalTime2,
                        ApprovedBy = entity.ApprovedBy,
                        ApprovedBy2 = entity.ApprovedBy2,
                        RejectedBy = entity.RejectedBy,
                        RejectionComments = entity.RejectionComments,
                        ReportType = entity.ReportType,
                        Ward = entity.Ward
                    };

                }
            }
            
            return ObjectMapper.Map<WardMidnightCensusReportResponse>(entity);
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
        [AbpAuthorize(PermissionNames.SubmitsReportsForApproval)]
        public async Task<WardMidnightCensusReportResponse> SubmitForApproval(WardCensusInput input)
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<WardResponse>> GetWardsAsync()
        {
            return await _wardCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]/{hospitalId}")]
        public async Task<List<WardResponse>> GetWardByHospitalAsync(Guid hospitalId)
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

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="term"></param>
        ///// <param name="personId"></param>
        ///// <returns></returns>
        //[HttpGet, Route("subject/{personId}")]
        //public async Task<List<AutocompleteItemDto>> GetWardByPersonAutoCompleteAsync(Guid personId)
        //{
        //    return ObjectMapper.Map<List<AutocompleteItemDto>>(await _wardCrudHelper.GetWardByPersonAutoCompleteAsync(personId));
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<WardResponse> GetWardAsync(Guid id)
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
        public async Task<WardResponse> CreateWardAsync(WardInput input)
        {
            Validation.ValidateText(input?.Name, "Name");
            Validation.ValidateText(input?.Description, "Description");
            Validation.ValidateNullableType(input?.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");
            Validation.ValidateEntityWithDisplayNameDto(input?.OwnerOrganisation, "OwnerOrganisation");

            return await _wardCrudHelper.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public async Task<WardResponse> UpdateWardAsync(WardInput input)
        {
            Validation.ValidateIdWithException(input?.Id, "Ward Id cannot be empty");
            Validation.ValidateText(input.Name, "Name");
            Validation.ValidateText(input.Description, "Description");
            Validation.ValidateNullableType(input.NumberOfBeds, "NumberOfBeds");
            Validation.ValidateReflist(input?.Speciality, "Speciliaty");
            Validation.ValidateEntityWithDisplayNameDto(input?.OwnerOrganisation, "OwnerOrganisation");

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
