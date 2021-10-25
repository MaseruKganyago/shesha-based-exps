using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Boxfusion.Health.HealthCommon.Core.Extentions;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.Extensions;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.Dtos
{
	/// <summary>
	/// 
	/// </summary>
    public class EncounterMapProfile : ShaProfile
	{
		/// <summary>
		/// 
		/// </summary>
		public EncounterMapProfile()
		{
			CreateMap<FhirEncounterInput, Encounter>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => GetEntity<Appointment>(b.Appointment)))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => GetEntity<ServiceRequest>(b.BasedOn)))
				.ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => GetEntity<EpisodeOfCare>(b.EpisodeOfCare)))
				.ForMember(a => a.Performer, options => options.MapFrom(b => GetEntity<Practitioner>(b.Performer)))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.ServiceProvider)))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.ReasonCode)))
				.ForMember(e => e.StartDateTime, e => e.MapFrom(e => DateTime.Now))
			.MapReferenceListValuesToDto();

			//BackboneElement Participant
			CreateMap<ParticipantInput, Participant>()
				.ForMember(a => a.Individual, options => options.MapFrom(b => GetEntity<PersonFhirBase>(b.Individual)))
				.MapReferenceListValuesFromDto();

			CreateMap<Encounter, FhirEncounterResponse>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => b.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(b.Appointment.Id, "") : null))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => b.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(b.BasedOn.Id, b.BasedOn.Identifier) : null))
				.ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, b.Subject.FullName) : null))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => b.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(b.EpisodeOfCare.Id, "") : null))
				.ForMember(a => a.Performer, options => options.MapFrom(b => b.Performer != null ? new EntityWithDisplayNameDto<Guid?>(b.Performer.Id, b.Performer.FullName) : null))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => b.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(b.ServiceProvider.Id, b.ServiceProvider.Name) : null))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => b.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(b.PartOf.Id, b.PartOf.Identifier) : null))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.ReasonCode)))
			.MapReferenceListValuesToDto();

			CreateMap<Participant, ParticipantResponse>()
				.ForMember(a => a.Individual, options => options.MapFrom(b => b.Individual != null ? new EntityWithDisplayNameDto<Guid?>(b.Individual.Id, b.Individual.FullName) : null))
				.MapReferenceListValuesToDto();

			CreateMap<CdmPractitioner, ConsultationReportContent>()
				.ForMember(c => c.PractitionerTitle, options => options.MapFrom(c => c != null ? c.Title.GetEnumDescription() : null))
				.ForMember(c => c.HealthCareProvider, options => options.MapFrom(c => c != null ? c.LastName : null))
				.ForMember(c => c.HPCSANumber, options => options.MapFrom(c => c != null ? c.PracticeSANCNumber : null))
				.ForMember(c => c.DispensaryNumber, options => options.MapFrom(c => c != null ? c.DispensaryNumber : null))
				.ForMember(c => c.PractitionerRole, options => options.MapFrom(c => c != null ? c.PrimaryPractitionerRole.GetEnumDescription() : null))
			.MapReferenceListValuesToDto();

			//BackboneElement Encounter
			CreateMap<EncounterLocationInput, EncounterLocation>()
				.ForMember(a => a.Location, options => options.MapFrom(b => GetEntity<FhirLocation>(b.Location)))
			.MapReferenceListValuesFromDto();

			CreateMap<CdmPatient, ConsultationReportContent>()
				.ForMember(c => c.PatientFullName, options => options.MapFrom(c => c != null ? c.FullName : null))
				.ForMember(c => c.PatientID, options => options.MapFrom(c => c != null ? c.IdentityNumber : null))
				.ForMember(c => c.PatientAge, options => options.MapFrom(c => c != null ? UtilityHelper.CalculateAge(c.DateOfBirth) : null))
				.ForMember(c => c.PatientGender, options => options.MapFrom(c => c != null ? c.Gender.GetEnumDescription(): null))
			.MapReferenceListValuesToDto();

			CreateMap<EncounterLocation, EncounterLocationResponse>()
				.ForMember(a => a.Location, options => options.MapFrom(b => b.Location != null ? new EntityWithDisplayNameDto<Guid?>(b.Location.Id, b.Location.Name) : null))
			.MapReferenceListValuesToDto();

			CreateMap<Encounter, ConsultationReportContent>()
				.ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, b.Subject.FullName) : null))
				.ForMember(a => a.Encounter, options => options.MapFrom(b => b.Id != null ? new EntityWithDisplayNameDto<Guid?>(b.Id, b.Identifier) : null))
			.MapReferenceListValuesToDto();

			CreateMap<ConsultationReportContent, DocumentReferenceInput>()
				.ForMember(a => a.Date, b => b.MapFrom(c => c.AuthoredOn))
				.ForMember(a => a.Type, b => b.MapFrom(b => new ReferenceListItemValueDto() { ItemValue = (long?)RefListDocumentTypeValueSets.ConsultationReport }))
				.ForMember(a => a.ContextEncounterOwnerId, b => b.MapFrom(c => c.Encounter.Id.ToString()));




            CreateMap<ConsultationReportContent, Document>()
				.ForMember(c => c.Id, options => options.Ignore())
				.ForMember(e => e.Subject, e => e.MapFrom(e => GetEntity<Patient>(e.Subject)))
                .ForMember(e => e.Encounter, e => e.MapFrom(e => GetEntity<Encounter>(e.Encounter)))
                .ForMember(e => e.Type, e => e.MapFrom(e => RefListDocumentTypeValueSets.ConsultationReport))
            .MapReferenceListValuesToDto();

            CreateMap<Person, Document>()
				.ForMember(c => c.Id, options => options.Ignore())
				.ForMember(c => c.Practitioner, options => options.MapFrom(c => (c != null ? c : null)));
        }
	}
}
