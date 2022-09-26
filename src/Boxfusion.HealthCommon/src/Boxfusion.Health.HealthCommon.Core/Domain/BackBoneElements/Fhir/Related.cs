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
	public class Related: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual Claim Claim { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "Relationship")]
		public virtual long? Relationship { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid? Reference { get; set; }
	}
}
