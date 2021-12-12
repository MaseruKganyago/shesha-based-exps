using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using NHibernate.Linq;
using Shesha.AutoMapper.Dto;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class AdmissionCrudHelper : IAdmissionCrudHelper, ITransientDependency
    {
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepositiory;
        private readonly IPatientCrudHelper<HisPatient, NonUserCdmPatientResponse> _patientCrudHelper;
        private readonly IRepository<EncounterLocation, Guid> _encounterLocationRepositiory;
        private readonly IRepository<ConditionIcdTenCode, Guid> _conditionIcdTenCodeRepositiory;
        private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepositiory;
        private readonly IRepository<Condition, Guid> _conditionRepositiory;
        private readonly IRepository<Diagnosis, Guid> _diagnosisRepositiory;
        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
        private readonly IRepository<Ward, Guid> _wardRepositiory;
        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmissionRepositiory"></param>
        /// <param name="hospitalAdmissionRepositiory"></param>
        /// <param name="patientCrudHelper"></param>
        /// <param name="encounterLocationRepositiory"></param>
        /// <param name="conditionIcdTenCodeRepositiory"></param>
        /// <param name="icdTenCodeRepositiory"></param>
        /// <param name="conditionRepositiory"></param>
        /// <param name="diagnosisRepositiory"></param>
        /// <param name="hisPatientRepositiory"></param>
        /// <param name="wardRepositiory"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public AdmissionCrudHelper(
            IRepository<WardAdmission, Guid> wardAdmissionRepositiory,
            IRepository<HospitalAdmission, Guid> hospitalAdmissionRepositiory,
            IPatientCrudHelper<HisPatient, NonUserCdmPatientResponse> patientCrudHelper,
            IRepository<EncounterLocation, Guid> encounterLocationRepositiory,
            IRepository<ConditionIcdTenCode, Guid> conditionIcdTenCodeRepositiory,
            IRepository<IcdTenCode, Guid> icdTenCodeRepositiory,
            IRepository<Condition, Guid> conditionRepositiory,
            IRepository<Diagnosis, Guid> diagnosisRepositiory,
            IRepository<HisPatient, Guid> hisPatientRepositiory,
            IRepository<Ward, Guid> wardRepositiory,
            IUnitOfWorkManager unitOfWork,
            IMapper mapper)
        {
            _wardAdmissionRepositiory = wardAdmissionRepositiory;
            _hospitalAdmissionRepositiory = hospitalAdmissionRepositiory;
            _patientCrudHelper = patientCrudHelper;
            _encounterLocationRepositiory = encounterLocationRepositiory;
            _conditionIcdTenCodeRepositiory = conditionIcdTenCodeRepositiory;
            _icdTenCodeRepositiory = icdTenCodeRepositiory;
            _conditionRepositiory = conditionRepositiory;
            _diagnosisRepositiory = diagnosisRepositiory;
            _hisPatientRepositiory = hisPatientRepositiory;
            _wardRepositiory = wardRepositiory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AdmissionResponse>> GetAllAsync(Guid wardId, DateTime admissionDate)
        {
            var admissions = await _wardAdmissionRepositiory.GetAllListAsync(x => x.Ward.Id == wardId && x.StartDateTime.Value.Date == admissionDate.Date && x.AdmissionStatus != RefListAdmissionStatuses.rejected);

            var admissionResponses = _mapper.Map<List<AdmissionResponse>>(admissions);

            return admissionResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AdmissionResponse>> GetPatientAuditTrailAsync(Guid partOfId)
        {
            var admissions = await _wardAdmissionRepositiory.GetAll().Where(x => x.PartOf.Id == partOfId).OrderByDescending(x => x.CreationTime).ToListAsync();
            var admissionResponses = _mapper.Map<List<AdmissionResponse>>(admissions);

            return admissionResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AdmissionResponse> GetAsync(Guid id)
        {
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(id);
            HospitalAdmission hospitalAdmission = null;
            if (wardAdmission?.PartOf != null)
                hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);

            HisPatient hisPatient = null;
            if (wardAdmission?.Subject != null)
                hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);

            List<EntityWithDisplayNameDto<Guid?>> codes = await GetIcdTenCodes(wardAdmission);

            AdmissionResponse admissionResponse = null;
            if(hospitalAdmission != null)
                admissionResponse = _mapper.Map<AdmissionResponse>(hospitalAdmission);

            if(admissionResponse != null)
                _mapper.Map(wardAdmission, admissionResponse);
            else
                admissionResponse = _mapper.Map<AdmissionResponse>(wardAdmission);

            _mapper.Map(hisPatient, admissionResponse);
            _mapper.Map(wardAdmission.Ward, admissionResponse);
            UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);

            if (hisPatient.DateOfBirth.HasValue && wardAdmission.SeparationDate.HasValue)
                admissionResponse.AgeBreakdown = AgeBreakdown(hisPatient.DateOfBirth.Value, wardAdmission.SeparationDate.Value);

            return admissionResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalAdmissionId"></param>
        /// <returns></returns>
        public async Task<List<AdmissionResponse>> GetWardAdmissions(Guid hospitalAdmissionId)
        {
            var wardAdmissions = await _wardAdmissionRepositiory.GetAll().Where(r => r.Ward.OwnerOrganisation.Id == hospitalAdmissionId).ToListAsync();

            var admissionsResponse = new List<AdmissionResponse>();
            foreach (var wardAdmission in wardAdmissions)
            {
                var admissionResponse = _mapper.Map<AdmissionResponse>(wardAdmission);
                HospitalAdmission hospitalAdmission = null;
                if (wardAdmission?.PartOf != null)
                    hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);

                HisPatient hisPatient = null;
                if (wardAdmission?.Subject != null)
                    hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);

                List<EntityWithDisplayNameDto<Guid?>> codes = await GetIcdTenCodes(wardAdmission);

                _mapper.Map(hospitalAdmission, admissionResponse);
                _mapper.Map(hisPatient, admissionResponse);
                _mapper.Map(wardAdmission.Ward, admissionResponse);
                UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);

                admissionsResponse.Add(admissionResponse);
            }

            return admissionsResponse;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <param name="currentWardId"></param>
        /// <returns></returns>
        public async Task ValidateIdentityNumber(string identityNumber, Guid currentWardId)
        {
            if (!Validation.IsValidIdentityNumber(identityNumber))
                throw new UserFriendlyException("The specified identify number is not a valid South African number.");

            var wardAdmissions = await _wardAdmissionRepositiory.GetAllListAsync(x => x.Subject.IdentityNumber == identityNumber);
            if (wardAdmissions.Count() > 0)
            {
                if (!wardAdmissions.Where(x => x.AdmissionStatus == RefListAdmissionStatuses.admitted).Any())
                    throw new UserFriendlyException($"This I.D. number belongs to a returning patient {wardAdmissions[0].Subject.FullName}, {identityNumber}");

                if (wardAdmissions.Where(x => x.Ward.Id == currentWardId && x.AdmissionStatus == RefListAdmissionStatuses.admitted).Any())
                    throw new UserFriendlyException($"The patient with the entered ID number ({identityNumber}) has already been admitted in this ward");

                if (wardAdmissions.Where(x => x.Ward.Id != currentWardId && x.AdmissionStatus == RefListAdmissionStatuses.admitted).Any())
                {
                    var wardAdmission = wardAdmissions.Where(x => x.Ward.Id != currentWardId && x.AdmissionStatus == RefListAdmissionStatuses.admitted).FirstOrDefault();
                    throw new UserFriendlyException($"The patient with the entered ID number ({identityNumber}) has already been admitted in {wardAdmission.Ward.Name} ward. Please separate the patient from the other ward, before admitting them to this ward.");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <param name="hisPatient"></param>
        /// <returns></returns>
        public async Task<AdmissionResponse> CreateAsync(AdmissionInput input, PersonFhirBase currentLoggedInPerson, HisPatient hisPatient)
        {
            //Create patient
            var admissionResponse = _mapper.Map<AdmissionResponse>(hisPatient);
                var hospitalAdmission = _mapper.Map<HospitalAdmission>(input);
                _mapper.Map(hisPatient, hospitalAdmission);
                var insertedHospitalAdmission = await _hospitalAdmissionRepositiory.InsertAsync(hospitalAdmission);
                //}

                //Create ward admission record
                var wardAdmission = _mapper.Map<WardAdmission>(input);
                wardAdmission.PartOf = insertedHospitalAdmission;
                _mapper.Map(hisPatient, wardAdmission);
                var insertedWardAdmission = await _wardAdmissionRepositiory.InsertAsync(wardAdmission);

                //Create a condition
                var condition = new Condition
                {
                    RecordedDate = DateTime.Now,
                    Subject = hisPatient,
                    Recorder = currentLoggedInPerson,
                    FhirEncounter = insertedWardAdmission,
                    HospitalisationEncounter = insertedHospitalAdmission
                };

                var insertedCondition = await _conditionRepositiory.InsertAsync(condition);

                List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = new List<EntityWithDisplayNameDto<Guid?>>();
                //add a list of conditionIcdTenCode to a task
                if (input?.Code != null && input?.Code.Count() > 0)
                {
                    //Add newly updated contact points
                    var taskConditionIcdTenCodes = new List<Task<EntityWithDisplayNameDto<Guid?>>>(); //Tasks lists to handle batch insert into database
                    input.Code.ForEach((v) => taskConditionIcdTenCodes.Add(CreateICdTenCode(v, insertedCondition)));
                    var conditonIcdTenCodes = ((IList<EntityWithDisplayNameDto<Guid?>>)await Task.WhenAll(taskConditionIcdTenCodes)); //save contact points to db
                    icdTenCodeResponses = conditonIcdTenCodes.ToList();
                }

                //Create a diagnosis
                var diagnosis = new Diagnosis
                {
                    OwnerId = insertedHospitalAdmission.Id.ToString(),
                    OwnerType = insertedHospitalAdmission.GetTypeShortAlias(),
                    Condition = insertedCondition,          
                };
                var insertedDiagnosis = await _diagnosisRepositiory.InsertAsync(diagnosis);
                _mapper.Map(insertedHospitalAdmission, admissionResponse);
                _mapper.Map(insertedWardAdmission, admissionResponse);
                _mapper.Map(wardAdmission?.Ward, admissionResponse);
            UtilityHelper.TrySetProperty(admissionResponse, "Code", icdTenCodeResponses);

            return admissionResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        public async Task<AdmissionResponse> UpdateAsync(AdmissionInput input, PersonFhirBase currentLoggedInPerson)
        {
            //AdmissionResponse admissionResponse = null;
            var dbWardAdmission = await _wardAdmissionRepositiory.GetAsync(input.Id);
            var dbHisPatient = await _hisPatientRepositiory.GetAsync(dbWardAdmission.Subject.Id);
            _mapper.Map(input, dbWardAdmission);
            var updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(dbWardAdmission);
            var admissionResponse = _mapper.Map<AdmissionResponse>(updatedWardAdmission);

            if (dbWardAdmission?.PartOf != null)
            {
                var dbHospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(dbWardAdmission.PartOf.Id);
                _mapper.Map(input, dbHospitalAdmission);
                var updatedHospitalAdmission = await _hospitalAdmissionRepositiory.UpdateAsync(dbHospitalAdmission);
                _mapper.Map(updatedHospitalAdmission, admissionResponse);
            }

            //Update a condition
            var dbCondition = await _conditionRepositiory.FirstOrDefaultAsync(x => x.FhirEncounter == dbWardAdmission);

            List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = new List<EntityWithDisplayNameDto<Guid?>>();
                //add a list of conditionIcdTenCode to a task
            if (input?.Code != null && input?.Code.Count() > 0)
            {
                //Delete old conditionIcdTenCode when deleting
                var dbConditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => x.Condition == dbCondition);
                dbConditionIcdTenCodes.ForEach(x => x.IsDeleted = false);
                var taskDeleteConditionIcdTenCodes = new List<Task>();
                dbConditionIcdTenCodes.ForEach((conditionIcdTenCode) => taskDeleteConditionIcdTenCodes.Add(DeleteConditionIcdTenCode(conditionIcdTenCode)));

                //Add newly updated contact points
                var taskConditionIcdTenCodes = new List<Task<EntityWithDisplayNameDto<Guid?>>>(); //Tasks lists to handle batch insert into database
                input.Code.ForEach((v) => taskConditionIcdTenCodes.Add(CreateICdTenCode(v, dbCondition)));
                var conditonIcdTenCodes = ((IList<EntityWithDisplayNameDto<Guid?>>)await Task.WhenAll(taskConditionIcdTenCodes)); //save contact points to db
                icdTenCodeResponses = conditonIcdTenCodes.ToList();
            }

            _mapper.Map(dbWardAdmission?.Ward, admissionResponse);
            UtilityHelper.TrySetProperty(admissionResponse, "Code", icdTenCodeResponses);

            return admissionResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _wardAdmissionRepositiory.GetAsync(id);
            await _wardAdmissionRepositiory.DeleteAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditionIcdTenCode"></param>
        /// <returns></returns>
        private async Task DeleteConditionIcdTenCode(ConditionIcdTenCode conditionIcdTenCode)
        {
            using (var uow = _unitOfWork.Begin())
            {
                await _conditionIcdTenCodeRepositiory.DeleteAsync(conditionIcdTenCode);
                uow.Complete();
            }
        }

        private string AgeBreakdown(DateTime dateOfBirth, DateTime separationDate)
        {

            int Years = new DateTime(DateTime.Now.Subtract(dateOfBirth).Ticks).Year - 1;
            DateTime PastYearDate = dateOfBirth.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == separationDate)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= separationDate)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = separationDate.Subtract(PastYearDate.AddMonths(Months)).Days;

            if (Years == 0 && Months == 0 && Days >= 0)
            {
                if (Days <= 6)
                    return "0-6 days";

                if (Days <= 7 && Days >= 28)
                    return "7-28 days";

                if (Days <= 29)
                    return "29 days - 11 months";
            }

            if (Years == 0 && Months <= 11 && Days >= 0)
            {
                if (Days <= 6)
                    return "0-6 days";

                if (Days >= 7 && Days <= 28)
                    return "7-28 days";

                if (Days <= 29)
                    return "29 days - 11 months";
            }

            if (Years < 5)
                return "12-59 months";

            if (Years > 5 && Years < 12)
                return "5-12 years";

            if (Years > 12)
                return "> 12 years";

            return " No age range found";
        }

        private async Task<List<EntityWithDisplayNameDto<Guid?>>> GetIcdTenCodes(WardAdmission wardAdmission)
        {
            //Get IcdTenCodes
            List<Condition> conditions = null;
            List<EntityWithDisplayNameDto<Guid?>> codes = new List<EntityWithDisplayNameDto<Guid?>>();
            //if (insertedHospitalAdmission != null)
            //    conditions = await _conditionRepositiory.GetAllListAsync(x => x.Subject == hisPatient && x.HospitalisationEncounter.Id == insertedHospitalAdmission.Id);
            //else
            conditions = await _conditionRepositiory.GetAllListAsync(x => x.FhirEncounter == wardAdmission);
            if(conditions?.Count() > 0)
            {
                List<ConditionIcdTenCode> conditionIcdTenCodes = null;
                List<IcdTenCode> icdTenCodes = null;
                if (conditions.Count() > 0)
                {
                    conditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => conditions.Contains(x.Condition));

                    var icdTenCodeIds = conditionIcdTenCodes.Select(x => x.IcdTenCode.Id).ToList();
                    if (conditionIcdTenCodes.Count() > 0)
                        icdTenCodes = await _icdTenCodeRepositiory.GetAll().Where(x => icdTenCodeIds.Contains(x.Id)).ToListAsync();
                }

                if (icdTenCodes?.Count() > 0)
                    icdTenCodes.ForEach(icdTenCode => codes.Add(new EntityWithDisplayNameDto<Guid?>(icdTenCode.Id, icdTenCode.ICDTenThreeCodeDesc)));
            }

            return codes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        private async Task<EntityWithDisplayNameDto<Guid?>> CreateICdTenCode(EntityWithDisplayNameDto<Guid?> input, Condition condition)
        {
            ConditionIcdTenCode insertedConditionIcdTenCode = null;
            var icdTenCode = await _icdTenCodeRepositiory.GetAsync(input.Id.Value);
            using (var uow = _unitOfWork.Begin())
            {
                var conditionIcdTenCode = new ConditionIcdTenCode
                {
                    Condition = condition,
                    IcdTenCode = icdTenCode
                };

                insertedConditionIcdTenCode = await _conditionIcdTenCodeRepositiory.InsertAsync(conditionIcdTenCode);
                uow.Complete();
            }

            return new EntityWithDisplayNameDto<Guid?>(icdTenCode.Id, icdTenCode.ICDTenThreeCodeDesc);
        }
    }
}
