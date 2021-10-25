using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Extentions;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicationRequestMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public MedicationRequestMapProfile()
        {
            CreateMap<CdmMedicationRequestInput, CdmMedicationRequest>()
                .ForMember(e => e.Subject, e => e.MapFrom(e => GetEntity<Patient>(e.Subject)))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => GetEntity<Encounter>(e.Encounter)))
                .ForMember(e => e.MedicationReference, e => e.MapFrom(e => GetEntity<Medication>(e.MedicationReference)))
                .ForMember(e => e.PriorPrescription, e => e.MapFrom(e => GetEntity<CdmMedicationRequest>(e.PriorPrescription)))
                //.ForMember(e => e.EventHistory, e => e.MapFrom(e => GetEntity<Provenance>(e.EventHistory)))
                .ForMember(e => e.Category, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.Category)))
                .ForMember(e => e.MedicationCodeableConcept, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.MedicationCodeableConcept)))
                .ForMember(e => e.AuthoredOn, e => e.MapFrom(e => DateTime.Now))
                .ForMember(e => e.ReasonCode, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.ReasonCode)))
            .MapReferenceListValuesFromDto();

            CreateMap<CdmMedicationRequestUpdate, CdmMedicationRequest>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.BasedOnOwnerId, options => options.Ignore())
                .ForMember(c => c.BasedOnOwnerType, options => options.Ignore())
                .ForMember(c => c.PerformerOwnerId, options => options.Ignore())
                .ForMember(c => c.PerformerOwnerType, options => options.Ignore())
                .ForMember(e => e.Subject, e => e.MapFrom(e => GetEntity<Patient>(e.Subject)))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => GetEntity<Encounter>(e.Encounter)))
                .ForMember(e => e.MedicationReference, e => e.MapFrom(e => GetEntity<Medication>(e.MedicationReference)))
                .ForMember(e => e.PriorPrescription, e => e.MapFrom(e => GetEntity<CdmMedicationRequest>(e.PriorPrescription)))
                //.ForMember(e => e.EventHistory, e => e.MapFrom(e => GetEntity<Provenance>(e.EventHistory)))
                .ForMember(e => e.Category, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.Category)))
                .ForMember(e => e.MedicationCodeableConcept, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.MedicationCodeableConcept)))
                .ForMember(e => e.AuthoredOn, e => e.MapFrom(e => DateTime.Now))
                .ForMember(e => e.ReasonCode, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.ReasonCode)))
            .MapReferenceListValuesFromDto();


            CreateMap<CdmMedicationRequest, CdmMedicationRequestResponse > ()
                .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
                .ForMember(c => c.Encounter, options => options.MapFrom(c => c.Encounter != null ? new EntityWithDisplayNameDto<Guid?>(c.Encounter.Id, c.Encounter.Identifier) : null))
                .ForMember(c => c.MedicationReference, options => options.MapFrom(c => c.MedicationReference != null ? new EntityWithDisplayNameDto<Guid?>(c.MedicationReference.Id, c.MedicationReference.Identifier) : null))
                .ForMember(c => c.PriorPrescription, options => options.MapFrom(c => c.PriorPrescription != null ? new EntityWithDisplayNameDto<Guid?>(c.PriorPrescription.Id, c.PriorPrescription.Identifier) : null))
                //.ForMember(c => c.EventHistory, options => options.MapFrom(c => c.EventHistory != null ? new EntityWithDisplayNameDto<Guid?>(c.EventHistory.Id, c.EventHistory.Identifier) : null))
                .ForMember(c => c.Category, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.Category != null ? (RefListMedicationRequestCategoryCodes)c.Category : 0)))
                .ForMember(c => c.MedicationCodeableConcept, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.MedicationCodeableConcept != null ? (RefListMedicationCodes)c.MedicationCodeableConcept : 0)))
                .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.ReasonCode != null ? (RefListConditionProblemDiagnosisCodes)c.ReasonCode : 0)))
            .MapReferenceListValuesToDto();

            CreateMap<ProductResponse, AutocompleteItemDto>()
                .ForMember(c => c.Value, options => options.MapFrom(c => c.Code))
                .ForMember(c => c.DisplayText, options => options.MapFrom(c => c.Name));

            CreateMap<CdmPractitioner, CdmMedicationRequestInput>()
                .ForMember(c => c.PerformerOwnerId, options => options.MapFrom(c => c != null ? c.Id.ToString() : null))
                .ForMember(c => c.PerformerOwnerType, options => options.MapFrom(c => c != null ? c.GetTypeShortAlias() : null));

            CreateMap<CdmPractitioner, CdmMedicationRequestUpdate>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.PerformerOwnerId, options => options.MapFrom(c => c != null ? c.Id.ToString() : null))
                .ForMember(c => c.PerformerOwnerType, options => options.MapFrom(c => c != null ? c.GetTypeShortAlias() : null));

            CreateMap<Person, CdmMedicationRequestUpdate>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.PerformerOwnerId, options => options.MapFrom(c => c != null ? c.Id.ToString() : null))
                .ForMember(c => c.PerformerOwnerType, options => options.MapFrom(c => c != null ? c.GetTypeShortAlias() : null));

            CreateMap<Person, CdmMedicationRequestInput>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.PerformerOwnerId, options => options.MapFrom(c => c != null ? c.Id.ToString() : null))
                .ForMember(c => c.PerformerOwnerType, options => options.MapFrom(c => c != null ? c.GetTypeShortAlias() : null));

            CreateMap<CdmPractitioner, EScriptContent>()
                .ForMember(c => c.PractitionerTitle, options => options.MapFrom(c => c != null ? c.Title.GetEnumDescription(): ""))
                .ForMember(c => c.PractitionerInitials, options => options.MapFrom(c => c != null ? c.Initials : ""))
                .ForMember(c => c.PractitionerSurname, options => options.MapFrom(c => c != null ? c.LastName : ""))
                .ForMember(c => c.HPCSANumber, options => options.MapFrom(c => c != null ? c.PracticeSANCNumber : ""))
                .ForMember(c => c.DispensaryNumber, options => options.MapFrom(c => c != null ? c.DispensaryNumber : ""))
                .ForMember(c => c.PractitionerRole, options => options.MapFrom(c => c != null ? c.PrimaryPractitionerRole.GetEnumDescription() : ""))
            .MapReferenceListValuesToDto();

            CreateMap<Person, EScriptContent>()
                .ForMember(c => c.PractitionerTitle, options => options.MapFrom(c => c != null ? c.Title.GetEnumDescription() : ""))
                .ForMember(c => c.PractitionerInitials, options => options.MapFrom(c => c != null ? c.Initials : ""))
                .ForMember(c => c.PractitionerSurname, options => options.MapFrom(c => c != null ? c.LastName : ""))
                .MapReferenceListValuesToDto();

            CreateMap<CdmMedicationRequest, EScriptContent>()
                .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
                .ForMember(c => c.PatientFullName, options => options.MapFrom(c => c != null ? c.Subject.FullName : ""))
                .ForMember(a => a.Encounter, options => options.MapFrom(b => b.Encounter != null ? new EntityWithDisplayNameDto<Guid?>(b.Encounter.Id, b.Identifier) : null))
                .ForMember(c => c.PatientMedicalAidName, options => options.MapFrom(c => c != null ? c.Subject.MedicalAidName : ""))
                .ForMember(c => c.PatientMedicalAidNumber, options => options.MapFrom(c => c != null ? c.Subject.MedicalAidNumber : ""))
                .ForMember(c => c.PatientContactNumber, options => options.MapFrom(c => c != null ? c.Subject.MobileNumber : ""))
                .ForMember(c => c.AuthoredOn, options => options.MapFrom(c => c != null ? UtilityHelper.ConvertDateTime(c.AuthoredOn) : ""));

            CreateMap<CdmMedicationRequest, Document>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(e => e.Subject, e => e.MapFrom(e => e.Subject))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => e.Encounter))
                .ForMember(e => e.Type, e => e.MapFrom(e => RefListDocumentTypeValueSets.eScript))
            .MapReferenceListValuesToDto();

            CreateMap<Person, Document>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Practitioner, options => options.MapFrom(c => (c != null ? c : null)));
        }
    }
}
