using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
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
	public class Payee: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "PayeeType")]
		public virtual long? PayeeType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Practitioner PayeePerson { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation PayeeOrganisation { get; set; }
	}
}
