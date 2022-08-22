using Abp.Domain.Entities.Auditing;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Patients
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.PatientContact")]
	public class PatientContact: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string FirstName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string LastName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Cdm", "RelationshipTypes")]
		public virtual long? RelationshipType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string MobileNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string AlternativeNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Address Address { get; set; }
	}
}
