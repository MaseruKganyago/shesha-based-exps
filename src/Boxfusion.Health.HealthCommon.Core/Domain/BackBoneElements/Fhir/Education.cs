using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Education")]
	public class Education: FullAuditedEntity<Guid>
	{
		public virtual string DocumentType { get; set; }
		public virtual string Reference { get; set; }
		public virtual DateTime? MyProperty { get; set; }
		public virtual DateTime? PresentationDate { get; set; }
		public virtual Immunisation Immunisation { get; set; }
	}
}
