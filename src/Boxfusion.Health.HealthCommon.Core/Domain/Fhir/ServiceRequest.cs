using Abp.Domain.Entities.Auditing;
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
	[Entity(TypeShortAlias = "HealthCommon.Core.ServiceRequest")]
	[Table("Fhir_ServiceRequests")]
	[Discriminator]

	public class ServiceRequest: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string Identifier { get; set; }
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
		public virtual ServiceRequest Replaces { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Requisition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListServiceRequestStatuses? Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListRequestIntents? Intent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ServiceRequestCategoryCodes")]
		public virtual RefListServiceRequestCategoryCodes? Category { get; set; }
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
		public virtual RefListServiceRequestProcedureCodes? Code { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ServiceRequestOrderDetails")]
		public virtual RefListServiceRequestOrderDetails? OrderDetail { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal QuantityQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal QuantityRatioNumerator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal QuantityRatioDenominator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal QuantityRangeLow { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal QuantityRangeHigh { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Subject { get; set; }
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
		public virtual DateTime? OccurencePeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? OccurencePeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool AsNeededBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListServiceRequestMedicationAsNeededReasons? AsNeededCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? AuthoredOn { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RequestOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RequestOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListServiceRequestParticipantRoles? PerformerType { get; set; }
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
		public virtual RefListServiceDeliveryLocationRoleTypes? LocationCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual FhirLocation LocationReference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ServiceRequestProcedureReasons")]
		public virtual RefListServiceRequestProcedureReasons? ReasonCode { get; set; }
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
		public virtual string InsuranceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string InsuranceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string SupportingInfoOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string SupportingInfoOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Specimen Specimen { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "BodySites")]
		public virtual RefListBodySite? BodySite { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PatientInstruction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Provenance RelevantHistory { get; set; }
	}
}
