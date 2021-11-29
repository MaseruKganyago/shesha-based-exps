using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers;
using Boxfusion.Health.His.Admissions.Domain.Views;
using Boxfusion.Health.His.Admissions.Helpers;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Boxfusion.Health.His.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Extensions;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisAdmis/[controller]")]
    public class AdmissionsAppService : SheshaAppServiceBase, IAdmissionsAppService
    {
        private readonly IEncounterCrudHelper<WardAdmission> _wardAdmissionCrudHelper;
        private readonly IEncounterCrudHelper<HospitalAdmission> _hospitalisationEncounterCrudHelper;
        private readonly IRepository<HisPatient, Guid> _patientRepository;
        private readonly IRepository<Ward, Guid> _wardRepository;
        private readonly IConditionsCrudHelper _conditionsCrudHelper;
        private readonly IRepository<Diagnosis, Guid> _diagnosisRepository;
        private readonly IRepository<ConditionIcdTenCode, Guid> _conditionIcdTenCodeRepository;
        private readonly IRepository<Condition, Guid> _conditionRepository;
        private readonly ISessionDataProvider _sessionDataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmissionCrudHelper"></param>
        /// <param name="patientRepository"></param>
        /// <param name="wardRepository"></param>
        /// <param name="conditionsCrudHelper"></param>
        /// <param name="diagnosisRepository"></param>
        /// <param name="conditionIcdTenCodeRepository"></param>
        /// <param name="hospitalisationEncounterCrudHelper"></param>
        /// <param name="conditionRepository"></param>
        public AdmissionsAppService(IEncounterCrudHelper<WardAdmission> wardAdmissionCrudHelper,
            IRepository<HisPatient, Guid> patientRepository,
            IRepository<Ward, Guid> wardRepository,
            IConditionsCrudHelper conditionsCrudHelper,
            IRepository<Diagnosis, Guid> diagnosisRepository,
            IRepository<ConditionIcdTenCode, Guid> conditionIcdTenCodeRepository,
            IEncounterCrudHelper<HospitalAdmission> hospitalisationEncounterCrudHelper,
            IRepository<Condition, Guid> conditionRepository, ISessionDataProvider sessionDataProvider)
        {
            _wardAdmissionCrudHelper = wardAdmissionCrudHelper;
            _patientRepository = patientRepository;
            _wardRepository = wardRepository;
            _conditionsCrudHelper = conditionsCrudHelper;
            _diagnosisRepository = diagnosisRepository;
            _conditionIcdTenCodeRepository = conditionIcdTenCodeRepository;
            _hospitalisationEncounterCrudHelper = hospitalisationEncounterCrudHelper;
            _conditionRepository = conditionRepository;
            _sessionDataProvider = sessionDataProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig IndexTable()
        {
            var table = new DataTableConfig<AdmittedPatientItems, Guid>("AdmittedPatients_Index");

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
            table.AddProperty(a => a.Days, b => b.Caption("Inpatient Days"));

            return table;
        }

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

                originalWard.AdmissionStatus = RefListAdmissionStatuses.admitted;

                await wardAdmissionService.UpdateAsync(originalWard);
                respose.Rejected = true;
            }

            await wardAdmissionService.UpdateAsync(wardAdmission);
            await ServiceBusHelper.TransferAddmission(wardAdmission);

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

            var patient = await _patientRepository.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
            if (patient == null) throw new UserFriendlyException("identityNumber can not be null.");

            return ObjectMapper.Map<HisPatientResponse>(patient);
        }
        /// <summary>
        /// Used to get the ward daily census by passing wardId and the Report date
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("GetWardCensusDailyStats")]
        public async Task<WardCensusResponse> GetWardCensusDailyStats(WardCensusInput input)
        {
            var dailyStats = await _sessionDataProvider.GetDailyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
            if (!dailyStats.Any())
            {
                throw new UserFriendlyException("No records found for the ward and date specified");
            }

            var dailyStat = dailyStats[0];

            return new WardCensusResponse()
            {
                MidnightCount = (int?)dailyStat.MidnightCount,
                TotalAdmittedPatients = (int?)dailyStat.TotalAdmittedPatients,
                TotalSeparatedPatients = (int?)dailyStat.TotalSeparatedPatients,
                TotalBedAvailability = (int?)dailyStat.TotalBedAvailability,
                TotalBedInWard = (int?)dailyStat.TotalBedInWard,
                AverageBedAvailability = dailyStat.AverageBedAvailability,
                AverageLengthOfStay = dailyStat.AverageLengthOfStay,
                BedUtilisation = dailyStat.BedUtilisation
            };
        }
        /// <summary>
        /// Used to het Monthly ward stats 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet, Route("GetWardCensusMonthlyStats")]
        public async Task<WardCensusResponse> GetWardCensusMonthlyStats(WardCensusInput input)
        {
            var dailyStats = await _sessionDataProvider.GetMonthlyStats(new WardCensusInput() { ReportDate = input.ReportDate, WardId = input.WardId });
            if (!dailyStats.Any())
            {
                throw new UserFriendlyException("No records found for the ward and date specified");
            }

            var dailyStat = dailyStats[0];

            return new WardCensusResponse()
            {
                MidnightCount = (int?)dailyStat.MidnightCount,
                TotalAdmittedPatients = (int?)dailyStat.TotalAdmittedPatients,
                TotalSeparatedPatients = (int?)dailyStat.TotalSeparatedPatients,
                TotalBedAvailability = (int?)dailyStat.TotalBedAvailability,
                TotalBedInWard = (int?)dailyStat.TotalBedInWard,
                AverageBedAvailability = dailyStat.AverageBedAvailability,
                AverageLengthOfStay = dailyStat.AverageLengthOfStay,
                BedUtilisation = dailyStat.BedUtilisation
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<ConditionResponse> GetCondition(Guid id)
        {
            if (id == Guid.Empty) throw new UserFriendlyException("id cannot be null.");

            var entity = await _conditionRepository.GetAsync(id);
            if (entity == null) throw new UserFriendlyException("Condition with specified id does not exist.");
            var conditionResult = ObjectMapper.Map<ConditionResponse>(entity);

            //Gets all conditionIcdTenCodeAssignments for the condition and maps to result
            var list = await _conditionIcdTenCodeRepository.GetAllListAsync();
            list.RemoveAll(a => a.Condition?.Id != conditionResult?.Id);

            conditionResult.Code = ObjectMapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(list);

            return conditionResult;
        }

        private async Task<DiagnosisResponse> SaveOrUpdateDiagnosis(DiagnosisInput diagnosis, WardAdmission ownerEntity)
        {
            //Creates new Condition for Diagnosis if the was no existing condition to relate to the diagnosis
            var condition = new ConditionResponse();
            if (Validation.ValidateId(diagnosis.Condition.Id) == null)
            {
                condition = await _conditionsCrudHelper.CreateAsync(diagnosis.Condition);
                diagnosis.Condition.Id = condition.Id;
                diagnosis.Condition.Code = condition.Code;
            }

            var entity = await SaveOrUpdateEntityAsync<Diagnosis>((Guid?)Validation.ValidateId(diagnosis.Id), async item =>
            {
                ObjectMapper.Map(diagnosis, item);
                item.OwnerId = ownerEntity.Id.ToString();
                item.OwnerType = ownerEntity.GetTypeShortAlias();
            });

            var result = ObjectMapper.Map<DiagnosisResponse>(entity);
            result.Condition = condition;
            return result;
        }
    }
}
