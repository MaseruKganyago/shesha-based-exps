using Abp.Domain.Entities.Auditing;
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
	[Entity(TypeShortAlias = "HealthCommon.Core.ConditionIcdTenCode")]
	public class ConditionIcdTenCode : FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual Condition Condition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual IcdTenCode IcdTenCode { get; set; }
	}
}
