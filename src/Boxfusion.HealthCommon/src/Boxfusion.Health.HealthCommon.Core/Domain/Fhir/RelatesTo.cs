using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.RelatesTo", GenerateApplicationService = false)]
	public class RelatesTo: FullAuditedEntity<Guid>
	{
		[ReferenceList("Fhir", "DocumentRelationshipTypes")]
		public virtual int? Code { get; set; }
		public virtual DocumentReference Target { get; set; }
	}
}
