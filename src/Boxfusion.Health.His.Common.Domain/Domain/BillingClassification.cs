using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.BillingClassification")]
	public class BillingClassification: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "BillingClassificationType")]
		public virtual long? ClassificationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DiscountPercent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation DefaultPayor { get; set; }
	}
}
