using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.MedicationStatement")]
    public class MedicationStatement : FullAuditedEntity<Guid>
    {
        public virtual string BasedOnOwnerId { get; set; }
        public virtual string BasedOnOwnerType { get; set; }
        public virtual string PartOfOwnerId { get; set; }
        public virtual string PartOfOwnerType { get; set; }
        public virtual RefListMedicationStatementStatus Status { get; set; }
        [MultiValueReferenceList("Fhir", "ReasonMedicationStatusCodes")]
        public virtual RefListReasonMedicationStatusCodes StatusReason { get; set; }
        public virtual RefListConditionCategory Category { get; set; }
        public virtual RefListMedicationCodeableConcept MedicationCodeableConcept { get; set; }
        public virtual Medication MedicationReference { get; set; }
        public virtual string MedicationText { get; set; }
        public virtual Patient Subject { get; set; }
        public virtual string ContextOwnerId { get; set; }
        public virtual string ContextOwnerType { get; set; }
        public virtual DateTime? EffectiveDateTime { get; set; }
        public virtual DateTime? EffectivePeriodStart { get; set; }
        public virtual DateTime? EffectivePeriodEnd { get; set; }
        public virtual DateTime? DateAsserted { get; set; }
        public virtual PersonFhirBase InformationSource { get; set; }
        public virtual string DerivedFromOwnerId { get; set; }
        public virtual string DerivedFromOwnerType { get; set; }
        [MultiValueReferenceList("Fhir", "ConditionProblemDiagnosisCodes")]
        public virtual RefListConditionProblemDiagnosisCodes ReasonCode { get; set; }
        public virtual string ReasonReferenceOwnerId { get; set; }
        public virtual string ReasonReferenceOwnerType { get; set; }
        //public virtual  Note  {get;set;}
        //public virtual Dosage Dosage { get; set; }
    }
}
