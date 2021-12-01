using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.AutoMapper.Dto;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class SeparationCrudHelper : ISeparationCrudHelper, ITransientDependency
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
        private readonly IRepository<FhirOrganisation, Guid> _organisationRepositiory;

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
        public SeparationCrudHelper(
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
            IRepository<FhirOrganisation, Guid> organisationRepositiory,
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
            _organisationRepositiory = organisationRepositiory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        public async Task<SeparationResponse> CreateAsync(SeparationInput input, PersonFhirBase currentLoggedInPerson)
        {
            var encounterId = input.Id;
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(encounterId);

            HospitalAdmission hospitalAdmission = null;
            if (wardAdmission?.PartOf != null)
                hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);

            HisPatient hisPatient = null;
            if (wardAdmission?.Subject != null)
                hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);

            WardAdmission destinationWardAdmission = null;
            if (input.SeparationDestinationWard != null)
                destinationWardAdmission = _mapper.Map<WardAdmission>(input);
            else
                destinationWardAdmission = new WardAdmission();


            // var conditions = await _conditionRepositiory.GetAllListAsync(x => x.Subject == hisPatient);

            // await UpdateConditions(hisPatient, hospitalAdmission, input, currentLoggedInPerson);

            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.internalTransfer)
            {
                //var sourceWardAdmission = _mapper.Map<WardAdmission>(wardAdmission);
                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                wardAdmission.SeparationDestinationWard = new Ward();
                wardAdmission.SeparationDestinationWard.Id = input.SeparationDestinationWard.Id.Value;
                // var updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);



                //_mapper.Map(hisPatient, sourceWardAdmission);
                //Create ward admission record

                // destinationWardAdmission.Ward = new Ward();
                // destinationWardAdmission.PartOf = new Encounter();
                // destinationWardAdmission.InternalTransferOriginalWard = new WardAdmission();

                // destinationWardAdmission.PartOf = hospitalAdmission;
                // destinationWardAdmission.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                // destinationWardAdmission.AdmissionType = RefListAdmissionTypes.internalTransferIn;
                // destinationWardAdmission.Ward.Id = input.SeparationDestinationWard.Id.Value;
                // destinationWardAdmission.InternalTransferOriginalWard = wardAdmission;
                // _mapper.Map(hisPatient, destinationWardAdmission);
                //var insertedDestinationWardAdmission = await _wardAdmissionRepositiory.InsertAsync(destinationWardAdmission);



                // destinationWardAdmission.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                // destinationWardAdmission.AdmissionType = RefListAdmissionTypes.internalTransferIn;
                // destinationWardAdmission.InternalTransferOriginalWard = wardAdmission;
                // destinationWardAdmission.Ward.Id = input.SeparationDestinationWard.Id.Value;
                // _mapper.Map(hisPatient, hospitalAdmission);
                // if (destinationWardAdmission.PartOf == null)
                // _mapper.Map(wardAdmission.PartOf, destinationWardAdmission);
                // destinationWardAdmission.InternalTransferOriginalWard = wardAdmission;

                // var insertedDestinationWardAdmission = await _wardAdmissionRepositiory.InsertAsync(destinationWardAdmission);

                // wardAdmission.InternalTransferDestinationWard = insertedDestinationWardAdmission;
                // var updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                //Validation.ValidateNullableType(input?.SeparationDestinationWard, "Separation Destination Ward");
            }
            else if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.externalTransfer)
            {
                //var sourceWardAdmission = _mapper.Map<WardAdmission>(wardAdmission);
                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.separated;
                wardAdmission.SeparationType = RefListSeparationTypes.externalTransfer;
                await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                if (input.IsGautengGovFacility)
                {
                    hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.separated;
                    if (input.TransferToHospital.Id != null)
                        hospitalAdmission.TransferToHospital = await _organisationRepositiory.GetAsync((Guid)input.TransferToHospital.Id);
                    await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
                }
                else
                {
                    hospitalAdmission.TransferToNonGautengHospital = input.TransferToNonGautengHospital;
                    hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.separated;
                    await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
                }
            }
            else
            {
                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.separated;
                wardAdmission.SeparationType = (RefListSeparationTypes)input.SeparationType.ItemValue;
                await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.separated;
                await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
            }

            //var separationResponse = new SeparationResponse
            //{
            //    Patient = _mapper.Map<HisPatientResponse>(hisPatient),
            //    // WardAdmission = _mapper.Map<WardAdmissionResponse>(wardAdmission),
            //    // DestinationWardAdmission = _mapper.Map<WardAdmissionResponse>(destinationWardAdmission),
            //    // HospitalAdmission = _mapper.Map<AdmissionResponse>(hospitalAdmission)
            //};

            return new SeparationResponse();
        }

        // hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);
        private async Task UpdateConditions(HisPatient hisPatient, HospitalAdmission hospitalAdmission,
            SeparationInput input, PersonFhirBase currentLoggedInPerson)
        {
            //Create a condition
            var condition = new Condition
            {
                RecordedDate = DateTime.Now,
                Subject = hisPatient,
                Recorder = currentLoggedInPerson,
                //Asserter = currentLoggedInPerson,
                HospitalisationEncounter = hospitalAdmission
            };

            var insertedCondition = await _conditionRepositiory.InsertAsync(condition);
            //add a list of conditionIcdTenCode to a task
            List<EntityWithDisplayNameDto<Guid?>> icdTenCodeResponses = null;
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
                OwnerId = hisPatient.Id.ToString(),
                OwnerType = hisPatient.GetTypeShortAlias(),
                Condition = insertedCondition
            };
            var insertedDiagnosis = await _diagnosisRepositiory.InsertAsync(diagnosis);
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
