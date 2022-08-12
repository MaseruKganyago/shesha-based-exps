using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.MedicationRequest")]
	[Table("Fhir_MedicationRequests")]
	[Discriminator]
	public class MedicationRequest: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string Identifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationRequestStatuses? Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationRequestStatusReasonCodes? StatusReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListRequestIntents? Intent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "MedicationRequestCategoryCodes")]
		public virtual RefListMedicationRequestCategoryCodes? Category { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListRequestPriorities? Priority { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool DoNotPerform { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool ReportedBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReportedReferenceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReportedReferenceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "MedicationCodes")]
		public virtual RefListMedicationCodes? MedicationCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Medication MedicationReference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual CdmPatient Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Encounter Encounter { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string SupportingInformationOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string SupportingInformationOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? AuthoredOn { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RequesterOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RequesterOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationRequestPerformerRoles? PerformerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RecordedOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RecordedOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ConditionProblemDiagnosisCodes")]
		public virtual RefListConditionProblemDiagnosisCodes? ReasonCode { get; set; }
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
		public virtual string BasedOnOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string BasedOnOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string GroupIdentifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationRequestCourseTherapyCodes? CourseOfTherapyType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string InsuranceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string InsuranceOwnerType { get; set; }
		///// <summary>
		///// 
		///// </summary>
		//public virtual Dosage DosageInstruction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? InitialFillQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual TimeSpan? InitialFillDuration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual TimeSpan? DispenseInterval { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ValidityPeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ValidityPeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual int? NumberOfRepeatsAllowed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal? Quantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual TimeSpan? ExpectedSupplyDuration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool AllowBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicatioRequestActSubstanceAdminSubstitutionCodes? AllowCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationRequestSubstanceAdminSubstitutionReasons? Reason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual MedicationRequest PriorPrescription { get; set; }
		/// <summary>
		/// 
		/// </summary>
		//public virtual DectedIssue DectedIssue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		//public virtual Provenance EventHistory { get; set; }
	}
}
