using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.ConditionIcdTenCode")]
	[Table("Fhir_ConditionIcdTenCodes")]
	[Discriminator]
	//TODO:IH: THIS SHOULD RATHER HAVE BEEN INHERITANCE STRUCTURE OR EVEN MADE PART OF THE BASE CLASS TO REDUCE COMPLEXITY AND IMPROVEPERFORMANCE
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
