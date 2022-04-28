using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Shesha.AutoMapper.Dto;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Common.Enums;
using NHibernate.Linq;
using Shesha.Extensions;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.NHibernate;
using Abp.UI;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Domain.Helpers;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Admissions
{
    /// <summary>
    ///  Domain Service for the Admission entity.
    /// </summary>
    public class AdmissionsManager : DomainService
    {
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepositiory;
        private readonly IPatientCrudHelper<HisPatient, NonUserCdmPatientResponse> _patientCrudHelper;
        private readonly IRepository<EncounterLocation, Guid> _encounterLocationRepositiory;
        private readonly IRepository<HisConditionIcdTenCode, Guid> _conditionIcdTenCodeRepositiory;
        private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepositiory;
        private readonly IRepository<Condition, Guid> _conditionRepositiory;
        private readonly IRepository<Diagnosis, Guid> _diagnosisRepositiory;
        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
        private readonly IRepository<HisWard, Guid> _wardRepositiory;
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
        public AdmissionsManager(
            IRepository<WardAdmission, Guid> wardAdmissionRepositiory,
            IRepository<HospitalAdmission, Guid> hospitalAdmissionRepositiory,
            IPatientCrudHelper<HisPatient, NonUserCdmPatientResponse> patientCrudHelper,
            IRepository<EncounterLocation, Guid> encounterLocationRepositiory,
            IRepository<HisConditionIcdTenCode, Guid> conditionIcdTenCodeRepositiory,
            IRepository<IcdTenCode, Guid> icdTenCodeRepositiory,
            IRepository<Condition, Guid> conditionRepositiory,
            IRepository<Diagnosis, Guid> diagnosisRepositiory,
            IRepository<HisPatient, Guid> hisPatientRepositiory,
            IRepository<HisWard, Guid> wardRepositiory,
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
        public async Task<List<WardAdmission>> GetAllAsync(Guid wardId, DateTime admissionDate)
        {
            var admissions = await _wardAdmissionRepositiory.GetAllListAsync(x => x.Ward.Id == wardId && 
                                                                             x.StartDateTime.Value.Date == admissionDate.Date && 
                                                                             x.AdmissionStatus != RefListAdmissionStatuses.rejected);

            return admissions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<WardAdmission>> GetPatientAuditTrailAsync(Guid partOfId)
        {
            var admissions = await _wardAdmissionRepositiory.GetAll().Where(x => x.PartOf.Id == partOfId)
                                                                     .OrderByDescending(x => x.CreationTime).ToListAsync();

            return admissions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns WardAdmission entity with it's relations using the WardAdmissionWithRelations class</returns>
        public async Task<WardAdmissionWithRelations> GetByIdWithRelationsAsync(Guid id)
        {
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(id);

            HospitalAdmission hospitalAdmission = null;
            if (wardAdmission?.PartOf != null)
                hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);

            HisPatient hisPatient = null;
            if (wardAdmission?.Subject != null)
                hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);

            var results = await GetIcdTenCodes(wardAdmission);

            return new WardAdmissionWithRelations(wardAdmission, hospitalAdmission, hisPatient, results.Item1, results.Item2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalAdmissionId"></param>
        /// <returns>Returns WardAdmission entity list with it's relations using the WardAdmissionWithRelations class</returns>
        public async Task<List<WardAdmissionWithRelations>> GetByHospitalAdmissionIdWithRelationsAsync(Guid hospitalAdmissionId)
        {
            var wardAdmissions = await _wardAdmissionRepositiory.GetAll().Where(r => r.Ward.OwnerOrganisation.Id == hospitalAdmissionId).ToListAsync();

            var admissionsResponse = new List<WardAdmissionWithRelations>();
            foreach (var wardAdmission in wardAdmissions)
            {
                HospitalAdmission hospitalAdmission = null;
                if (wardAdmission?.PartOf != null)
                    hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);

                HisPatient hisPatient = null;
                if (wardAdmission?.Subject != null)
                    hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);

                var results = await GetIcdTenCodes(wardAdmission);

                admissionsResponse.Add(new WardAdmissionWithRelations(wardAdmission, hospitalAdmission, hisPatient, results.Item1, results.Item2));
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
            if (wardAdmissions.Any())
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
        /// <param name="wardId"></param>
        /// <returns></returns>
        public async Task<bool> IsBedStillAvailable(Guid wardId)
        {
            var wardAdmissionCount = await _wardAdmissionRepositiory.GetAll()
                                                                    .Where(x => x.AdmissionStatus == RefListAdmissionStatuses.admitted &&
                                                                     x.IsDeleted == false && x.Ward.Id == wardId).ToListAsync();
            var wardCount = await _wardRepositiory.GetAsync(wardId);

            return wardAdmissionCount.Count() >= wardCount.NumberOfBeds;
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
            //Create hospital admission
            var admissionResponse = _mapper.Map<AdmissionResponse>(hisPatient);
            var hospitalAdmission = _mapper.Map<HospitalAdmission>(input);
            _mapper.Map(hisPatient, hospitalAdmission);
            var insertedHospitalAdmission = await _hospitalAdmissionRepositiory.InsertAsync(hospitalAdmission);

            //Create ward admission record
            var wardAdmission = _mapper.Map<WardAdmission>(input);
            _mapper.Map(currentLoggedInPerson, wardAdmission);
            wardAdmission.PartOf = insertedHospitalAdmission;
            _mapper.Map(hisPatient, wardAdmission);
            var insertedWardAdmission = await _wardAdmissionRepositiory.InsertAsync(wardAdmission);
            List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = await AddDiagnoses(input, currentLoggedInPerson, hisPatient, insertedHospitalAdmission, insertedWardAdmission, false);

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
            _mapper.Map(currentLoggedInPerson, dbWardAdmission);
            var dbHisPatient = await _hisPatientRepositiory.GetAsync(dbWardAdmission.Subject.Id);
            _mapper.Map(input, dbWardAdmission);
            var updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(dbWardAdmission);
            var admissionResponse = _mapper.Map<AdmissionResponse>(updatedWardAdmission);

            HospitalAdmission dbHospitalAdmission = null;
            if (dbWardAdmission?.PartOf != null)
            {
                dbHospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(dbWardAdmission.PartOf.Id);
                _mapper.Map(input, dbHospitalAdmission);
                var updatedHospitalAdmission = await _hospitalAdmissionRepositiory.UpdateAsync(dbHospitalAdmission);
                _mapper.Map(updatedHospitalAdmission, admissionResponse);
            }

            //Delete conditionIcd10Code
            var dbConditions = await _conditionRepositiory.GetAllListAsync(x => x.FhirEncounter == dbWardAdmission);
            List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = new List<EntityWithDisplayNameDto<Guid?>>();

            var dbConditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => dbConditions.Contains(x.Condition) && x.AdmissionStatus == RefListAdmissionStatuses.admitted && x.IsDeleted == false);
            dbConditionIcdTenCodes.ForEach(x => x.IsDeleted = false);
            var taskDeleteConditionIcdTenCodes = new List<Task>();
            dbConditionIcdTenCodes.ForEach((conditionIcdTenCode) => taskDeleteConditionIcdTenCodes.Add(DeleteConditionIcdTenCode(conditionIcdTenCode)));

            //add a list of conditionIcdTenCode to a task
            if (input?.Code != null && input.Code.Any())
            {
                //Add newly updated contact points
                var condition = dbConditionIcdTenCodes.Select(x => x.Condition).FirstOrDefault() ?? await _conditionRepositiory.InsertAsync(new Condition { RecordedDate = DateTime.Now, Subject = dbHisPatient, Recorder = currentLoggedInPerson, FhirEncounter = updatedWardAdmission, HospitalisationEncounter = dbHospitalAdmission });
                var taskConditionIcdTenCodes = new List<Task<EntityWithDisplayNameDto<Guid?>>>(); //Tasks lists to handle batch insert into database
                input.Code.ForEach((v) => taskConditionIcdTenCodes.Add(CreateICdTenCode(v, condition, false)));
                var conditonIcdTenCodes = ((IList<EntityWithDisplayNameDto<Guid?>>)await Task.WhenAll(taskConditionIcdTenCodes)); //save contact points to db
                icdTenCodeResponses = conditonIcdTenCodes.ToList();
            }

            var _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
            await _unitOfWork.Current.SaveChangesAsync();
            await _sessionProvider.Session.Transaction.CommitAsync();

            _mapper.Map(dbWardAdmission?.Ward, admissionResponse);
            var results = await GetIcdTenCodes(dbWardAdmission);
            //List<EntityWithDisplayNameDto<Guid?>> codes = results.Item1;
            //List<EntityWithDisplayNameDto<Guid?>> separationCodes = results.Item2;

            //UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);
            //UtilityHelper.TrySetProperty(admissionResponse, "SeparationCode", separationCodes);

            return admissionResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        public async Task<AdmissionResponse> SeparatePatientAsync(AdmissionInput input, PersonFhirBase currentLoggedInPerson)
        {
            var dbWardAdmission = await _wardAdmissionRepositiory.GetAsync(input.Id);
            List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = new List<EntityWithDisplayNameDto<Guid?>>();

            var patient = await _hisPatientRepositiory.GetAsync(dbWardAdmission.Subject.Id);
            var admissionResponse = _mapper.Map<AdmissionResponse>(patient);
            var separationInput = _mapper.Map<SeparationInput>(input);

            _mapper.Map(separationInput, dbWardAdmission);
            dbWardAdmission.AdmissionStatus = RefListAdmissionStatuses.separated;
            var updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(dbWardAdmission);

            var dbHospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(dbWardAdmission.PartOf.Id);
            _mapper.Map(separationInput, dbHospitalAdmission);
            var updatedHospitalAdmission = await _hospitalAdmissionRepositiory.UpdateAsync(dbHospitalAdmission);

            //Add diagnosis
            icdTenCodeResponses = await AddDiagnoses(input, currentLoggedInPerson, (HisPatient)patient, dbHospitalAdmission, updatedWardAdmission, true);

            if (input?.SeparationType?.ItemValue == (int)RefListSeparationTypes.internalTransfer)
            {
                //Create hospital admission
                var hospitalAdmission = _mapper.Map<HospitalAdmission>(input);
                _mapper.Map(patient, hospitalAdmission);
                var insertedHospitalAdmission = await _hospitalAdmissionRepositiory.InsertAsync(hospitalAdmission);

                //Create ward admission record
                var ward2Admission = _mapper.Map<WardAdmission>(input);
                _mapper.Map(currentLoggedInPerson, ward2Admission);
                ward2Admission.PartOf = insertedHospitalAdmission;
                _mapper.Map(patient, ward2Admission);
                ward2Admission.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                var ward = await _wardRepositiory.GetAsync(input.SeparationDestinationWard.Id.Value);
                ward2Admission.Ward = ward;
                ward2Admission.InternalTransferOriginalWard = dbWardAdmission;
                var insertedWardAdmission = await _wardAdmissionRepositiory.InsertAsync(ward2Admission);

                //Add diagnosis
                input.Code = separationInput?.SeparationCode;
                await AddDiagnoses(input, currentLoggedInPerson, (HisPatient)patient, insertedHospitalAdmission, insertedWardAdmission, false);
                dbWardAdmission.InternalTransferDestinationWard = insertedWardAdmission;
                updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(dbWardAdmission);
            }

            var _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
            await _unitOfWork.Current.SaveChangesAsync();
            await _sessionProvider.Session.Transaction.CommitAsync();

            var results = await GetIcdTenCodes(dbWardAdmission);
            //List<EntityWithDisplayNameDto<Guid?>> codes = results.Item1;
            //List<EntityWithDisplayNameDto<Guid?>> separationCodes = results.Item2;

            _mapper.Map(updatedHospitalAdmission, admissionResponse);
            _mapper.Map(updatedWardAdmission, admissionResponse);
            //UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);
            //UtilityHelper.TrySetProperty(admissionResponse, "SeparationCode", separationCodes);

            return admissionResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admission"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        public async Task<AdmissionResponse> UndoSeparation(UndoSeparationDto admission, PersonFhirBase currentLoggedInPerson)
        {
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(admission.Id);
            wardAdmission.AdmissionStatus = RefListAdmissionStatuses.admitted;
            var hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);
            var hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);

            if (wardAdmission?.SeparationType == RefListSeparationTypes.internalTransfer)
            {
                if (Validation.IsValidateId(wardAdmission?.InternalTransferDestinationWard?.Id))
                {
                    var ward2Admission = await _wardAdmissionRepositiory.GetAsync(wardAdmission.InternalTransferDestinationWard.Id);
                    await _wardAdmissionRepositiory.DeleteAsync(ward2Admission);
                }
            }

            var separationResponse = _mapper.Map<SeparationResponse>(wardAdmission);
            _mapper.Map(hospitalAdmission, separationResponse);

            _mapper.Map(separationResponse, wardAdmission);
            _mapper.Map(separationResponse, hospitalAdmission);

            await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);
            await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);

            //Delete conditionIcd10Code
            var dbConditions = await _conditionRepositiory.GetAllListAsync(x => x.FhirEncounter == wardAdmission);
            List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = new List<EntityWithDisplayNameDto<Guid?>>();

            var dbConditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => dbConditions.Contains(x.Condition) && x.AdmissionStatus == RefListAdmissionStatuses.separated && x.IsDeleted == false);
            dbConditionIcdTenCodes.ForEach(x => x.IsDeleted = false);
            var taskDeleteConditionIcdTenCodes = new List<Task>();
            dbConditionIcdTenCodes.ForEach((conditionIcdTenCode) => taskDeleteConditionIcdTenCodes.Add(DeleteConditionIcdTenCode(conditionIcdTenCode)));

            var _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
            await _unitOfWork.Current.SaveChangesAsync();
            await _sessionProvider.Session.Transaction.CommitAsync();

            var admissionResponse = _mapper.Map<AdmissionResponse>(hisPatient);
            _mapper.Map(hospitalAdmission, admissionResponse);
            _mapper.Map(wardAdmission, admissionResponse);
            _mapper.Map(wardAdmission?.Ward, admissionResponse);
            var results = await GetIcdTenCodes(wardAdmission);
            //List<EntityWithDisplayNameDto<Guid?>> codes = results.Item1;
            //List<EntityWithDisplayNameDto<Guid?>> separationCodes = results.Item2;

            //UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);
            //UtilityHelper.TrySetProperty(admissionResponse, "SeparationCode", separationCodes);
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
        private async Task DeleteConditionIcdTenCode(HisConditionIcdTenCode conditionIcdTenCode)
        {
            using (var uow = _unitOfWork.Begin())
            {
                await _conditionIcdTenCodeRepositiory.DeleteAsync(conditionIcdTenCode);
                uow.Complete();
            }
        }

        private async Task<Tuple<List<IcdTenCode>, List<IcdTenCode>>> GetIcdTenCodes(WardAdmission wardAdmission)
        {

            List<IcdTenCode> icdTenCodes = new List<IcdTenCode>();
            List<IcdTenCode> separationIcdTenCodes = new List<IcdTenCode>();

            var conditions = await _conditionRepositiory.GetAll().Where(x => x.FhirEncounter == wardAdmission).ToListAsync();
            if (conditions.Any())
            {
                //Admission Icd10Codes
                var conditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => conditions.Contains(x.Condition) &&
                                                                                 x.AdmissionStatus == RefListAdmissionStatuses.admitted &&
                                                                                 x.IsDeleted == false);
                if (conditionIcdTenCodes.Any())
                {
                    var icdTenCodeIds = conditionIcdTenCodes.Select(x => x.IcdTenCode.Id).ToList();
                    icdTenCodes = await _icdTenCodeRepositiory.GetAll().Where(x => icdTenCodeIds.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
                }

                //Separation Icd10Codes
                var separationConditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => conditions.Contains(x.Condition) &&
                                                                                            x.AdmissionStatus == RefListAdmissionStatuses.separated &&
                                                                                            x.IsDeleted == false);
                if (separationConditionIcdTenCodes.Any())
                {
                    var separationIcdTenCodeIds = separationConditionIcdTenCodes.Select(x => x.IcdTenCode.Id).ToList();
                    separationIcdTenCodes = await _icdTenCodeRepositiory.GetAll().Where(x => separationIcdTenCodeIds.Contains(x.Id) &&
                                                                                        x.IsDeleted == false).ToListAsync();
                }
            }

            return new Tuple<List<IcdTenCode>, List<IcdTenCode>>(icdTenCodes, separationIcdTenCodes);
        }

        private async Task<List<EntityWithDisplayNameDto<Guid?>>> AddDiagnoses(AdmissionInput input, PersonFhirBase currentLoggedInPerson, HisPatient hisPatient, HospitalAdmission insertedHospitalAdmission, WardAdmission insertedWardAdmission, bool isSeparation = true)
        {
            List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            if (!isSeparation)
            {
                //add a list of conditionIcdTenCode to a task
                if (input?.Code != null && input.Code.Any())
                {
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

                    //Add newly updated contact points
                    var taskConditionIcdTenCodes = new List<Task<EntityWithDisplayNameDto<Guid?>>>(); //Tasks lists to handle batch insert into database
                    input.Code.ForEach((v) => taskConditionIcdTenCodes.Add(CreateICdTenCode(v, insertedCondition, false)));
                    var conditonIcdTenCodes = ((IList<EntityWithDisplayNameDto<Guid?>>)await Task.WhenAll(taskConditionIcdTenCodes)); //save contact points to db
                    icdTenCodeResponses = conditonIcdTenCodes.ToList();

                    //Create a diagnosis
                    var diagnosis = new Diagnosis
                    {
                        OwnerId = insertedHospitalAdmission.Id.ToString(),
                        OwnerType = insertedHospitalAdmission.GetTypeShortAlias(),
                        Condition = insertedCondition,
                    };
                    var insertedDiagnosis = await _diagnosisRepositiory.InsertAsync(diagnosis);
                }
            }
            else
            {
                //add a list of conditionIcdTenCode to a task
                if (input?.SeparationCode != null && input.SeparationCode.Any())
                {
                    //Delete conditionIcd10Code
                    var dbConditions = await _conditionRepositiory.GetAllListAsync(x => x.FhirEncounter == insertedWardAdmission);
                    icdTenCodeResponses = new List<EntityWithDisplayNameDto<Guid?>>();

                    var dbConditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => dbConditions.Contains(x.Condition) && x.AdmissionStatus == RefListAdmissionStatuses.admitted && x.IsDeleted == false);
                    dbConditionIcdTenCodes.ForEach(x => x.IsDeleted = false);
                    var taskDeleteConditionIcdTenCodes = new List<Task>();
                    dbConditionIcdTenCodes.ForEach((conditionIcdTenCode) => taskDeleteConditionIcdTenCodes.Add(DeleteConditionIcdTenCode(conditionIcdTenCode)));

                    var condition = await _conditionIcdTenCodeRepositiory.GetAll().Where(x => dbConditions.Contains(x.Condition) && x.AdmissionStatus == RefListAdmissionStatuses.separated && x.IsDeleted == false).Select(x => x.Condition).FirstOrDefaultAsync()
                        ?? new Condition { RecordedDate = DateTime.Now, Subject = hisPatient, Recorder = currentLoggedInPerson, FhirEncounter = insertedWardAdmission, HospitalisationEncounter = insertedHospitalAdmission };

                    Condition insertedCondition = null;
                    //Create a condition
                    if (!Validation.IsValidateId(condition.Id))
                        insertedCondition = await _conditionRepositiory.InsertAsync(condition);

                    //Add newly updated icd10code
                    var taskConditionIcdTenCodes = new List<Task<EntityWithDisplayNameDto<Guid?>>>(); //Tasks lists to handle batch insert into database
                    input.SeparationCode.ForEach((v) => taskConditionIcdTenCodes.Add(CreateICdTenCode(v, condition ?? insertedCondition, true)));
                    var conditonIcdTenCodes = ((IList<EntityWithDisplayNameDto<Guid?>>)await Task.WhenAll(taskConditionIcdTenCodes)); //save contact points to db
                    icdTenCodeResponses = conditonIcdTenCodes.ToList();

                    //Create a diagnosis
                    var diagnosis = new Diagnosis
                    {
                        OwnerId = insertedHospitalAdmission.Id.ToString(),
                        OwnerType = insertedHospitalAdmission.GetTypeShortAlias(),
                        Condition = insertedCondition,
                    };
                    var insertedDiagnosis = await _diagnosisRepositiory.InsertAsync(diagnosis);
                }
            }

            return icdTenCodeResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        private async Task<EntityWithDisplayNameDto<Guid?>> CreateICdTenCode(EntityWithDisplayNameDto<Guid?> input, Condition condition, bool isSeparation = true)
        {
            ConditionIcdTenCode insertedConditionIcdTenCode = null;
            var icdTenCode = await _icdTenCodeRepositiory.GetAsync(input.Id.Value);
            using (var uow = _unitOfWork.Begin())
            {
                var conditionIcdTenCode = new HisConditionIcdTenCode
                {
                    Condition = condition,
                    IcdTenCode = icdTenCode,
                    AdmissionStatus = isSeparation == false ? RefListAdmissionStatuses.admitted : RefListAdmissionStatuses.separated

                };

                insertedConditionIcdTenCode = await _conditionIcdTenCodeRepositiory.InsertAsync(conditionIcdTenCode);
                uow.Complete();
            }

            return new EntityWithDisplayNameDto<Guid?>(icdTenCode.Id, $"{icdTenCode.ICDTenCode} {icdTenCode.WHOFullDesc}");
        }

    }
}
