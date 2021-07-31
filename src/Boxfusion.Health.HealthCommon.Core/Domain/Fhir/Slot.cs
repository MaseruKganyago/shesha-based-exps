using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Slot")]
	public class Slot: FullAuditedEntity<Guid>
	{
	}
}
