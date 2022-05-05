﻿using Abp.Domain.Repositories;
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
using Boxfusion.Health.His.Common.Domain.Domain.Diagnoses;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.His.Common.Domain.Domain.ConditionIcdTenCodes;
using Shesha.Domain;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Admissions
{
    /// <summary>
    ///  Domain Service for the Admission entity.
    /// </summary>
    public class AdmissionsManager : DomainService
    {
        private readonly DiagnosisManager _diagnosisManager;
        private readonly ConditionIcdTenCodeManager _conditionIcdTenCodeManager;
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepositiory;
        private readonly IRepository<HisWard, Guid> _wardRepositiory;


        private readonly IPatientCrudHelper<HisPatient, NonUserCdmPatientResponse> _patientCrudHelper;
        private readonly IRepository<EncounterLocation, Guid> _encounterLocationRepositiory;
        private readonly IRepository<HisConditionIcdTenCode, Guid> _conditionIcdTenCodeRepositiory;
        private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepositiory;
        private readonly IRepository<Condition, Guid> _conditionRepositiory;
        private readonly IRepository<Diagnosis, Guid> _diagnosisRepositiory;
        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
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
		/// <param name="diagnosisManager"></param>
		/// <param name="conditionIcdTenCodeManager"></param>
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
            IMapper mapper,
            DiagnosisManager diagnosisManager,
            ConditionIcdTenCodeManager conditionIcdTenCodeManager)
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
            _diagnosisManager = diagnosisManager;
            _conditionIcdTenCodeManager = conditionIcdTenCodeManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WardAdmission> GetWardAdmissionAsync(Guid id)
        {
            return await _wardAdmissionRepositiory.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HospitalAdmission> GetHospitalAdmissionAsync(Guid id)
        {
            return await _hospitalAdmissionRepositiory.GetAsync(id);
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
            var ward = await _wardRepositiory.GetAsync(wardId);

            return wardAdmissionCount.Count() >= ward.NumberOfBeds;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardAdmission"></param>
		/// <param name="hospitalAdmission"></param>
		/// <param name="codes"></param>
		/// <returns></returns>
		public async Task<WardAdmission> AdmitPatientAsync(WardAdmission wardAdmission, HospitalAdmission hospitalAdmission, List<IcdTenCode> codes)
        {
            //Create hospital admission
            var hospitalAdmissionEntity = await _hospitalAdmissionRepositiory.InsertAsync(hospitalAdmission);

            //Create ward admission record
            wardAdmission.PartOf = hospitalAdmissionEntity;
            wardAdmission.AdmissionStatus = RefListAdmissionStatuses.admitted;
            var wardAdmissionEntity = await _wardAdmissionRepositiory.InsertAsync(wardAdmission);

            #region Make a diagnosis for the admission
            //If there's existing codes create a diagnosis
            if (codes.Any())
                await MakeADiagnosis(wardAdmissionEntity, codes, RefListEncounterDiagnosisRoles.AD, RefListAdmissionStatuses.admitted);
            #endregion

            return wardAdmissionEntity;
        }
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmission"></param>
        /// <param name="hospitalAdmission"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
		public async Task<WardAdmission> UpdateAsync(WardAdmission wardAdmission, HospitalAdmission hospitalAdmission, List<IcdTenCode> codes)
        {
            var updatedWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

            HospitalAdmission updatedHospitalAdmission = null;
            if (wardAdmission.PartOf is not null)
                updatedHospitalAdmission = await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);

            #region Adds new or update an existing diagnosis
            var diagnosis = await _diagnosisRepositiory.FirstOrDefaultAsync(a => a.OwnerId == updatedWardAdmission.Id.ToString());

            if (diagnosis is not null)
                await UpdateDiagnosis(diagnosis, updatedWardAdmission, codes);
            else
                if (codes.Any()) await MakeADiagnosis(updatedWardAdmission, codes, RefListEncounterDiagnosisRoles.AD, RefListAdmissionStatuses.admitted);
            #endregion

            return updatedWardAdmission;
        }

		/// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmission"></param>
        /// <param name="hospitalAdmission"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
		public async Task<WardAdmission> SeparatePatientAsync(WardAdmission wardAdmission, HospitalAdmission hospitalAdmission, List<IcdTenCode> codes)
        {
            wardAdmission.AdmissionStatus = RefListAdmissionStatuses.separated;
            var separatedAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

            #region Make a diagnosis for separation
            //Checks for an exisisting Diagnosis that may have been made on an undone-separation(check UndoSeparation() method)
            var diagnosis = await _diagnosisRepositiory.FirstOrDefaultAsync(a => a.OwnerId == separatedAdmission.Id.ToString() &&
                                                                            a.Use == (int)RefListEncounterDiagnosisRoles.DD);

            if (diagnosis is not null)
                await UpdateDiagnosis(diagnosis, separatedAdmission, codes);
            else if (codes.Any())
                await MakeADiagnosis(separatedAdmission, codes, RefListEncounterDiagnosisRoles.DD, RefListAdmissionStatuses.separated);
            #endregion

            if (wardAdmission?.SeparationType == RefListSeparationTypes.internalTransfer)
            {
                //Create ward admission record
                WardAdmission newAdmission = wardAdmission;
                newAdmission.Id = Guid.Empty;
                newAdmission.PartOf = hospitalAdmission;
                newAdmission.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                newAdmission.InternalTransferOriginalWard = separatedAdmission;
                var insertedWardAdmission = await _wardAdmissionRepositiory.InsertAsync(newAdmission);

                #region Make a diagnosis for the internal new admission
                //If there's existing codes create a diagnosis
                if (codes.Any())
                    await MakeADiagnosis(newAdmission, codes, RefListEncounterDiagnosisRoles.AD, RefListAdmissionStatuses.admitted);
                #endregion
            }
            else
            {
                hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.separated;
                await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
            }

            return separatedAdmission;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardAdmissionId"></param>
		/// <param name="person"></param>
		/// <returns></returns>
		public async Task<WardAdmission> UndoSeparation(Guid wardAdmissionId, Person person)
        {
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(wardAdmissionId);
            var hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);


            wardAdmission.AdmissionStatus = RefListAdmissionStatuses.admitted;
            wardAdmission.Performer = person;
            var reAdmissionEntity = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

            if (wardAdmission?.SeparationType == RefListSeparationTypes.internalTransfer)
            {
                await UndoWardInternalTransfer(wardAdmission);
            }
            else
            {
                hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted;
                await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
            }

            return reAdmissionEntity;
        }

		private async Task UndoWardInternalTransfer(WardAdmission wardAdmission)
		{
            var transferedAdmission = await _wardAdmissionRepositiory.GetAsync(wardAdmission.InternalTransferDestinationWard.Id);
            if (transferedAdmission.AdmissionStatus == RefListAdmissionStatuses.separated)
                throw new UserFriendlyException($"Can't undo-separation, because patient already separated from transfered ward: {transferedAdmission.Ward.Name}");

            if (Validation.IsValidateId(wardAdmission?.InternalTransferDestinationWard?.Id))
            {
                await _wardAdmissionRepositiory.DeleteAsync(transferedAdmission);

                var diagnosis = await _diagnosisRepositiory.FirstOrDefaultAsync(a => a.OwnerId == transferedAdmission.Id.ToString());
                await _diagnosisManager.DeleteDiagnosis(diagnosis.Id);

                await _conditionIcdTenCodeManager.DeleteAssignment<HisConditionIcdTenCode>(diagnosis.Condition);
            }
        }

		private async Task MakeADiagnosis(WardAdmission wardAdmissionEntity, List<IcdTenCode> codes, RefListEncounterDiagnosisRoles use, RefListAdmissionStatuses status)
        {
            var diagnosisEntity = await _diagnosisManager.AddNewDiagnosis<WardAdmission, Condition>(wardAdmissionEntity,
                                          (int)use, null,
                                          //prepares the condtion of this diagnosis
                                          async item =>
                                          {
                                              item.RecordedDate = DateTime.Now;
                                              item.Subject = wardAdmissionEntity.Subject;
                                              item.Recorder = (PersonFhirBase)wardAdmissionEntity.Performer;
                                              item.FhirEncounter = wardAdmissionEntity;
                                              item.HospitalisationEncounter = (HospitalisationEncounter)wardAdmissionEntity.PartOf;
                                          });

            await _conditionIcdTenCodeManager.AssignIcdTenCodeToCondition<HisConditionIcdTenCode>(codes, diagnosisEntity.Condition,
                                                                        //(Optional) extra values required in ConditionIcdTenCode sub-entities
                                                                        async item =>
                                                                        {
                                                                            item.AdmissionStatus = status;
                                                                        });
        }

        private async Task UpdateDiagnosis(Diagnosis diagnosis, WardAdmission updatedWardAdmission, List<IcdTenCode> codes)
        {
            var updatedDiagnosis = await _diagnosisManager.UpdateDiagnosis<Condition>(diagnosis, 
                                                            async item => 
                                                            {
                                                                item.RecordedDate = DateTime.Now;
                                                                item.Subject = updatedWardAdmission.Subject;
                                                                item.Recorder = (PersonFhirBase)updatedWardAdmission.Performer;
                                                            });

            await _conditionIcdTenCodeManager.UpdateAssignedIcdTenCodes<HisConditionIcdTenCode>(codes, diagnosis.Condition);
        }

    }
}
