using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.ClaimResponse")]
	public class ClaimResponse: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListClaimResponseStatus? Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ClaimResponseType")]
		public virtual long? Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ClaimResponseSubType")]
		public virtual long? SubType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ClaimResponseUse")]
		public virtual long? Use { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Patient { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Created { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation Insurer { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation RequestorOrganisation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Practitioner RequestorPractitioner { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Claim Claim { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListOutCome? OutCome { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Disposition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PreAuthRef { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? PreAuthDateStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? PreAuthDateEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ClaimResponsePayeeType")]
		public virtual long? PayeeType { get; set; }
	}
}
