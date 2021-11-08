using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Domain;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
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

			//Ward
			CreateMap<Ward, HospitalisationEncounterInput>()
				.ForMember(a => a.DestinationOwnerId, opt => opt.MapFrom(b => b.Id))
				.ForMember(a => a.DestinationOwnerType, opt => opt.MapFrom(b => b.GetTypeShortAlias()));
		}
	}
}
