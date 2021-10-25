using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Diagnoses.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	public class DiagnosisMapProfile: ShaProfile
	{
		/// <summary>
		/// 
		/// </summary>
		public DiagnosisMapProfile()
		{
			CreateMap<DiagnosisInput, Diagnosis>()
				.ForMember(a => a.Condition, options => options.MapFrom(b => b.Condition.Id == null ? GetEntity<Condition>(b.Condition.Id) : null))
				.MapReferenceListValuesFromDto();

			CreateMap<Diagnosis, DiagnosisResponse>()
				.ForMember(a => a.Condition, options => options.Ignore())
				.MapReferenceListValuesToDto();
		}
	}
}
