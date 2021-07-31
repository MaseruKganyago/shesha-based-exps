using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.AllergyIntolerance")]
    public class AllergyIntolerance : FullAuditedEntity<Guid>
    {
        public virtual RefListClinicalStatus ClinicalStatus { get; set; }
        public virtual RefListVerificationStatus VerificationStatus { get; set; }
        public virtual RefListAllergyIntoleranceType AllergyType { get; set; }
        public virtual RefListCategory Category { get; set; }
        public virtual RefListAllergyIntoleranceCriticality Criticality { get; set; }
        public virtual RefListCode Code { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Encounter Encounter { get; set; }
        public virtual DateTime OnsetDateTime { get; set; }
        public virtual int OnsetAge { get; set; }
        public virtual DateTime OnsetPeriodStart { get; set; }
        public virtual DateTime OnsetPeriodEnd { get; set; }
        public virtual decimal OnsetRangeLow { get; set; }
        public virtual decimal OnsetRangeHigh { get; set; }
        public virtual string OnsetString { get; set; }
        public virtual DateTime RecordedDate { get; set; }
        public virtual PersonFhirBase Recorder { get; set; }
        public virtual PersonFhirBase Asserter { get; set; }
        public virtual DateTime LastOccurence { get; set; }
        public virtual Reaction Reaction { get; set; }
    }
}
