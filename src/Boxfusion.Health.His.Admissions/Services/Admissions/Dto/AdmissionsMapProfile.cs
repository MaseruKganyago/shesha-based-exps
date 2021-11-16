using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Domain;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Dtos;
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
			CreateMap<HisPatientInput, HisPatient>()
				.MapReferenceListValuesFromDto();

			CreateMap<HisPatient, HisPatientResponse>()
				.MapReferenceListValuesToDto();

			//WardAdmission
			CreateMap<WardAdmissionInput, WardAdmission>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => GetEntity<Appointment>(b.Appointment)))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => GetEntity<ServiceRequest>(b.BasedOn)))
				.ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<HisPatient>(b.Subject)))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => GetEntity<EpisodeOfCare>(b.EpisodeOfCare)))
				.ForMember(a => a.Performer, options => options.MapFrom(b => GetEntity<PersonFhirBase>(b.Performer)))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => GetEntity<Hospital>(b.ServiceProvider)))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.ReasonCode)))
				.ForMember(a => a.AdmissionDestinationWard, options => options.MapFrom(b => GetEntity<Ward>(b.AdmissionDestinationWard)))
				.ForMember(a => a.SeparationDestinationWard, options => options.MapFrom(b => GetEntity<Ward>(b.AdmissionDestinationWard)))
				.MapReferenceListValuesFromDto();

			CreateMap<WardAdmission, WardAdmissionResponse>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => b.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(b.Appointment.Id, "") : null))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => b.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(b.BasedOn.Id, b.BasedOn.Identifier) : null))
				.ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, b.Subject.FullName) : null))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => b.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(b.EpisodeOfCare.Id, "") : null))
				.ForMember(a => a.Performer, options => options.MapFrom(b => b.Performer != null ? new EntityWithDisplayNameDto<Guid?>(b.Performer.Id, b.Performer.FullName) : null))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => b.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(b.ServiceProvider.Id, b.ServiceProvider.Name) : null))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => b.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(b.PartOf.Id, b.PartOf.Identifier) : null))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.ReasonCode)))
				.ForMember(a => a.AdmissionDestinationWard, options => options.MapFrom(b => b.AdmissionDestinationWard != null ? new EntityWithDisplayNameDto<Guid?>(b.AdmissionDestinationWard.Id, b.AdmissionDestinationWard.Name) : null))
				.ForMember(a => a.SeparationDestinationWard, options => options.MapFrom(b => b.SeparationDestinationWard != null ? new EntityWithDisplayNameDto<Guid?>(b.SeparationDestinationWard.Id, b.SeparationDestinationWard.Name) : null))
				.MapReferenceListValuesToDto();

			//HospitalAdmission
			CreateMap<HospitalAdmissionInput, HospitalAdmission>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => GetEntity<Appointment>(b.Appointment)))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => GetEntity<ServiceRequest>(b.BasedOn)))
				.ForMember(a => a.Subject, options => options.MapFrom(b => GetEntity<HisPatient>(b.Subject)))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => GetEntity<EpisodeOfCare>(b.EpisodeOfCare)))
				.ForMember(a => a.Performer, options => options.MapFrom(b => GetEntity<PersonFhirBase>(b.Performer)))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => GetEntity<Hospital>(b.ServiceProvider)))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => GetEntity<Encounter>(b.PartOf)))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.ReasonCode)))
				.MapReferenceListValuesFromDto();

			CreateMap<HospitalAdmission, HospitalAdmissionResponse>()
				.ForMember(a => a.Appointment, options => options.MapFrom(b => b.Appointment != null ? new EntityWithDisplayNameDto<Guid?>(b.Appointment.Id, "") : null))
				.ForMember(a => a.BasedOn, options => options.MapFrom(b => b.BasedOn != null ? new EntityWithDisplayNameDto<Guid?>(b.BasedOn.Id, b.BasedOn.Identifier) : null))
				.ForMember(a => a.Subject, options => options.MapFrom(b => b.Subject != null ? new EntityWithDisplayNameDto<Guid?>(b.Subject.Id, b.Subject.FullName) : null))
				.ForMember(a => a.EpisodeOfCare, options => options.MapFrom(b => b.EpisodeOfCare != null ? new EntityWithDisplayNameDto<Guid?>(b.EpisodeOfCare.Id, "") : null))
				.ForMember(a => a.Performer, options => options.MapFrom(b => b.Performer != null ? new EntityWithDisplayNameDto<Guid?>(b.Performer.Id, b.Performer.FullName) : null))
				.ForMember(a => a.ServiceProvider, options => options.MapFrom(b => b.ServiceProvider != null ? new EntityWithDisplayNameDto<Guid?>(b.ServiceProvider.Id, b.ServiceProvider.Name) : null))
				.ForMember(a => a.PartOf, options => options.MapFrom(b => b.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(b.PartOf.Id, b.PartOf.Identifier) : null))
				.ForMember(a => a.ReasonCode, options => options.MapFrom(b => UtilityHelper.GetMultiReferenceListItemValueList(b.ReasonCode)))
				.MapReferenceListValuesToDto();

			//Diagnosis
			CreateMap<DiagnosisInput, Diagnosis>()
				.ForMember(a => a.Condition, options => options.MapFrom(b => b.Condition.Id != null ? GetEntity<Condition>(b.Condition.Id) : null))
				.MapReferenceListValuesFromDto();

			CreateMap<Diagnosis, DiagnosisResponse>()
				.ForMember(a => a.Condition, options => options.Ignore())
				.MapReferenceListValuesToDto();

			CreateMap<ConditionIcdTenCode, EntityWithDisplayNameDto<Guid?>>()
				.ForMember(a => a.Id, options => options.MapFrom(b => b.Id))
				.ForMember(a => a.DisplayText, options => options.MapFrom(b => $"{b.IcdTenCode.ICDTenThreeCode} {b.IcdTenCode.WHOFullDesc}"));
		}
	}
}
