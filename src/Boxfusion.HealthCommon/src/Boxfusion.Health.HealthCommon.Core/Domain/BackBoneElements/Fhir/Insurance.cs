using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
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
	[Entity(TypeShortAlias = "HealthCommon.Core.Insurance")]
	public class Insurance: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual Coverage Coverage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual bool Inforce { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime BenefitPeriodStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? BenefitPeriodEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Item Item { get; set; }

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
