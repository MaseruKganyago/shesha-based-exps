using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.Referrals;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferralServiceRequestMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferralServiceRequestMapProfile()
        {
            CreateMap<ReferralServiceRequestInput, ReferralServiceRequest>()
                .ForMember(e => e.Replaces, e => e.MapFrom(e => GetEntity<ServiceRequest>(e.Replaces)))
                .ForMember(e => e.Subject, e => e.MapFrom(e => GetEntity<Patient>(e.Subject)))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => GetEntity<Encounter>(e.Encounter)))
                .ForMember(e => e.ServiceQueue, e => e.MapFrom(e => GetEntity<Schedule>(e.ServiceQueue)))
                .ForMember(e => e.BookingSlot, e => e.MapFrom(e => GetEntity<Slot>(e.BookingSlot)))
                .ForMember(e => e.EncounterInitiated, e => e.MapFrom(e => GetEntity<Encounter>(e.EncounterInitiated)))
                .ForMember(e => e.LocationReference, e => e.MapFrom(e => GetEntity<FhirLocation>(e.LocationReference)))
                .ForMember(e => e.Category, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.Category)))
                .ForMember(e => e.OrderDetail, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.OrderDetail)))
                .ForMember(e => e.AuthoredOn, e => e.MapFrom(e => DateTime.Now))
                .ForMember(e => e.ReasonCode, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.ReasonCode)))
                .ForMember(e => e.BodySite, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.BodySite)))
            //.ForMember(e => e.Specimen, e => e.MapFrom(e => GetEntity<Specimen>(e.Specimen)))
            //.ForMember(e => e.RelevantHistory, e => e.MapFrom(e => GetEntity<Provenance>(e.RelevantHistory)))
                .MapReferenceListValuesFromDto();

            CreateMap<ReferralServiceRequestUpdate, ReferralServiceRequest>()
                .ForMember(e => e.Replaces, e => e.MapFrom(e => GetEntity<ServiceRequest>(e.Replaces)))
                .ForMember(e => e.Subject, e => e.MapFrom(e => GetEntity<Patient>(e.Subject)))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => GetEntity<Encounter>(e.Encounter)))
                .ForMember(e => e.ServiceQueue, e => e.MapFrom(e => GetEntity<Schedule>(e.ServiceQueue)))
                .ForMember(e => e.BookingSlot, e => e.MapFrom(e => GetEntity<Slot>(e.BookingSlot)))
                .ForMember(e => e.EncounterInitiated, e => e.MapFrom(e => GetEntity<Encounter>(e.EncounterInitiated)))
                .ForMember(e => e.LocationReference, e => e.MapFrom(e => GetEntity<FhirLocation>(e.LocationReference)))
                .ForMember(e => e.Category, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.Category)))
                .ForMember(e => e.OrderDetail, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.OrderDetail)))
                .ForMember(e => e.AuthoredOn, e => e.MapFrom(e => DateTime.Now))
                .ForMember(e => e.ReasonCode, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.ReasonCode)))
                .ForMember(e => e.BodySite, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.BodySite)))
            ////.ForMember(e => e.Specimen, e => e.MapFrom(e => GetEntity<Specimen>(e.Specimen)))
            ////.ForMember(e => e.RelevantHistory, e => e.MapFrom(e => GetEntity<Provenance>(e.RelevantHistory)))
                .MapReferenceListValuesFromDto();

            CreateMap<ReferralServiceRequestResponse, ReferralServiceRequest>()
                .ForMember(e => e.Replaces, e => e.MapFrom(e => GetEntity<ServiceRequest>(e.Replaces)))
                .ForMember(e => e.Subject, e => e.MapFrom(e => GetEntity<Patient>(e.Subject)))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => GetEntity<Encounter>(e.Encounter)))
                .ForMember(e => e.ServiceQueue, e => e.MapFrom(e => GetEntity<Schedule>(e.ServiceQueue)))
                .ForMember(e => e.BookingSlot, e => e.MapFrom(e => GetEntity<Slot>(e.BookingSlot)))
                .ForMember(e => e.EncounterInitiated, e => e.MapFrom(e => GetEntity<Encounter>(e.EncounterInitiated)))
                .ForMember(e => e.LocationReference, e => e.MapFrom(e => GetEntity<FhirLocation>(e.LocationReference)))
                .ForMember(e => e.Category, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.Category)))
                .ForMember(e => e.OrderDetail, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.OrderDetail)))
                .ForMember(e => e.AuthoredOn, e => e.MapFrom(e => DateTime.Now))
                .ForMember(e => e.ReasonCode, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.ReasonCode)))
                .ForMember(e => e.BodySite, e => e.MapFrom(e => UtilityHelper.SetMultiValueReferenceList(e.BodySite)))
                //.ForMember(e => e.Specimen, e => e.MapFrom(e => GetEntity<Specimen>(e.Specimen)))
                //.ForMember(e => e.RelevantHistory, e => e.MapFrom(e => GetEntity<Provenance>(e.RelevantHistory)))
                .MapReferenceListValuesFromDto();

            CreateMap<ReferralServiceRequest, ReferralServiceRequestResponse>()
                .ForMember(c => c.Replaces, options => options.MapFrom(c => c.Replaces != null ? new EntityWithDisplayNameDto<Guid?>(c.Replaces.Id, c.Replaces.Identifier) : null))
                .ForMember(c => c.Subject, options => options.MapFrom(c => c.Subject != null ? new EntityWithDisplayNameDto<Guid?>(c.Subject.Id, c.Subject.FullName) : null))
                .ForMember(c => c.Encounter, options => options.MapFrom(c => c.Encounter != null ? new EntityWithDisplayNameDto<Guid?>(c.Encounter.Id, c.Encounter.Identifier) : null))
                .ForMember(c => c.ServiceQueue, options => options.MapFrom(c => c.ServiceQueue != null ? new EntityWithDisplayNameDto<Guid?>(c.ServiceQueue.Id, c.ServiceQueue.Identifier) : null))
                .ForMember(c => c.BookingSlot, options => options.MapFrom(c => c.BookingSlot != null ? new EntityWithDisplayNameDto<Guid?>(c.BookingSlot.Id, c.BookingSlot.Identifier) : null))
                .ForMember(c => c.EncounterInitiated, options => options.MapFrom(c => c.EncounterInitiated != null ? new EntityWithDisplayNameDto<Guid?>(c.EncounterInitiated.Id, c.Encounter.Identifier) : null))
                .ForMember(c => c.LocationReference, options => options.MapFrom(c => c.LocationReference != null ? new EntityWithDisplayNameDto<Guid?>(c.LocationReference.Id, c.LocationReference.Name) : null))
                .ForMember(c => c.Category, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.Category != null ? (RefListServiceRequestCategoryCodes)c.Category : 0)))
                .ForMember(c => c.OrderDetail, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.OrderDetail != null ? (RefListServiceRequestOrderDetails)c.OrderDetail : 0)))
                .ForMember(c => c.ReasonCode, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.ReasonCode != null ? (RefListServiceRequestProcedureReasons)c.ReasonCode : 0)))
                .ForMember(c => c.BodySite, options => options.MapFrom(c => UtilityHelper.GetMultiReferenceListItemValueList(c.BodySite != null ? (RefListBodySite)c.BodySite : 0)))
            //.ForMember(c => c.Specimen, options => options.MapFrom(c => c.Specimen != null ? new EntityWithDisplayNameDto<Guid?>(c.Specimen.Id, c.Specimen.Name) : null))
            //.ForMember(c => c.RelevantHistory, options => options.MapFrom(c => c.RelevantHistory != null ? new EntityWithDisplayNameDto<Guid?>(c.RelevantHistory.Id, c.Assigner.Name) : null))
                .MapReferenceListValuesToDto();

            CreateMap<Person, ReferralServiceRequestInput>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.PerformerOwnerId, options => options.MapFrom(c => c != null ? c.Id.ToString() : null))
                .ForMember(c => c.PerformerOwnerType, options => options.MapFrom(c => c != null ? c.GetTypeShortAlias() : null));

            CreateMap<Person, ReferralServiceRequestUpdate>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.PerformerOwnerId, options => options.MapFrom(c => c != null ? c.Id.ToString() : null))
                .ForMember(c => c.PerformerOwnerType, options => options.MapFrom(c => c != null ? c.GetTypeShortAlias() : null));

            CreateMap<ReferralServiceRequest, ReferralFacilityContent>()
                .ForMember(a => a.Encounter, options => options.MapFrom(b => b.Encounter != null ? new EntityWithDisplayNameDto<Guid?>(b.Encounter.Id, b.Identifier) : null))
                .ForMember(c => c.PatientName, options => options.MapFrom(c => c != null ? c.Subject.FullName : ""))
                .ForMember(c => c.DateOfBirth, options => options.MapFrom(c => c != null ? UtilityHelper.ConvertDateTime(c.Subject.DateOfBirth) : ""))
                .ForMember(c => c.AuthoredOn, options => options.MapFrom(c => c != null ? UtilityHelper.ConvertDateTime(c.AuthoredOn) : ""))
                .ForMember(c => c.Comment, options => options.MapFrom(c => c.Comment ?? ""))
                .ForMember(c => c.Speciality, options => options.MapFrom(c => c != null ? UtilityHelper.GetRefListItemText("Fhir", "ServiceDeliveryLocationRoleTypes", c.LocationCode != null ? (long?)c.LocationCode.Value : null): ""))
                .ForMember(c => c.ReferralFacility, options => options.MapFrom(c => c != null ? c.LocationReference.Name : ""));

            CreateMap<CdmPractitioner, ReferralFacilityContent>()
                .ForMember(c => c.HealthCareProvider, options => options.MapFrom(c => c != null ? c.FullName : ""))
                .ForMember(c => c.HPCSANumber, options => options.MapFrom(c => c != null ? c.PracticeSANCNumber : ""))
                .ForMember(c => c.DispensaryNumber, options => options.MapFrom(c => c != null ? c.DispensaryNumber : ""))
                .ForMember(c => c.PractitionerRole, options => options.MapFrom(c => c != null ? UtilityHelper.GetRefListItemText("Cdm", "PractitionerRoles", c.PrimaryPractitionerRole != null ? (long?)c.PrimaryPractitionerRole.Value : null) : ""));

            CreateMap<Person, ReferralFacilityContent>()
                .ForMember(c => c.HealthCareProvider, options => options.MapFrom(c => c != null ? c.FullName : ""));

            CreateMap<ReferralServiceRequest, Document>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(e => e.Subject, e => e.MapFrom(e => e.Subject))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => e.Encounter))
                .ForMember(e => e.Type, e => e.MapFrom(e => RefListDocumentTypeValueSets.ReferralToFacility))
            .MapReferenceListValuesToDto();

            CreateMap<Person, Document>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Practitioner, options => options.MapFrom(c => (c != null ? c : null)));
        }
    }
}
