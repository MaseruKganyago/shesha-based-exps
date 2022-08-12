using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Benefit")]
	public class Benefit: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "BenefitType")]
		public virtual long? Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal AllowedMoney { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerType { get; set; }
	}
}
