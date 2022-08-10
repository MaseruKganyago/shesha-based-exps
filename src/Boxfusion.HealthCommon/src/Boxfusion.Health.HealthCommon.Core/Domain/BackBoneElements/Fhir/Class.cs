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
	public class Class: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ClassType")]
		public virtual long? Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Value { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Name { get; set; }

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
