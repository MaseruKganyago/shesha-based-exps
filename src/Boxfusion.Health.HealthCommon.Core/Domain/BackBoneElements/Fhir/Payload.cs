using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Payload")]
	public class Payload: FullAuditedEntity<Guid>
	{
		public virtual string ContentString { get; set; }
		public virtual string ContentReferenceOwnerId { get; set; }
		public virtual string ContentReferenceOwnerType { get; set; }
	}
}
