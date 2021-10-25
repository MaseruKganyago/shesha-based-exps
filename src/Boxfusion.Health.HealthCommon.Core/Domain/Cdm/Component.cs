using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Component")]
	public class Component: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal ValueQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListComponentValues? ValueCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ValueString { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool ValueBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual int ValueInteger { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal ValueRangeLow { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal ValueRangeHigh { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal ValueRatioNumerator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal ValueRatioDenominator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ValueDateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ValueStartDateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ValueEndDateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string UnitOfMeasure { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Observation Observation { get; set; }
	}
}
