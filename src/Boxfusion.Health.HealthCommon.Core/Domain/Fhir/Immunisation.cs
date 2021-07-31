using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Immunization")]
	public class Immunisation: FullAuditedEntity<Guid>
	{
		public virtual string Identifier { get; set; }
		[ReferenceList("Fhir", "ImmunisationStatuses")]
		public virtual int? Status { get; set; }
		[ReferenceList("Fhir", "ImmunisationStatusReasons")]
		public virtual int? StatusReason { get; set; }
		[ReferenceList("Fhir", "ImmunisationVaccineCodes")]
		public virtual int? VaccineCode { get; set; }
		public virtual Patient Patient { get; set; }
		public virtual Encounter Encounter { get; set; }
		public virtual DateTime? OccurenceDateTime { get; set; }
		public virtual string OccurenceString { get; set; }
		public virtual DateTime? Recorded { get; set; }
		public virtual bool PrimarySource { get; set; }
		[ReferenceList("Fhir", "ImmunisationOriginCodes")]
		public virtual int? ReportOrigin { get; set; }
		public virtual FhirLocation Location { get; set; }
		public virtual FhirOrganisation Manufacture { get; set; }
		public virtual string LotNumber { get; set; }
		public virtual DateTime? ExpirationDate { get; set; }
		[ReferenceList("Fhir", "CodesForImmunizationSiteOfAdministrations")]
		public virtual int? Site { get; set; }
		[ReferenceList("Fhir", "ImmunisationRouteCodes")]
		public virtual int? Route { get; set; }
		public virtual decimal DoseQuantity { get; set; }
		[ReferenceList("Fhir", "ImmunisationFunctionCodes")]
		public virtual int? PerformerFunction { get; set; }
		public virtual string PerformerActorOwnerId { get; set; }
		public virtual string PerformerActorOwnerType { get; set; }
		[MultiValueReferenceList("Fhir", "ImmunisationReasonCodes")]
		public virtual int? ReasonCode { get; set; }
		public virtual string ReasonReferenceOwnerId { get; set; }
		public virtual string ReasonReferenceOwnerType { get; set; }
		public virtual bool IsSubpotent { get; set; }
		[MultiValueReferenceList("Fhir", "ImmunisationSubpotentReasons")]
		public virtual int? SubpotentReason { get; set; }
		[MultiValueReferenceList("Fhir", "ImmunisationProgramEligibilities")]
		public virtual int? ProgramEligiibility { get; set; }
		[ReferenceList("Fhir", "ImmunisationFundingSources")]
		public virtual int? FundingSource { get; set; }

	}
}
