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
	[Entity(TypeShortAlias = "HealthCommon.Core.Item")]
	public class Item: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ItemCategory")]
		public virtual long? Category { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ItemProductOrService")]
		public virtual long? ProductOrService { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual bool Excluded { get; set; }

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
		[ReferenceList("Fhir", "ItemUnit")]
		public virtual long? Unit { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ItemTerm")]
		public virtual long? Term { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Benefit Benefit { get; set; }

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
