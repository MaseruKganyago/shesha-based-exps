using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsultationEncounterMapProfile : ShaProfile
	{
		/// <summary>
		/// 
		/// </summary>
		public ConsultationEncounterMapProfile()
		{
			CreateMap<ConsultationEncounterInput, ConsultationEncounter>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => GetEntity<Appointment>(b.Appointment)))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => GetEntity<ServiceRequest>(b.BasedOn)))
				.ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<Patient>(b.Subject)))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => GetEntity<EpisodeOfCare>(b.EpisodeOfCare)))
				.ForMember(a => a.Performer, options => options.MapFrom(b => GetEntity<Practitioner>(b.Performer)))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => GetEntity<FhirOrganisation>(b.ServiceProvider)))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.ReasonCode)))
				.ForMember(a => a.FollowupAppointment, options => options.MapFrom(b => GetEntity<Appointment>(b.FollowupAppointment)))
				.ForMember(a => a.CHWWorkOrder, options => options.MapFrom(b => GetEntity<ChwWorkOrder>(b.CHWWorkOrder)))
				.ForMember(e => e.StartDateTime, e => e.MapFrom(e => DateTime.Now))
				.MapReferenceListValuesFromDto();

			CreateMap<ConsultationEncounter, ConsultationEncounterResponse>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => b.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(b.Appointment.Id, "") : null))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => b.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(b.BasedOn.Id, b.BasedOn.Identifier) : null))
				.ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, b.Subject.FullName) : null))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => b.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(b.EpisodeOfCare.Id, "") : null))
				.ForMember(a => a.Performer, options => options.MapFrom(b => b.Performer != null ? new EntityWithDisplayNameDto<Guid?>(b.Performer.Id, b.Performer.FullName) : null))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => b.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(b.ServiceProvider.Id, b.ServiceProvider.Name) : null))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => b.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(b.PartOf.Id, b.PartOf.Identifier) : null))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.ReasonCode)))
				.ForMember(a => a.FollowupAppointment, options => options.MapFrom(b => b.FollowupAppointment != null ? new EntityWithDisplayNameDto<Guid?>(b.FollowupAppointment.Id, "") : null))
				.ForMember(a => a.CHWWorkOrder, options => options.MapFrom(b => b.CHWWorkOrder != null ? new EntityWithDisplayNameDto<Guid?>(b.CHWWorkOrder.Id, "") : null))
				.MapReferenceListValuesToDto();

			CreateMap<ConsultationEncounter, ConsultationEncounterInput>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => b.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(b.Appointment.Id, "") : null))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => b.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(b.BasedOn.Id, b.BasedOn.Identifier) : null))
				.ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, b.Subject.FullName) : null))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => b.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(b.EpisodeOfCare.Id, "") : null))
				.ForMember(a => a.Performer, options => options.MapFrom(b => b.Performer != null ? new EntityWithDisplayNameDto<Guid?>(b.Performer.Id, b.Performer.FullName) : null))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => b.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(b.ServiceProvider.Id, b.ServiceProvider.Name) : null))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => b.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(b.PartOf.Id, b.PartOf.Identifier) : null))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.ReasonCode)))
				.ForMember(a => a.FollowupAppointment, options => options.MapFrom(b => b.FollowupAppointment != null ? new EntityWithDisplayNameDto<Guid?>(b.FollowupAppointment.Id, "") : null))
				.ForMember(a => a.CHWWorkOrder, options => options.MapFrom(b => b.CHWWorkOrder != null ? new EntityWithDisplayNameDto<Guid?>(b.CHWWorkOrder.Id, "") : null))
				.MapReferenceListValuesToDto();

			CreateMap<int, ReferenceListItemValueDto>()
				.MapReferenceListValuesToDto();


            CreateMap<ConsultationEncounter, FeedBackResponse>()
                .ForMember(a => a.Encounter, options => options.MapFrom(b => b.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(b.Id, b.Identifier) : null))
                .MapReferenceListValuesToDto();

            CreateMap<FollowUpInput, ConsultationEncounter>()
				.ForMember(a => a.Id, options => options.Ignore())
				.ForMember(a => a.FollowupRequired, options => options.MapFrom(b => true))
				.ForMember(a => a.FollowupNotificationStatus, options => options.MapFrom(b => RefListFollowupNotificationStatuses.pending))
				.MapReferenceListValuesFromDto();

			CreateMap<FollowUpFeedbackInput, ConsultationEncounter>()
				.ForMember(a => a.Id, options => options.Ignore());
		}
	}
}
