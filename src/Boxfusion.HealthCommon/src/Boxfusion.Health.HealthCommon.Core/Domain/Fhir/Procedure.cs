using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Procedure")]
    [Discriminator]
    public class Procedure : FullAuditedEntity<Guid>
    {
        public virtual string Identifier { get; set; }

        public virtual string BasedOnOwnerId { get; set; }

        public virtual string BasedOnOwnerType { get; set; }

        public virtual string PartOfOwnerId { get; set; }

        public virtual string PartOfOwnerType { get; set; }

        [ReferenceList("Fhir", "EventStatuses")]
        public virtual int? Status { get; set; }

        [ReferenceList("Fhir", "ProcedureNotPerformedReasons")]
        public virtual int? StatusReason { get; set; }

        [MultiValueReferenceList("Fhir", "ProcedureCategories")]
        public virtual RefListProcedureCategories Category { get; set; }

        [ReferenceList("Cdm", "ProcedureCodingSystem")]
        public virtual int? CodingSystem { get; set; }

		[ReferenceList("Fhir", "ProcedureCodes")]
        public virtual int? CodeValue { get; set; }

		public virtual string CodeText { get; set; }

		public virtual Patient Subject { get; set; }

        public virtual Encounter Encounter { get; set; }

        public virtual DateTime? PerformedDateTime { get; set; }

        public virtual DateTime? PerformedPeriodStart { get; set; }

        public virtual string PerformedString { get; set; }

        public virtual int? PerformedAge { get; set; }

        public virtual decimal? PerformedRangeLow { get; set; }

        public virtual decimal? PerformedRangeHigh { get; set; }

		public virtual PersonFhirBase Recorder { get; set; }

		public virtual PersonFhirBase Asserter { get; set; }

		//public virtual string RecorderOwnerId { get; set; }

        //public virtual string RecorderOwnerType { get; set; }

        //public virtual string AsserterOwnerId { get; set; }

        //public virtual string AsserterOwnerType { get; set; }

        [ReferenceList("Fhir", "MedicationRequestPerformerRoles")]
        public virtual int? PerformerFunction { get; set; }

        public virtual string PerformerActorOwnerId { get; set; }

        public virtual string PerformerActorOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase Performer { get; set; }

        public virtual FhirOrganisation PerformerOnBehalfOf { get; set; }

        public virtual FhirLocation Location { get; set; }

        [MultiValueReferenceList("Fhir", "ConditionProblemDiagnosisCodes")]
        public virtual RefListConditionProblemDiagnosisCodes ReasonCode { get; set; }

        public virtual string ReasonReferenceOwnerId { get; set; }

        public virtual string ReasonReferenceOwnerType { get; set; }

        [MultiValueReferenceList("Fhir", "BodySite")]
        public virtual RefListBodySite BodySite { get; set; }

        [ReferenceList("Fhir", "ProcedureOutcomes")]
        public virtual int? Outcome { get; set; }

        public virtual string ReportOwnerId { get; set; }

        public virtual string ReportOwnerType { get; set; }

        [MultiValueReferenceList("Fhir", "ConditionProblemDiagnosisCodes")]
        public virtual RefListConditionProblemDiagnosisCodes Complication { get; set; }

        public virtual Condition ComplicationDetail { get; set; }

        [MultiValueReferenceList("Fhir", "ProcedureFollowUpCodes")]
        public virtual RefListProcedureFollowUp FollowUp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Medication ProcedureMedication { get; set; }
    }
}
