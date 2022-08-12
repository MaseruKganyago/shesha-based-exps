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
	[Entity(TypeShortAlias = "HealthCommon.Core.AllergyIntoleranceCodeAssignment")]
	public class AllergyIntoleranceCodeAssignment: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual AllergyIntoleranceCode AllergyIntoleranceCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual AllergyIntolerance AllergyIntolerance { get; set; }
	}
}
