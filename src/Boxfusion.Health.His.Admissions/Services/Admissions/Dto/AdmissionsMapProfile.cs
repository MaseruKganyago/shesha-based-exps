using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Domain;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
	/// <summary>
	/// 
	/// </summary>
	public class AdmissionsMapProfile: ShaProfile
	{
		/// <summary>
		/// 
		/// </summary>
		public AdmissionsMapProfile()
		{
			//AdmissionsPatient
			CreateMap<AdmitPatientInput, AdmissionsPatient>()
				.MapReferenceListValuesFromDto();

			CreateMap<AdmissionsPatient, AdmitPatientResponse>()
				.MapReferenceListValuesToDto();

			//HospitalisationEncounter
			CreateMap<AdmitPatientInput, HospitalisationEncounterInput>()
				.ForMember(a => a.PreAdmissionIdentifier, opt => opt.MapFrom(b => b.AdmissionNumber))
				.ForMember(a => a.StartDateTime, opt => opt.MapFrom(b => b.AdmissionDate))
				.MapReferenceListValuesFromDto();

			CreateMap<HospitalisationEncounter, AdmitPatientResponse>()
				.ForMember(a => a.AdmissionNumber, opt => opt.MapFrom(b => b.PreAdmissionIdentifier))
				.ForMember(a => a.AdmissionDate, opt => opt.MapFrom(b => b.StartDateTime))
				.MapReferenceListValuesToDto();

			CreateMap<HospitalisationEncounterInput, HospitalisationEncounter>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => GetEntity<Appointment>(b.Appointment)))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => GetEntity<ServiceRequest>(b.BasedOn)))
				.ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => GetEntity<EpisodeOfCare>(b.EpisodeOfCare)))
				.ForMember(a => a.Performer, options => options.MapFrom(b => GetEntity<Person>(b.Performer)))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.ServiceProvider)))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
				.MapReferenceListValuesFromDto();

			//Ward
			CreateMap<Ward, HospitalisationEncounterInput>()
				.ForMember(a => a.Id, opt => opt.Ignore())
				.ForMember(a => a.DestinationOwnerId, opt => opt.MapFrom(b => b.Id))
				.ForMember(a => a.DestinationOwnerType, opt => opt.MapFrom(b => b.GetTypeShortAlias()));
		}
	}
}
