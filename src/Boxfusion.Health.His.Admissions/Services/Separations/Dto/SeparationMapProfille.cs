using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class SeparationMapProfille : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public SeparationMapProfille()
        {
            CreateMap<SeparationInput, WardAdmission>()
            .ForMember(c => c.Id, options => options.Ignore())
            .ForMember(c => c.CapturedAfterApproval, options => options.MapFrom(c => false))
            .ForMember(c => c.StartDateTime, options => options.MapFrom(c => DateTime.Now))
            .ForMember(u => u.AdmissionStatus, options => options.MapFrom(u => RefListAdmissionStatuses.admitted))
            .ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
            .ForMember(a => a.ServiceProvider, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.ServiceProvider)))
            .ForMember(a => a.Appointment, options => options.MapFrom(b => GetEntity<Appointment>(b.Appointment)))
            .ForMember(a => a.Performer, options => options.MapFrom(b => GetEntity<Practitioner>(b.Performer)))
            .ForMember(a => a.BasedOn, options => options.MapFrom(b => GetEntity<ServiceRequest>(b.BasedOn)))
            .ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => GetEntity<EpisodeOfCare>(b.EpisodeOfCare)))
            .ForMember(a => a.Ward, options => options.MapFrom(b => GetEntity<HisWard>(b.Ward)))
            .ForMember(a => a.SeparationDestinationWard, options => options.MapFrom(b => GetEntity<HisWard>(b.SeparationDestinationWard)))
            .ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
            .MapReferenceListValuesFromDto();

            //CreateMap<HospitalAdmission, AdmissionResponse>()
            //    .ForMember(c => c.Id, options => options.Ignore())
            //    .ForMember(c => c.Identifier, options => options.Ignore())
            //    .ForMember(c => c.Status, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterStatuses", (long?)c.Status)))
            //    .ForMember(c => c.Class, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterClasses", (long?)c.Class)))
            //    .ForMember(c => c.Type, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterTypes", (long?)c.Type)))
            //    .ForMember(c => c.Priority, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterPriorities", (long?)c.Priority)))
            //    .ForMember(c => c.ServiceType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterServiceTypes", (long?)c.ServiceType)))
            //    .ForMember(c => c.AdmitSource, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationAdmitSources", (long?)c.AdmitSource)))
            //    .ForMember(c => c.ReAdmission, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationReAdmissionIndicators", (long?)c.ReAdmission)))
            //    .ForMember(c => c.DietPreference, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationDiets", (long?)c.DietPreference)))
            //    .ForMember(c => c.SpecialCourtesy, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSpecialCourtesies", (long?)c.SpecialCourtesy)))
            //    .ForMember(c => c.SpecialArrangement, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSpecialArrangements", (long?)c.SpecialArrangement)))
            //    .ForMember(c => c.DischargeDisposition, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationDischargeDispositions", (long?)c.DischargeDisposition)))
            //    .ForMember(c => c.HospitalAdmissionStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "HospitalAdmissionStatuses", (long?)c.HospitalAdmissionStatus)))
            //    .ForMember(c => c.Classification, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Classifications", (long?)c.Classification)))
            //    .ForMember(c => c.OtherCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "OtherCategories", (long?)c.OtherCategory)))
            //    .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList((RefListServiceRequestProcedureReasons)c.ReasonCode)))
            //    .ForMember(c => c.HospitalAdmissionNumber, options => options.MapFrom(c => c.HospitalAdmissionNumber))
            //    .ForMember(c => c.PreAdmissionIdentifier, options => options.MapFrom(c => c.PreAdmissionIdentifier))
            //    .ForMember(c => c.OriginOwnerId, options => options.MapFrom(c => c.OriginOwnerId))
            //    .ForMember(c => c.OriginOwnerType, options => options.MapFrom(c => c.OriginOwnerType))
            //    .ForMember(c => c.DestinationOwnerId, options => options.MapFrom(c => c.DestinationOwnerId))
            //    .ForMember(c => c.ReasonReferenceOwnerType, options => options.MapFrom(c => c.ReasonReferenceOwnerType))
            //    .ForMember(c => c.ReasonReferenceOwnerId, options => options.MapFrom(c => c.ReasonReferenceOwnerId))
            //    .ForMember(c => c.EndDateTime, options => options.MapFrom(c => c.EndDateTime))
            //    .ForMember(c => c.StartDateTime, options => options.MapFrom(c => c.StartDateTime))
            //    .ForMember(c => c.Identifier, options => options.MapFrom(c => c.Identifier))
            //    .ForMember(c => c.TransferFroHospital, options => options.MapFrom(c => c.TransferFroHospital != null ? new EntityWithDisplayNameDto<Guid?>(c.TransferFroHospital.Id, c.TransferFroHospital.Name) : null))
            //    .ForMember(c => c.TransferToHospital, options => options.MapFrom(c => c.TransferToHospital != null ? new EntityWithDisplayNameDto<Guid?>(c.TransferToHospital.Id, c.TransferToHospital.Name) : null))
            //    .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
            //    .ForMember(c => c.PartOf, options => options.MapFrom(c => c.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(c.PartOf.Id, c.PartOf.Identifier) : null))
            //    .ForMember(c => c.ServiceProvider, options => options.MapFrom(c => c.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(c.ServiceProvider.Id, c.ServiceProvider.Name) : null))
            //    .ForMember(c => c.Appointment, options => options.MapFrom(c => c.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(c.Appointment.Id, c.Appointment.Identifier) : null))
            //    .ForMember(c => c.Performer, options => options.MapFrom(c => c.Performer != null ? new EntityWithDisplayNameDto<Guid?>(c.Performer.Id, c.Performer.FullName) : null))
            //    .ForMember(c => c.BasedOn, options => options.MapFrom(c => c.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(c.BasedOn.Id, c.BasedOn.Identifier) : null))
            //    .ForMember(c => c.EpisodeOfCare, options => options.MapFrom(c => c.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(c.EpisodeOfCare.Id, "") : null))
            //    .MapReferenceListValuesToDto();
        }

    }
}
