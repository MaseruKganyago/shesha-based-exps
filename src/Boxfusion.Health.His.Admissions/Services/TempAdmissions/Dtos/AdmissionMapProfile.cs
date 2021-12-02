using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class AdmissionMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public AdmissionMapProfile()
        {
            CreateMap<AdmissionInput, WardAdmission>()
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
                .ForMember(a => a.Ward, options => options.MapFrom(b => GetEntity<Ward>(b.Ward)))
                .ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
                .ForMember(c => c.SeparationDate, options => options.MapFrom(c => c.SeparationDate))
                .ForMember(c => c.TransferRejectionReason, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.TransferRejectionReason)))
                .ForMember(c => c.TransferRejectionReasonComment, options => options.MapFrom(c => c.TransferRejectionReasonComment))
                .ForMember(c => c.SeparationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.SeparationType)))
                .ForMember(a => a.SeparationDestinationWard, options => options.MapFrom(b => GetEntity<Ward>(b.SeparationDestinationWard)))
                .ForMember(c => c.SeparationChildHealth, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.SeparationChildHealth)))
                .ForMember(c => c.SeparationComment, options => options.MapFrom(c => c.SeparationComment))
                .ForMember(a => a.InternalTransferOriginalWard, options => options.MapFrom(b => GetEntity<Ward>(b.InternalTransferOriginalWard)))
                .ForMember(a => a.InternalTransferDestinationWard, options => options.MapFrom(b => GetEntity<Ward>(b.InternalTransferDestinationWard)))
                .MapReferenceListValuesFromDto();

            CreateMap<AdmissionInput, HospitalAdmission>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.CapturedAfterApproval, options => options.MapFrom(c => false))
                .ForMember(c => c.HospitalAdmissionNumber, options => options.MapFrom(c => c.HospitalAdmissionNumber))
                .ForMember(c => c.Status, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Status)))
                .ForMember(c => c.Class, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Class)))
                .ForMember(c => c.Type, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Type)))
                .ForMember(c => c.AdmitSource, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.AdmitSource)))
                .ForMember(c => c.ReAdmission, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.ReAdmission)))
                .ForMember(c => c.DietPreference, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.DietPreference)))
                .ForMember(c => c.SpecialCourtesy, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.SpecialCourtesy)))
                .ForMember(c => c.SpecialArrangement, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.SpecialArrangement)))
                .ForMember(c => c.DischargeDisposition, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.DischargeDisposition)))
                .ForMember(c => c.Priority, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Priority)))
                .ForMember(c => c.ServiceType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.ServiceType)))
                .ForMember(c => c.PreAdmissionIdentifier, options => options.MapFrom(c => c.PreAdmissionIdentifier))
                .ForMember(c => c.OriginOwnerId, options => options.MapFrom(c => c.OriginOwnerId))
                .ForMember(c => c.OriginOwnerType, options => options.MapFrom(c => c.OriginOwnerType))
                .ForMember(c => c.DestinationOwnerId, options => options.MapFrom(c => c.DestinationOwnerId))
                .ForMember(c => c.ReasonReferenceOwnerType, options => options.MapFrom(c => c.ReasonReferenceOwnerType))
                .ForMember(c => c.ReasonReferenceOwnerId, options => options.MapFrom(c => c.ReasonReferenceOwnerId))
                .ForMember(e => e.ReasonCode, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.ReasonCode)))
                .ForMember(c => c.EndDateTime, options => options.MapFrom(c => c.EndDateTime))
                .ForMember(c => c.StartDateTime, options => options.MapFrom(c => DateTime.Now))
                .ForMember(c => c.Identifier, options => options.MapFrom(c => c.Identifier))
                .ForMember(u => u.HospitalAdmissionStatus, options => options.MapFrom(u => RefListHospitalAdmissionStatuses.admitted))
                .ForMember(c => c.Classification, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Classification)))
                .ForMember(c => c.OtherCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.OtherCategory)))
                .ForMember(a => a.TransferFroHospital, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.TransferFroHospital)))
                .ForMember(a => a.TransferToHospital, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.TransferToHospital)))
                .ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
                .ForMember(a => a.ServiceProvider, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.ServiceProvider)))
                .ForMember(a => a.Appointment, options => options.MapFrom(b => GetEntity<Appointment>(b.Appointment)))
                .ForMember(a => a.Performer, options => options.MapFrom(b => GetEntity<Practitioner>(b.Performer)))
                .ForMember(a => a.BasedOn, options => options.MapFrom(b => GetEntity<ServiceRequest>(b.BasedOn)))
                .ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => GetEntity<EpisodeOfCare>(b.EpisodeOfCare)))
                .ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
                .MapReferenceListValuesToDto();

            CreateMap<HisPatient, HospitalAdmission>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Identifier, options => options.Ignore())
                .ForMember(c => c.Subject, options => options.MapFrom(c => GetEntity<Patient>(c.Id)))
                .MapReferenceListValuesToDto();

            CreateMap<HisPatient, WardAdmission>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Identifier, options => options.Ignore())
                .ForMember(c => c.Subject, options => options.MapFrom(c => GetEntity<Patient>(c.Id)))
                .MapReferenceListValuesToDto();

            CreateMap<WardAdmission, AdmissionResponse>()
                .ForMember(c => c.Status, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterStatuses", (long?)c.Status)))
                .ForMember(c => c.Class, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterClasses", (long?)c.Class)))
                .ForMember(c => c.Type, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterTypes", (long?)c.Type)))
                .ForMember(c => c.Priority, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterPriorities", (long?)c.Priority)))
                .ForMember(c => c.ServiceType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterServiceTypes", (long?)c.ServiceType)))
                .ForMember(c => c.AdmitSource, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationAdmitSources", (long?)c.AdmitSource)))
                .ForMember(c => c.ReAdmission, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationReAdmissionIndicators", (long?)c.ReAdmission)))
                .ForMember(c => c.DietPreference, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationDiets", (long?)c.DietPreference)))
                .ForMember(c => c.SpecialCourtesy, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSpecialCourtesies", (long?)c.SpecialCourtesy)))
                .ForMember(c => c.SpecialArrangement, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSpecialArrangements", (long?)c.SpecialArrangement)))
                .ForMember(c => c.DischargeDisposition, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationDischargeDispositions", (long?)c.DischargeDisposition)))
                .ForMember(c => c.AdmissionStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "AdmissionStatuses", (long?)c.AdmissionStatus)))
                .ForMember(c => c.AdmissionType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "AdmissionTypes", (long?)c.AdmissionType)))
                .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList((RefListServiceRequestProcedureReasons)c.ReasonCode)))
                .ForMember(c => c.PreAdmissionIdentifier, options => options.MapFrom(c => c.PreAdmissionIdentifier))
                .ForMember(c => c.OriginOwnerId, options => options.MapFrom(c => c.OriginOwnerId))
                .ForMember(c => c.OriginOwnerType, options => options.MapFrom(c => c.OriginOwnerType))
                .ForMember(c => c.DestinationOwnerId, options => options.MapFrom(c => c.DestinationOwnerId))
                .ForMember(c => c.ReasonReferenceOwnerType, options => options.MapFrom(c => c.ReasonReferenceOwnerType))
                .ForMember(c => c.ReasonReferenceOwnerId, options => options.MapFrom(c => c.ReasonReferenceOwnerId))
                .ForMember(c => c.EndDateTime, options => options.MapFrom(c => c.EndDateTime))
                .ForMember(c => c.StartDateTime, options => options.MapFrom(c => c.StartDateTime))
                .ForMember(c => c.Identifier, options => options.MapFrom(c => c.Identifier))
                .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
                .ForMember(c => c.PartOf, options => options.MapFrom(c => c.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(c.PartOf.Id, c.PartOf.Identifier) : null))
                .ForMember(c => c.ServiceProvider, options => options.MapFrom(c => c.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(c.ServiceProvider.Id, c.ServiceProvider.Name) : null))
                .ForMember(c => c.Appointment, options => options.MapFrom(c => c.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(c.Appointment.Id, c.Appointment.Identifier) : null))
                .ForMember(c => c.Performer, options => options.MapFrom(c => c.Performer != null ? new EntityWithDisplayNameDto<Guid?>(c.Performer.Id, c.Performer.FullName) : null))
                .ForMember(c => c.BasedOn, options => options.MapFrom(c => c.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(c.BasedOn.Id, c.BasedOn.Identifier) : null))
                .ForMember(c => c.EpisodeOfCare, options => options.MapFrom(c => c.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(c.EpisodeOfCare.Id, "") : null))
                .ForMember(c => c.Ward, options => options.MapFrom(c => c.Ward != null ? new EntityWithDisplayNameDto<Guid?>(c.Ward.Id, c.Ward.Name) : null))
                .ForMember(c => c.SeparationDate, options => options.MapFrom(c => c.SeparationDate))
                .ForMember(c => c.TransferRejectionReason, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationTransferRejectionReason", (long?)c.TransferRejectionReason)))
                .ForMember(c => c.TransferRejectionReasonComment, options => options.MapFrom(c => c.TransferRejectionReasonComment))
                .ForMember(c => c.SeparationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSeparationType", (long?)c.SeparationType)))
                .ForMember(c => c.SeparationDestinationWard, options => options.MapFrom(c => c.SeparationDestinationWard != null ? new EntityWithDisplayNameDto<Guid?>(c.SeparationDestinationWard.Id, c.SeparationDestinationWard.Name) : null))
                .ForMember(c => c.SeparationChildHealth, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSeparationChildHealth", (long?)c.SeparationChildHealth)))
                .ForMember(c => c.SeparationComment, options => options.MapFrom(c => c.SeparationComment))
                //.ForMember(c => c.InternalTransferOriginalWard, options => options.MapFrom(c => c.InternalTransferOriginalWard != null ? new EntityWithDisplayNameDto<Guid?>(c.InternalTransferOriginalWard.Id, c.InternalTransferOriginalWard.Identifier) : null))
                //.ForMember(c => c.InternalTransferDestinationWard, options => options.MapFrom(c => c.InternalTransferDestinationWard != null ? new EntityWithDisplayNameDto<Guid?>(c.InternalTransferDestinationWard.Id, c.InternalTransferDestinationWard.Identifier) : null))
                //.ForMember(C => C.AgeBreakdown, options => options.MapFrom(""))
                .MapReferenceListValuesFromDto();

            CreateMap<HospitalAdmission, AdmissionResponse>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Identifier, options => options.Ignore())
                .ForMember(c => c.Status, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterStatuses", (long?)c.Status)))
                .ForMember(c => c.Class, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterClasses", (long?)c.Class)))
                .ForMember(c => c.Type, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterTypes", (long?)c.Type)))
                .ForMember(c => c.Priority, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterPriorities", (long?)c.Priority)))
                .ForMember(c => c.ServiceType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "EncounterServiceTypes", (long?)c.ServiceType)))
                .ForMember(c => c.AdmitSource, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationAdmitSources", (long?)c.AdmitSource)))
                .ForMember(c => c.ReAdmission, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationReAdmissionIndicators", (long?)c.ReAdmission)))
                .ForMember(c => c.DietPreference, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationDiets", (long?)c.DietPreference)))
                .ForMember(c => c.SpecialCourtesy, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSpecialCourtesies", (long?)c.SpecialCourtesy)))
                .ForMember(c => c.SpecialArrangement, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationSpecialArrangements", (long?)c.SpecialArrangement)))
                .ForMember(c => c.DischargeDisposition, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "EncounterHospitalisationDischargeDispositions", (long?)c.DischargeDisposition)))
                .ForMember(c => c.HospitalAdmissionStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "HospitalAdmissionStatuses", (long?)c.HospitalAdmissionStatus)))
                .ForMember(c => c.Classification, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Classifications", (long?)c.Classification)))
                .ForMember(c => c.OtherCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "OtherCategories", (long?)c.OtherCategory)))
                .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList((RefListServiceRequestProcedureReasons)c.ReasonCode)))
                .ForMember(c => c.HospitalAdmissionNumber, options => options.MapFrom(c => c.HospitalAdmissionNumber))
                .ForMember(c => c.PreAdmissionIdentifier, options => options.MapFrom(c => c.PreAdmissionIdentifier))
                .ForMember(c => c.OriginOwnerId, options => options.MapFrom(c => c.OriginOwnerId))
                .ForMember(c => c.OriginOwnerType, options => options.MapFrom(c => c.OriginOwnerType))
                .ForMember(c => c.DestinationOwnerId, options => options.MapFrom(c => c.DestinationOwnerId))
                .ForMember(c => c.ReasonReferenceOwnerType, options => options.MapFrom(c => c.ReasonReferenceOwnerType))
                .ForMember(c => c.ReasonReferenceOwnerId, options => options.MapFrom(c => c.ReasonReferenceOwnerId))
                .ForMember(c => c.EndDateTime, options => options.MapFrom(c => c.EndDateTime))
                .ForMember(c => c.StartDateTime, options => options.MapFrom(c => c.StartDateTime))
                .ForMember(c => c.Identifier, options => options.MapFrom(c => c.Identifier))
                .ForMember(c => c.TransferFroHospital, options => options.MapFrom(c => c.TransferFroHospital != null ? new EntityWithDisplayNameDto<Guid?>(c.TransferFroHospital.Id, c.TransferFroHospital.Name) : null))
                .ForMember(c => c.TransferToHospital, options => options.MapFrom(c => c.TransferToHospital != null ? new EntityWithDisplayNameDto<Guid?>(c.TransferToHospital.Id, c.TransferToHospital.Name) : null))
                .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
                .ForMember(c => c.PartOf, options => options.MapFrom(c => c.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(c.PartOf.Id, c.PartOf.Identifier) : null))
                .ForMember(c => c.ServiceProvider, options => options.MapFrom(c => c.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(c.ServiceProvider.Id, c.ServiceProvider.Name) : null))
                .ForMember(c => c.Appointment, options => options.MapFrom(c => c.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(c.Appointment.Id, c.Appointment.Identifier) : null))
                .ForMember(c => c.Performer, options => options.MapFrom(c => c.Performer != null ? new EntityWithDisplayNameDto<Guid?>(c.Performer.Id, c.Performer.FullName) : null))
                .ForMember(c => c.BasedOn, options => options.MapFrom(c => c.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(c.BasedOn.Id, c.BasedOn.Identifier) : null))
                .ForMember(c => c.EpisodeOfCare, options => options.MapFrom(c => c.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(c.EpisodeOfCare.Id, "") : null))

                .MapReferenceListValuesToDto();

            CreateMap<HisPatient, AdmissionResponse>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Identifier, options => options.Ignore())
                .ForMember(c => c.Subject, options => options.Ignore())
                .ForMember(c => c.FirstName, options => options.MapFrom(c => c.FirstName))
                .ForMember(c => c.LastName, options => options.MapFrom(c => c.LastName))
                .ForMember(c => c.DateOfBirth, options => options.MapFrom(c => c.DateOfBirth))
                .ForMember(c => c.IdentityNumber, options => options.MapFrom(c => c.IdentityNumber))
                .ForMember(c => c.PatientMasterIndexNumber, options => options.MapFrom(c => c.PatientMasterIndexNumber))
                .ForMember(c => c.HospitalPatientNumber, options => options.MapFrom(c => c.HospitalPatientNumber))
                .ForMember(c => c.Gender, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Shesha.Core", "Gender", (long?)c.Gender)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "Countries", (long?)c.Nationality)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Provinces", (long?)c.PatientProvince)))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "IdentificationTypes", (long?)c.IdentificationType)))
                .MapReferenceListValuesToDto();

            //CreateMap<WardAdmission, PatientAuditTrailDto>()
            //    .ForMember(c => c.StartDateTime, options => options.MapFrom(c => c.StartDateTime))
            //    .ForMember(c => c.AdmissionStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "AdmissionStatuses", (long?)c.AdmissionStatus)))
            //    .ForMember(c => c.Speciality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "WardSpecialities", (long?)c.Ward.Speciality)))
            //    .MapReferenceListValuesFromDto();

            //CreateMap<Ward, PatientAuditTrailDto>()
            //    .ForMember(c => c.Speciality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "WardSpecialities", (long?)c.Speciality)))
            //    .MapReferenceListValuesFromDto();
        }
    }
}
