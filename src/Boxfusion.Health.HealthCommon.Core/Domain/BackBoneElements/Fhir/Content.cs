using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Content")]
	public class Content: FullAuditedEntity<Guid>
	{
		public virtual string OwnerId { get; set; }
		public virtual string OwnerType { get; set; }
		[ReferenceList("Fhir", "DocumentReferenceFormatCodeSets")]
		public virtual int? Format { get; set; }
	}
}
