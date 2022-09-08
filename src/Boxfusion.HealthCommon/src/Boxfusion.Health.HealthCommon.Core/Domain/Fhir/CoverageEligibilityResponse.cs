using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public virtual Coverage InsuranceCoverage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual bool InsuranceInforce { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? InsuranceBenefitPeriodStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? InsuranceBenefitPeriodEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ItemCategory")]
		public virtual long? ItemCategory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ItemProductOrService")]
		public virtual long? ItemProductOrService { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual bool ItemExcluded { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ItemName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(510)]
		public virtual string ItemDescription { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ItemUnit")]
		public virtual long? ItemUnit { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ItemTerm")]
		public virtual long? ItemTerm { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PreAuthRef { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "BenefitType")]
		public virtual long? BenefitType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal BenefitAllowedMoney { get; set; }
	}
}
