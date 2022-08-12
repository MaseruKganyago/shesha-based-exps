using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir;
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
	[Entity(TypeShortAlias = "HealthCommon.Core.CoverageEligibilityResponse")]
	public class CoverageEligibilityResponse: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "CoverageEligibilityResponseStatus")]
		public virtual long? CoverageEligibilityResponseStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "CoverageEligibilityResponsePurpose")]
		public virtual long? CoverageEligibilityResponsePurpose { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Patient { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime ServicedStartDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime ServicedEndDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "CoverageEligibilityResponseOutcome")]
		public virtual long? OutCome { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation Insurer { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Insurance Insurance { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PreAuthRef { get; set; }
	}
}
