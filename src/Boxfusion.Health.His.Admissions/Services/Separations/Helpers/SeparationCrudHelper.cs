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
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Boxfusion.Health.His.Domain.Dtos;
using System;
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

            WardAdmission destinationWard = null;
            if (input.SeparationDestinationWard != null)
                destinationWard = _mapper.Map<WardAdmission>(input);
            else
                destinationWard = new WardAdmission();


            var conditions = await _conditionRepositiory.GetAllListAsync(x => x.Subject == hisPatient);

            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.internalTransfer)
            {
                //var sourceWardAdmission = _mapper.Map<WardAdmission>(wardAdmission);
                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                wardAdmission.SeparationDestinationWard.Id = input.SeparationDestinationWard.Id.Value;



                //_mapper.Map(hisPatient, sourceWardAdmission);
                var updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);
                destinationWard.Ward = new Ward();

                destinationWard.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                destinationWard.AdmissionType = RefListAdmissionTypes.internalTransferIn;
                destinationWard.InternalTransferOriginalWard = wardAdmission;
                destinationWard.Ward.Id = input.SeparationDestinationWard.Id.Value;
                _mapper.Map(hisPatient, hospitalAdmission);
                if (wardAdmission?.PartOf == null)
                    _mapper.Map(wardAdmission.PartOf, destinationWard);
                destinationWard.InternalTransferOriginalWard = wardAdmission;

                var destinationWardAdmission = await _wardAdmissionRepositiory.InsertAsync(destinationWard);

                wardAdmission.InternalTransferDestinationWard = destinationWardAdmission;

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

            var separationResponse = new SeparationResponse
            {
                Patient = _mapper.Map<HisPatientResponse>(hisPatient),
                WardAdmission = _mapper.Map<WardAdmissionResponse>(wardAdmission),
                DestinationWardAdmission = _mapper.Map<WardAdmissionResponse>(destinationWard),
                HospitalAdmission = _mapper.Map<AdmissionResponse>(hospitalAdmission)
            };

            return separationResponse;
        }
    }
}
