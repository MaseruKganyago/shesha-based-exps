using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.ProtocolApplied")]
	public class ProtocolApplied: FullAuditedEntity<Guid>
	{
		public virtual string Series { get; set; }
		public virtual FhirOrganisation Authority { get; set; }
		[MultiValueReferenceList("Fhir", "ImmunizationTargetDiseaseCodes")]
		public virtual int? TargetDisease { get; set; }
		public virtual int? DoseNumberPositiveInt { get; set; }
		public virtual string DoseNumberString { get; set; }
		public virtual int? SeriesDosesPositiveInt { get; set; }
		public virtual int? SeriesDosesString { get; set; }
		public virtual Immunisation Immunisation { get; set; }
	}
}
