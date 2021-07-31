using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Component")]
	public class Component: FullAuditedEntity<Guid>
	{
		public virtual decimal ValueQuantity { get; set; }
		[ReferenceList("Cdm", "ComponentValues")]
		public virtual int? ValueCodeableConcept { get; set; }
		public virtual string ValueString { get; set; }
		public virtual bool ValueBoolean { get; set; }
		public virtual int ValueInteger { get; set; }
		public virtual decimal ValueRangeLow { get; set; }
		public virtual decimal ValueRangeHigh { get; set; }
		public virtual decimal ValueRatioNumerator { get; set; }
		public virtual decimal ValueRatioDenominator { get; set; }
		public virtual DateTime? ValueDateTime { get; set; }
		public virtual DateTime? ValueStartDateTime { get; set; }
		public virtual DateTime? ValueEndDateTime { get; set; }
		public virtual string UnitOfMeasure { get; set; }
		public virtual Observation Observation { get; set; }
	}
}
