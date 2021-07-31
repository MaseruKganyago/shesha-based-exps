using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.ServiceRequest")]
	public class ServiceRequest: FullAuditedEntity<Guid>
	{
		public virtual string Identifier { get; set; }
		public virtual string BasedOnOwnerId { get; set; }
		public virtual string BasedOnOwnerType { get; set; }
		public virtual ServiceRequest Replaces { get; set; }
		public virtual string Requisition { get; set; }
		[ReferenceList("Fhir", "ServiceRequestStatuses")]
		public virtual int? Status { get; set; }
		[ReferenceList("Fhir", "RequestIntents")]
		public virtual int? Intent { get; set; }
		[MultiValueReferenceList("Fhir", "RefListServiceRequestCategoryCodes")]
		public virtual int? Category { get; set; }
		[ReferenceList("Fhir", "RequestPriosities")]
		public virtual int? Priority { get; set; }
		public virtual bool DoNotPerform { get; set; }
		[ReferenceList("Fhir", "ServiceRequestProcedureCodes")]
		public virtual int? Code { get; set; }
		[MultiValueReferenceList("Fhir", "ServiceRequestOrderDetails")]
		public virtual int? OrderDetail { get; set; }
		public virtual decimal QuantityQuantity { get; set; }
		public virtual decimal QuantityRatioNumerator { get; set; }
		public virtual decimal QuantityRatioDenominator { get; set; }
		public virtual decimal QuantityRangeLow { get; set; }
		public virtual decimal QuantityRangeHigh { get; set; }
		public virtual Patient Subject { get; set; }
		public virtual Encounter Encounter { get; set; }
		public virtual DateTime? OccurenceDateTime { get; set; }
		public virtual DateTime? OccurencePeriodStart { get; set; }
		public virtual DateTime? OccurencePeriodEnd { get; set; }
		public virtual bool AsNeededBoolean { get; set; }
		[ReferenceList("Fhir", "ServiceRequestMedicationAsNeededReasons")]
		public virtual int? AsNeededCodeableConcept { get; set; }
		public virtual DateTime? AutheredOn { get; set; }
		public virtual string RequestOwnerId { get; set; }
		public virtual string RequestOwnerType { get; set; }
		[ReferenceList("Fhir", "ServiceRequestParticipantRoles")]
		public virtual int? PerformerType { get; set; }
		public virtual string PerformerOwnerId { get; set; }
		public virtual string PerformerOwnerType { get; set; }
		[MultiValueReferenceList("Fhir", "ServiceDeliveryLocationRoleTypes")]
		public virtual int? LocationCode { get; set; }
		public virtual FhirLocation LocationReference { get; set; }
		[MultiValueReferenceList("Fhir", "ServiceRequestProcedureReasons")]
		public virtual int? ReasonCode { get; set; }
		public virtual string ReasonReferenceOwnerId { get; set; }
		public virtual string ReasonReferenceOwnerType { get; set; }
		public virtual string InsuranceOwnerId { get; set; }
		public virtual string InsuranceOwnerType { get; set; }
		public virtual string SupportingInfoOwnerId { get; set; }
		public virtual string SupportingInfoOwnerType { get; set; }
		public virtual Specimen Specimen { get; set; }
		[MultiValueReferenceList("Fhir", "BodySites")]
		public virtual int? BodySite { get; set; }
		public virtual string PatientInstruction { get; set; }
		public virtual Provenance RelevantHistory { get; set; }
	}
}
