using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.MedicationRequest")]
	public class MedicationRequest: FullAuditedEntity<Guid>
	{
		public virtual string Identifier { get; set; }
		[ReferenceList("Fhir", "MedicationReuestStatuses")]
		public virtual int? Status { get; set; }
		[ReferenceList("Fhir", "MedicationRequestStatusReasonCodes")]
		public virtual int? StatusReason { get; set; }
		[ReferenceList("Fhir", "RequestIntents")]
		public virtual int? Intent { get; set; }
		[MultiValueReferenceList("Fhir", "MedicationRequestCategoryCodes")]
		public virtual int? Category { get; set; }
		[ReferenceList("Fhir", "RequestPriosities")]
		public virtual int? Priority { get; set; }
		public virtual bool DoNotPerform { get; set; }
		public virtual bool ReportedBoolean { get; set; }
		public virtual string ReportedReferenceOwnerId { get; set; }
		public virtual string ReportedReferenceOwnerType { get; set; }
		[MultiValueReferenceList("Fhir", "MedicationCodes")]
		public virtual int? MedicationCodeableConcept { get; set; }
		public virtual Medication MedicationReference { get; set; }
		public virtual Patient Subject { get; set; }
		public virtual Encounter Encounter { get; set; }
		public virtual string SupportingInformationOwnerId { get; set; }
		public virtual string SupportingInformationOwnerType { get; set; }
		public virtual DateTime? AuthoredOn { get; set; }
		public virtual string RequestorOwnerId { get; set; }
		public virtual string RequestorOwnerType { get; set; }
		public virtual string PerformerOwnerId { get; set; }
		public virtual string PerformerOwnerType { get; set; }
		[ReferenceList("Fhir", "MedicationRequestPerformerRoles")]
		public virtual int? PerformerType { get; set; }
		public virtual string RecordedOwnerId { get; set; }
		public virtual string RecordedOwnerType { get; set; }
		[MultiValueReferenceList("Fhir", "ConditionProblemDiagnosisCodes")]
		public virtual int? ReasonCode { get; set; }
		public virtual string ReasonReferenceOnwerId { get; set; }
		public virtual string ReasonReferenceOnwerType { get; set; }
		public virtual string BasedOnOwnerId { get; set; }
		public virtual string BasedOnOwnerType { get; set; }
		public virtual string GroupIdentifier { get; set; }
		[ReferenceList("Fhir", "MedicationRequestCourseTherapyCodes")]
		public virtual int? CourseOfTherapyType { get; set; }
		public virtual string InsuranceOwnerId { get; set; }
		public virtual string InsuranceOwnerType { get; set; }
		public virtual Dosage DosageInstruction { get; set; }
		public virtual DateTime? InitialFillQuantity { get; set; }
		public virtual TimeSpan? InitialFillDuration { get; set; }
		public virtual TimeSpan? DispenseInterval { get; set; }
		public virtual DateTime? ValidityPeriodStart { get; set; }
		public virtual DateTime? ValidityPeriodEnd { get; set; }
		public virtual ushort? NumberOfRepeatsAllowed { get; set; }
		public virtual decimal Quantity { get; set; }
		public virtual TimeSpan? ExpectedSupplyDuration { get; set; }
		public virtual bool AllowBoolean { get; set; }
		[ReferenceList("Fhir", "MedicatioRequestActSubstanceAdminSubstitutionCodes")]
		public virtual int? AllowCodeableConcept { get; set; }
		[ReferenceList("Fhir", "MedicationRequestSubstanceAdminSubstitutionReasons")]
		public virtual int? Reason { get; set; }
		public virtual MedicationRequest PriorPrescription { get; set; }
		//public virtual DectedIssue DectedIssue { get; set; }
		public virtual Provenance EventHistory { get; set; }
	}
}
