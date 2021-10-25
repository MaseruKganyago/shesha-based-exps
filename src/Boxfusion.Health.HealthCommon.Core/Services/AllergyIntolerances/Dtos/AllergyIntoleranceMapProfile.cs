using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.AllergyIntolerances.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	public class AllergyIntoleranceMapProfile: ShaProfile
	{
		/// <summary>
		/// 
		/// </summary>
		public AllergyIntoleranceMapProfile()
		{
			CreateMap<AllergyIntoleranceInput, AllergyIntolerance>()
				.ForMember(a => a.Patient, options => options.MapFrom(b => b.Patient != null ? GetEntity<Patient>(b.Patient.Id) : null))
				.ForMember(a => a.Encounter, options => options.MapFrom(b => b.Encounter != null ? GetEntity<Encounter>(b.Encounter.Id) : null))
				.ForMember(a => a.Recorder, options => options.MapFrom(b => b.Recorder != null ? GetEntity<PersonFhirBase>(b.Recorder.Id) : null))
				.ForMember(a => a.Asserter, options => options.MapFrom(b => b.Asserter != null ? GetEntity<PersonFhirBase>(b.Asserter.Id) : null))
				.ForMember(a => a.Code, options => options.Ignore())
				.MapReferenceListValuesFromDto();

			CreateMap<AllergyIntolerance, AllergyIntoleranceResponse>()
				.ForMember(a => a.Patient, options => options.MapFrom(b => b.Patient != null ? new EntityWithDisplayNameDto<Guid>(b.Patient.Id, b.Patient.FullName) : null))
				.ForMember(a => a.Encounter, options => options.MapFrom(b => b.Encounter != null ? new EntityWithDisplayNameDto<Guid>(b.Encounter.Id, b.Encounter.Identifier) : null))
				.ForMember(a => a.Recorder, options => options.MapFrom(b => b.Recorder != null ? new EntityWithDisplayNameDto<Guid>(b.Recorder.Id, b.Recorder.FullName) : null))
				.ForMember(a => a.Asserter, options => options.MapFrom(b => b.Asserter != null ? new EntityWithDisplayNameDto<Guid>(b.Asserter.Id, b.Asserter.FullName) : null))
				.ForMember(a => a.AllergyCodes, options => options.Ignore())
				.MapReferenceListValuesToDto();

			CreateMap<AllergyIntoleranceCodeAssignment, EntityWithDisplayNameDto<Guid?>>()
				.ForMember(a => a.Id, options => options.MapFrom(b => b.Id))
				.ForMember(a => a.DisplayText, options => options.MapFrom(b => $"{b.AllergyIntoleranceCode.Code} {b.AllergyIntoleranceCode.Description}"));
		}
	}
}
