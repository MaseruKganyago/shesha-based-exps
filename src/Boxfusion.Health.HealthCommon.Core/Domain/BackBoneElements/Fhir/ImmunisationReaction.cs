using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[Entity(TypeShortAlias = "HeathCommon.Core.ImmunisationReaction")]
	public class ImmunisationReaction: FullAuditedEntity<Guid>
	{
		public virtual string Date { get; set; }
		public virtual Observation Detail { get; set; }
		public virtual bool Reported { get; set; }
		public virtual Immunisation Immunisation { get; set; }
	}
}
