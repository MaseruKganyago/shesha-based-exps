using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Reaction")]
	public class Reaction: FullAuditedEntity<Guid>
	{
		[ReferenceList("Fhir", "AllergyIntoleranceSeverities")]
		public virtual int? Substance { get; set; }
		[MultiValueReferenceList("Fhir", "SNOMEDCTRouteCodes")]
		public virtual int? Manifestation { get; set; }
		public virtual string Description { get; set; }
		public virtual DateTime? OnSet { get; set; }
		[ReferenceList("Fhir", "AllergyIntoleranceSeverities")]
		public virtual int? Severity { get; set; }
		[ReferenceList("Fhir", "SNOMEDCTRouteCodes")]
		public virtual int? ExposureRoute { get; set; }
		public virtual string OwnerId { get; set; }
		public virtual string OwnerType { get; set; }
	}
}
