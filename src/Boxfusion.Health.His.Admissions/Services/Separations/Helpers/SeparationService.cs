using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Ardalis.GuardClauses;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using NHibernate.Linq;
using Shesha.AutoMapper.Dto;
using Shesha.Extensions;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class SeparationService : ISeparationService, ITransientDependency
    {
        private readonly IRepository<HisWard, Guid> _wardRepositiory;
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepositiory;
        private readonly IRepository<HisPatient, Guid> _hisPatientRepositiory;
        private readonly IRepository<Condition, Guid> _conditionRepositiory;
        private readonly IRepository<Diagnosis, Guid> _diagnosisRepositiory;
        private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepositiory;
        private readonly IRepository<ConditionIcdTenCode, Guid> _conditionIcdTenCodeRepositiory;
        private readonly IRepository<FhirOrganisation, Guid> _organisationRepositiory;

        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardRepositiory"></param>
        /// <param name="wardAdmissionRepositiory"></param>
        /// <param name="hospitalAdmissionRepositiory"></param>
        /// <param name="hisPatientRepositiory"></param>
        /// <param name="mapper"></param>
        /// <param name="conditionRepositiory"></param>
        /// <param name="diagnosisRepositiory"></param>
        /// <param name="icdTenCodeRepositiory"></param>
        /// <param name="conditionIcdTenCodeRepositiory"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="organisationRepositiory"></param>
        public SeparationService(IRepository<HisWard, Guid> wardRepositiory, IRepository<WardAdmission,
            Guid> wardAdmissionRepositiory, IRepository<HospitalAdmission, Guid> hospitalAdmissionRepositiory,
            IRepository<HisPatient, Guid> hisPatientRepositiory, IMapper mapper, 
            IRepository<Condition, Guid> conditionRepositiory, IRepository<Diagnosis, Guid> diagnosisRepositiory, 
            IRepository<IcdTenCode, Guid> icdTenCodeRepositiory, IRepository<ConditionIcdTenCode, Guid> conditionIcdTenCodeRepositiory,
            IUnitOfWorkManager unitOfWork, IRepository<FhirOrganisation, Guid> organisationRepositiory)
        {
            _wardRepositiory = wardRepositiory;
            _wardAdmissionRepositiory = wardAdmissionRepositiory;
            _hospitalAdmissionRepositiory = hospitalAdmissionRepositiory;
            _hisPatientRepositiory = hisPatientRepositiory;
            _mapper = mapper;
            _conditionRepositiory = conditionRepositiory;
            _diagnosisRepositiory = diagnosisRepositiory;
            _icdTenCodeRepositiory = icdTenCodeRepositiory;
            _conditionIcdTenCodeRepositiory = conditionIcdTenCodeRepositiory;
            _unitOfWork = unitOfWork;
            _organisationRepositiory = organisationRepositiory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        public async Task<AdmissionResponse> CreateAsync(SeparationInput input, PersonFhirBase currentLoggedInPerson)
        {


            var encounterId = input.Id;
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(encounterId);
            Guard.Against.Null(wardAdmission, nameof(wardAdmission));
            // wardAdmission = await GetEntityAsync<Encounter>(input.Id);

            HospitalAdmission hospitalAdmission = null;
            Guard.Against.Null(wardAdmission.PartOf, nameof(wardAdmission.PartOf));
            hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);
            Guard.Against.Null(hospitalAdmission, nameof(hospitalAdmission));


            // HisPatient hisPatient = null;
            Guard.Against.Null(wardAdmission.Subject, nameof(wardAdmission.Subject));
            var hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);
            Guard.Against.Null(hisPatient, nameof(hisPatient));

            if (hisPatient.DateOfBirth.HasValue)
            {
                var agebreakdown = AgeBreakdown(hisPatient.DateOfBirth.Value, input.SeparationDate.Value);
                if (agebreakdown != "12 - 59 months")
                { }
                else if (agebreakdown != "5-12 years")
                { }
                else
                {
                    Validation.ValidateReflist(input?.SeparationChildHealth, "Separation Child Health");
                    wardAdmission.SeparationChildHealth = (RefListSeparationChildHealths)input.SeparationChildHealth.ItemValue;
                }
            }

            wardAdmission.AdmissionStatus = RefListAdmissionStatuses.separated;
            wardAdmission.SeparationDate = input?.SeparationDate.Value;
            wardAdmission.SeparationComment = input.SeparationComment;
            wardAdmission.SeparationType = (RefListSeparationTypes?)input.SeparationType.ItemValue;

            WardAdmission destinationWardAdmission = null;
            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.internalTransfer)
            {
                var separationDestinationWard = await _wardRepositiory.GetAsync(input.SeparationDestinationWard.Id.Value);
                wardAdmission.SeparationDestinationWard = separationDestinationWard;

                wardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                //Create destination ward admission record
                if (input.SeparationDestinationWard != null)
                    destinationWardAdmission = _mapper.Map<WardAdmission>(input);

                destinationWardAdmission.PartOf = hospitalAdmission;
                destinationWardAdmission.AdmissionStatus = RefListAdmissionStatuses.inTransit;
                destinationWardAdmission.AdmissionType = RefListAdmissionTypes.internalTransferIn;
                destinationWardAdmission.Ward = separationDestinationWard; // input.SeparationDestinationWard.Id.Value;
                destinationWardAdmission.InternalTransferOriginalWard = wardAdmission;
                // destinationWardAdmission.wa
                _mapper.Map(hisPatient, destinationWardAdmission);
                var insertedDestinationWardAdmission = await _wardAdmissionRepositiory.InsertAsync(destinationWardAdmission);
                var _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
                await _unitOfWork.Current.SaveChangesAsync();
                await _sessionProvider.Session.Transaction.CommitAsync();


                wardAdmission.InternalTransferDestinationWard = insertedDestinationWardAdmission;
                wardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);
            }
            else if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.externalTransfer)
            {
                //var sourceWardAdmission = _mapper.Map<WardAdmission>(wardAdmission);
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
                wardAdmission.SeparationType = (RefListSeparationTypes)input.SeparationType.ItemValue;
                await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.separated;
                await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
            }

            if (destinationWardAdmission == null)
                await UpdateConditions(hisPatient, hospitalAdmission, input, currentLoggedInPerson, wardAdmission);
            else
                await UpdateConditions(hisPatient, hospitalAdmission, input, currentLoggedInPerson, destinationWardAdmission);

            var admissionResponse = _mapper.Map<AdmissionResponse>(hisPatient);
            _mapper.Map(wardAdmission, admissionResponse);
            _mapper.Map(hospitalAdmission, admissionResponse);


            if (hisPatient.DateOfBirth.HasValue && input.SeparationDate.HasValue)
                admissionResponse.AgeBreakdown = AgeBreakdown(hisPatient.DateOfBirth.Value, input.SeparationDate.Value);

            var codes = await GetCodes(wardAdmission);
            UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);

            if (destinationWardAdmission != null)
            {
                var separationCodes = GetCodes(destinationWardAdmission);
                UtilityHelper.TrySetProperty(admissionResponse, "SeparationCode", separationCodes);
            }
            else
            {
                UtilityHelper.TrySetProperty(admissionResponse, "SeparationCode", codes);
            }


            //var conditions = await _conditionRepositiory.GetAllListAsync(x => x.HospitalisationEncounter == hospitalAdmission);

            //List<ConditionIcdTenCode> conditionIcdTenCodes = null;
            //List<IcdTenCode> icdTenCodes = null;
            //if (conditions.Count() > 0)
            //{
            //    conditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => conditions.Contains(x.Condition));

            //    var temp = conditionIcdTenCodes.Select(x => x.IcdTenCode.Id).ToList();
            //    if (conditionIcdTenCodes.Count() > 0)
            //        icdTenCodes = await _icdTenCodeRepositiory.GetAll().Where(x => temp.Contains(x.Id)).ToListAsync();
            //}

            //List<EntityWithDisplayNameDto<Guid?>> codes = new List<EntityWithDisplayNameDto<Guid?>>();
            //List<EntityWithDisplayNameDto<Guid?>> separationCodes = new List<EntityWithDisplayNameDto<Guid?>>();

            //codes.Add(new EntityWithDisplayNameDto<Guid?>(icdTenCodes.FirstOrDefault().Id, icdTenCodes.FirstOrDefault().ICDTenThreeCodeDesc));
            //UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);

            //if (icdTenCodes.Count > 1)
            //{
            //    separationCodes.Add(new EntityWithDisplayNameDto<Guid?>(icdTenCodes.LastOrDefault().Id, icdTenCodes.LastOrDefault().ICDTenThreeCodeDesc));
            //    UtilityHelper.TrySetProperty(admissionResponse, "SeparationCode", separationCodes);
            //}

            return admissionResponse;
        }

        /*public async Task<AdmissionResponse> UndoAdmission(Guid admissionId, PersonFhirBase currentLoggedInPerson)
        {
            var encounterId = admissionId;
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(encounterId);
            Guard.Against.Null(wardAdmission, nameof(wardAdmission));
            // wardAdmission = await GetEntityAsync<Encounter>(input.Id);

            HospitalAdmission hospitalAdmission = null;
            Guard.Against.Null(wardAdmission.PartOf, nameof(wardAdmission.PartOf));
            hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);
            Guard.Against.Null(hospitalAdmission, nameof(hospitalAdmission));


            // HisPatient hisPatient = null;
            Guard.Against.Null(wardAdmission.Subject, nameof(wardAdmission.Subject));
            var hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);
            Guard.Against.Null(hisPatient, nameof(hisPatient));

            wardAdmission.AdmissionStatus = null;
            wardAdmission.SeparationDate = null;
            wardAdmission.SeparationComment = null;

            if (wardAdmission.SeparationType == RefListSeparationTypes.internalTransfer)
            {
                // var separationDestinationWard = await _wardRepositiory.GetAsync(input.SeparationDestinationWard.Id.Value);
                wardAdmission.SeparationDestinationWard = null;
                wardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);
                WardAdmission destinationWardAdmission = null;
                destinationWardAdmission = await _wardAdmissionRepositiory.GetAsync(wardAdmission.InternalTransferDestinationWard.Id);
                await _wardAdmissionRepositiory.DeleteAsync(destinationWardAdmission);

                wardAdmission.InternalTransferDestinationWard = null;
                wardAdmission = await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);
            }
            else if (wardAdmission.SeparationType == RefListSeparationTypes.externalTransfer)
            {
                //var sourceWardAdmission = _mapper.Map<WardAdmission>(wardAdmission);
                wardAdmission.SeparationType = null;
                await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                if (hospitalAdmission.TransferToHospital.Id != null)
                {
                    hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted;
                    hospitalAdmission.TransferToHospital = null;
                    await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
                }
                else
                {
                    hospitalAdmission.TransferToNonGautengHospital = null;
                    hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted;
                    await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
                }
            }
            else
            {
                wardAdmission.SeparationType = null;
                await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted;
                await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
            }

            var admissionResponse = _mapper.Map<AdmissionResponse>(hisPatient);
            _mapper.Map(wardAdmission, admissionResponse);
            _mapper.Map(hospitalAdmission, admissionResponse);


            if (hisPatient.DateOfBirth.HasValue && input.SeparationDate.HasValue)
                admissionResponse.AgeBreakdown = AgeBreakdown(hisPatient.DateOfBirth.Value, input.SeparationDate.Value);

            var conditions = await _conditionRepositiory.GetAllListAsync(x => x.HospitalisationEncounter == hospitalAdmission);

            List<ConditionIcdTenCode> conditionIcdTenCodes = null;
            List<IcdTenCode> icdTenCodes = null;
            if (conditions.Count() > 0)
            {
                conditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => conditions.Contains(x.Condition));

                var temp = conditionIcdTenCodes.Select(x => x.IcdTenCode.Id).ToList();
                if (conditionIcdTenCodes.Count() > 0)
                    icdTenCodes = await _icdTenCodeRepositiory.GetAll().Where(x => temp.Contains(x.Id)).ToListAsync();
            }
            List<EntityWithDisplayNameDto<Guid?>> codes = new List<EntityWithDisplayNameDto<Guid?>>();
            icdTenCodes.ForEach(icdTenCode => codes.Add(new EntityWithDisplayNameDto<Guid?>(icdTenCode.Id, icdTenCode.ICDTenThreeCodeDesc)));

            UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);


            return admissionResponse;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admissionId"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        public async Task<AdmissionResponse> UndoSeparation(Guid admissionId, PersonFhirBase currentLoggedInPerson)
        {
            var encounterId = admissionId;
            var wardAdmission = await _wardAdmissionRepositiory.GetAsync(encounterId);
            Guard.Against.Null(wardAdmission, nameof(wardAdmission));
            // wardAdmission = await GetEntityAsync<Encounter>(input.Id);

            HospitalAdmission hospitalAdmission = null;
            Guard.Against.Null(wardAdmission.PartOf, nameof(wardAdmission.PartOf));
            hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);
            Guard.Against.Null(hospitalAdmission, nameof(hospitalAdmission));


            // HisPatient hisPatient = null;
            Guard.Against.Null(wardAdmission.Subject, nameof(wardAdmission.Subject));
            var hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);
            Guard.Against.Null(hisPatient, nameof(hisPatient));

            if (wardAdmission.SeparationType == RefListSeparationTypes.internalTransfer)
            {
                Guard.Against.Null(wardAdmission.InternalTransferOriginalWard, nameof(wardAdmission.InternalTransferOriginalWard));
                var originalWardAdmission = await _wardAdmissionRepositiory.GetAsync(wardAdmission.InternalTransferOriginalWard.Id);


                originalWardAdmission.AdmissionStatus = null;
                originalWardAdmission.SeparationDate = null;
                originalWardAdmission.SeparationComment = null;

                originalWardAdmission.SeparationDestinationWard = null;
                originalWardAdmission.InternalTransferDestinationWard = null;
                originalWardAdmission.AdmissionStatus = RefListAdmissionStatuses.admitted;
                originalWardAdmission = await _wardAdmissionRepositiory.UpdateAsync(originalWardAdmission);
                encounterId = originalWardAdmission.Id;

                await _wardAdmissionRepositiory.DeleteAsync(wardAdmission);
                await _wardAdmissionRepositiory.UpdateAsync(originalWardAdmission);

            }
            else if (wardAdmission.SeparationType == RefListSeparationTypes.externalTransfer)
            {
                //var sourceWardAdmission = _mapper.Map<WardAdmission>(wardAdmission);
                wardAdmission.SeparationType = null;
                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.admitted;
                await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                if (hospitalAdmission.TransferToHospital.Id != null)
                {
                    hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted;
                    hospitalAdmission.TransferToHospital = null;
                    await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
                }
                else
                {
                    hospitalAdmission.TransferToNonGautengHospital = null;
                    hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted;
                    await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
                }
            }
            else
            {
                wardAdmission.SeparationType = null;
                wardAdmission.AdmissionStatus = RefListAdmissionStatuses.admitted;
                await _wardAdmissionRepositiory.UpdateAsync(wardAdmission);

                hospitalAdmission.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted;
                await _hospitalAdmissionRepositiory.UpdateAsync(hospitalAdmission);
            }


            var _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
            await _unitOfWork.Current.SaveChangesAsync();
            await _sessionProvider.Session.Transaction.CommitAsync();

            wardAdmission = await _wardAdmissionRepositiory.GetAsync(encounterId);
            Guard.Against.Null(wardAdmission, nameof(wardAdmission));
            // wardAdmission = await GetEntityAsync<Encounter>(input.Id);

            hospitalAdmission = null;
            Guard.Against.Null(wardAdmission.PartOf, nameof(wardAdmission.PartOf));
            hospitalAdmission = await _hospitalAdmissionRepositiory.GetAsync(wardAdmission.PartOf.Id);
            Guard.Against.Null(hospitalAdmission, nameof(hospitalAdmission));


            // HisPatient hisPatient = null;
            Guard.Against.Null(wardAdmission.Subject, nameof(wardAdmission.Subject));
            hisPatient = await _hisPatientRepositiory.GetAsync(wardAdmission.Subject.Id);
            Guard.Against.Null(hisPatient, nameof(hisPatient));

            var admissionResponse = _mapper.Map<AdmissionResponse>(hisPatient);
            _mapper.Map(wardAdmission, admissionResponse);
            _mapper.Map(hospitalAdmission, admissionResponse);
            List<EntityWithDisplayNameDto<Guid?>> codes = await GetCodes(wardAdmission);
            UtilityHelper.TrySetProperty(admissionResponse, "Code", codes);
            return admissionResponse;

        }

        private async Task<List<EntityWithDisplayNameDto<Guid?>>> GetCodes(WardAdmission wardAdmission)
        {
            var conditions = await _conditionRepositiory.GetAllListAsync(x => x.FhirEncounter == wardAdmission);

            List<ConditionIcdTenCode> conditionIcdTenCodes = null;
            List<IcdTenCode> icdTenCodes = null;
            if (conditions.Count() > 0)
            {
                conditionIcdTenCodes = await _conditionIcdTenCodeRepositiory.GetAllListAsync(x => conditions.Contains(x.Condition));

                var temp = conditionIcdTenCodes.Select(x => x.IcdTenCode.Id).ToList();
                if (conditionIcdTenCodes.Count() > 0)
                    icdTenCodes = await _icdTenCodeRepositiory.GetAll().Where(x => temp.Contains(x.Id)).ToListAsync();
            }

            List<EntityWithDisplayNameDto<Guid?>> codes = new List<EntityWithDisplayNameDto<Guid?>>();

            if (icdTenCodes != null)
                icdTenCodes.ForEach(icdTenCode => codes.Add(new EntityWithDisplayNameDto<Guid?>(icdTenCode.Id, icdTenCode.ICDTenThreeCodeDesc)));

            return codes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hisPatient"></param>
        /// <param name="hospitalAdmission"></param>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <param name="wardAdmission"></param>
        /// <returns></returns>
        private async Task UpdateConditions(HisPatient hisPatient, HospitalAdmission hospitalAdmission,
            SeparationInput input, PersonFhirBase currentLoggedInPerson, WardAdmission wardAdmission)
        {
            //Create a condition
            var condition = new Condition
            {
                RecordedDate = DateTime.Now,
                Subject = hisPatient,
                Recorder = currentLoggedInPerson,
                FhirEncounter = wardAdmission,
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
            var _sessionProvider = Abp.Dependency.IocManager.Instance.Resolve<ISessionProvider>();
            await _unitOfWork.Current.SaveChangesAsync();
            await _sessionProvider.Session.Transaction.CommitAsync();
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

    }
}
