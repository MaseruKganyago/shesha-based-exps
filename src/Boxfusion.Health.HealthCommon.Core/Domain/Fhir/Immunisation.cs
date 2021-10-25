using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Immunization")]
	public class Immunisation: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string Identifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListImmunisationStatuses? Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListImmunisationStatusReasons? StatusReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListImmunisationVaccineCodes? VaccineCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Patient { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Encounter Encounter { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? OccurenceDateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string OccurenceString { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Recorded { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool PrimarySource { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListImmunisationOriginCodes? ReportOrigin { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual FhirLocation Location { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation Manufacture { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string LotNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ExpirationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListCodesForImmunisationSiteOfAdmistrations? Site { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListImmunisationRouteCodes? Route { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DoseQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListImmunisationFunctionCodes? PerformerFunction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerActorOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerActorOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ImmunisationReasonCodes")]
		public virtual RefListImmunisationReasonCodes? ReasonCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReasonReferenceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReasonReferenceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool IsSubpotent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ImmunisationSubpotentReasons")]
		public virtual RefListImmunisationSubpotentReasons? SubpotentReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ImmunisationProgramEligibilities")]
		public virtual RefListImmunisationProgramEligibilities? ProgramEligibility { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListImmunisationFundingSources? FundingSource { get; set; }

	}
}
