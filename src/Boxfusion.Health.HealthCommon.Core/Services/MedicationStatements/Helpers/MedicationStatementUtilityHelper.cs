using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Enums;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Notes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationStatements.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public class MedicationStatementUtilityHelper
	{
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refListFilterIdType"></param>
        /// <param name="filterId"></param>
        /// <returns></returns>
		public static async Task<List<MedicationStatementResponse>> GetAllMedicationsStatementsWithBackboneElements(RefListFilterIdType refListFilterIdType, Guid filterId)
		{
            var repository = IocManager.Instance.Resolve<IRepository<MedicationStatement, Guid>>();
            var noteRepository = IocManager.Instance.Resolve<IRepository<Note, Guid>>();
            var dosageRepository = IocManager.Instance.Resolve<IRepository<Dosage, Guid>>();
            var mapper = IocManager.Instance.Resolve<IMapper>();

            var entityList = new List<MedicationStatement>();

			switch (refListFilterIdType)
			{
				case RefListFilterIdType.patientId:
                    entityList = await repository.GetAllListAsync(a => a.Subject.Id == filterId);
                        break;
                case RefListFilterIdType.practitionerId:
                    entityList = await repository.GetAllListAsync(a => a.InformationSource.Id == filterId);
                    break;
				default:
                    entityList = await repository.GetAllListAsync();
                    break;
			}

            #region Gets all entitities together with their relations
            var entityResultList = (from entity in entityList
                                    select new MedicationStatementResponse()
                                    {
                                        Id = entity.Id,
                                        BasedOnOwnerId = entity.BasedOnOwnerId,
                                        BasedOnOwnerType = entity.BasedOnOwnerType,
                                        PartOfOwnerId = entity.PartOfOwnerId,
                                        PartOfOwnerType = entity.PartOfOwnerType,
                                        Status = new ReferenceListItemValueDto() { ItemValue = (long?)entity.Status },
                                        StatusReason = UtilityHelper.GetMultiReferenceListItemValueList(entity.StatusReason),
                                        Category = new ReferenceListItemValueDto() { ItemValue = (long?)entity.Category },
                                        MedicationCodeableConcept = new ReferenceListItemValueDto() { ItemValue = (long?)entity.MedicationCodeableConcept },
                                        MedicationReference = new EntityWithDisplayNameDto<Guid?>(entity.MedicationReference?.Id, UtilityHelper.GetRefListItemText("Fhir", "ReasonMedicationStatusCodes", entity.MedicationReference?.Code != null ? (long?)entity.MedicationReference?.Code.Value : null)),
                                        MedicationText = entity.MedicationText,
                                        Subject = new EntityWithDisplayNameDto<Guid?>(entity.Subject?.Id, entity.Subject?.FullName),
                                        ContextOwnerId = entity.ContextOwnerId,
                                        ContextOwnerType = entity.ContextOwnerType,
                                        EffectiveDateTime = entity.EffectiveDateTime,
                                        EffectivePeriodStart = entity.EffectivePeriodStart,
                                        EffectivePeriodEnd = entity.EffectivePeriodEnd,
                                        DateAsserted = entity.DateAsserted,
                                        InformationSource = new EntityWithDisplayNameDto<Guid?>(entity.InformationSource?.Id, entity.InformationSource?.FullName),
                                        DerivedFromOwnerId = entity.DerivedFromOwnerId,
                                        DerivedFromOwnerType = entity.DerivedFromOwnerType,
                                        ReasonCode = UtilityHelper.GetMultiReferenceListItemValueList(entity.ReasonCode),
                                        ReasonReferenceOwnerId = entity.ReasonReferenceOwnerId,
                                        ReasonReferenceOwnerType = entity.ReasonReferenceOwnerType,
                                        Notes = (from note in noteRepository.GetAll().ToList()
                                                 where (note.OwnerId == entity.Id.ToString())
                                                 select new NoteDto()
                                                 {
                                                     Id = entity.Id,
                                                     OwnerId = note.OwnerId,
                                                     OwnerType = note.OwnerType,
                                                     NoteText = note.NoteText,
                                                     Author = new EntityWithDisplayNameDto<Guid>((Guid)(note.Author?.Id), note.Author?.FullName),
                                                 }).ToList(),
                                        Dosage = (from dosage in dosageRepository.GetAll().ToList()
                                                  where (dosage.OwnerId == entity.Id.ToString())
                                                  select new DosageResponse()
                                                  {
                                                      Id = entity.Id,
                                                      Sequence = dosage.Sequence,
                                                      Text = dosage.Text,
                                                      AdditionalInstruction = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.AdditionalInstruction },
                                                      ParentInstruction = dosage.ParentInstruction,
                                                      TimingEvent = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.TimingEvent },
                                                      TimingRepeatBoundsDuration = dosage.TimingRepeatBoundsDuration,
                                                      TimingRepeatBoundsRangeLow = dosage.TimingRepeatBoundsRangeLow,
                                                      TimingRepeatBoundsRangeHigh = dosage.TimingRepeatBoundsRangeHigh,
                                                      TimingRepeatBoundsPeriodStart = dosage.TimingRepeatBoundsPeriodStart,
                                                      TimingRepeatBoundsPeriodEnd = dosage.TimingRepeatBoundsPeriodEnd,
                                                      TimingRepeatCount = dosage.TimingRepeatCount,
                                                      TimingRepeatCountMax = dosage.TimingRepeatCountMax,
                                                      TimingRepeatDuration = dosage.TimingRepeatDuration,
                                                      TimingRepeatDurationMax = dosage.TimingRepeatDurationMax,
                                                      TimingRepeatDurationUnit = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.TimingRepeatDurationUnit },
                                                      TimingRepeatFrequency = dosage.TimingRepeatFrequency,
                                                      TimingRepeatFrequencyMax = dosage.TimingRepeatFrequencyMax,
                                                      TimingRepeatPeriod = dosage.TimingRepeatPeriod,
                                                      TimingRepeatPeriodMax = dosage.TimingRepeatPeriodMax,
                                                      TimingRepeatPeriodUnit = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.TimingRepeatPeriodUnit },
                                                      TimingRepeatDayOfWeek = UtilityHelper.GetMultiReferenceListItemValueList(dosage.TimingRepeatDayOfWeek),
                                                      TimingRepeatTimeOfDay = UtilityHelper.GetMultiReferenceListItemValueList(dosage.TimingRepeatTimeOfDay),
                                                      TimingRepeatWhen = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.TimingRepeatWhen },
                                                      TimingRepeatOffSet = dosage.TimingRepeatOffSet,
                                                      TimingCode = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.TimingCode },
                                                      AsNeeded = dosage.AsNeeded,
                                                      AsNeededBoolean = dosage.AsNeededBoolean,
                                                      AsNeededCodeableConcept = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.AsNeededCodeableConcept },
                                                      Site = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.Site },
                                                      Route = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.Route },
                                                      Method = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.Method },
                                                      DosageAndRateType = new ReferenceListItemValueDto() { ItemValue = (long?)dosage.DosageAndRateType },
                                                      DosageAndRateDoseRangeStart = dosage.DosageAndRateDoseRangeStart,
                                                      DosageAndRateDoseRangeEnd = dosage.DosageAndRateDoseRangeEnd,
                                                      DosageAndRateDoseQuantity = dosage.DosageAndRateDoseQuantity,
                                                      DosageAndRateRateRationNumerator = dosage.DosageAndRateRateRationNumerator,
                                                      DosageAndRateRateRatioDenominator = dosage.DosageAndRateRateRatioDenominator,
                                                      DosageAndRateRangeStart = dosage.DosageAndRateRangeStart,
                                                      DosageAndRateRangeEnd = dosage.DosageAndRateRangeEnd,
                                                      DosageAndRateRateQuantity = dosage.DosageAndRateRateQuantity,
                                                      MaxDosePerPeriodStart = dosage.MaxDosePerPeriodStart,
                                                      MaxDosePerPeriodEnd = dosage.MaxDosePerPeriodEnd,
                                                      MaxDosePerAdministration = dosage.MaxDosePerAdministration,
                                                      MaxDosePerLifetime = dosage.MaxDosePerLifetime,
                                                      OwnerId = dosage.OwnerId,
                                                      OwnerType = dosage.OwnerType
                                                  }).ToList()
                                    });
            #endregion

            var result = entityResultList.ToList();
            return result;
        }

	}
}
