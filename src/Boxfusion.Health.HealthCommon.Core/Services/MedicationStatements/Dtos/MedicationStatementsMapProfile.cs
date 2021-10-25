using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationStatements.Dtos
{
    /// <summary>
    /// 
    /// </summary>
	public class MedicationStatementsMapProfile: ShaProfile
	{
        /// <summary>
        /// 
        /// </summary>
		public MedicationStatementsMapProfile()
		{
            //MedicationStatement
            CreateMap<MedicationStatementInput, MedicationStatement>()
                .ForMember(a => a.MedicationReference, options => options.MapFrom(b => b.MedicationReference != null ? GetEntity<Medication>(b.MedicationReference.Id) : null))
                .ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? GetEntity<Patient>(b.Subject.Id) : null))
                .ForMember(a => a.InformationSource, options => options.MapFrom(b => b.InformationSource != null ? GetEntity<PersonFhirBase>(b.InformationSource.Id) : null))
                .ForMember(a => a.StatusReason, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.StatusReason)))
                .ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.ReasonCode)))
                .MapReferenceListValuesFromDto();

            CreateMap<MedicationStatement, MedicationStatementResponse>()
                .ForMember(a => a.MedicationReference, options => options.MapFrom(b => b.MedicationReference != null ? new EntityWithDisplayNameDto<Guid?>(b.MedicationReference.Id, UtilityHelper.GetRefListItemText("Fhir", "ReasonMedicationStatusCodes", (long?)b.MedicationReference.Code)) : null))
                .ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, $"{b.Subject.FirstName} {b.Subject.LastName}") : null))
                .ForMember(a => a.InformationSource, options => options.MapFrom(b => b.InformationSource != null ? new EntityWithDisplayNameDto<Guid?>(b.InformationSource.Id, $"{b.InformationSource.FirstName} {b.InformationSource.LastName}") : null))
                .ForMember(a => a.StatusReason, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.StatusReason)))
                .ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.ReasonCode)))
                .MapReferenceListValuesToDto();

            //Dosage
            CreateMap<DosageInput, Dosage>()
                .ForMember(a => a.TimingEvent, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.TimingEvent)))
                .ForMember(a => a.TimingRepeatDayOfWeek, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.TimingRepeatDayOfWeek)))
                .ForMember(a => a.TimingRepeatTimeOfDay, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.TimingRepeatTimeOfDay)))
                .MapReferenceListValuesFromDto();

            CreateMap<Dosage, DosageResponse>()
                .ForMember(a => a.TimingRepeatTimeOfDay, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.TimingRepeatTimeOfDay)))
                .ForMember(a => a.TimingEvent, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.TimingEvent)))
                .ForMember(a => a.TimingRepeatDayOfWeek, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.TimingRepeatDayOfWeek)))
                .MapReferenceListValuesToDto();

        }
    }
}
