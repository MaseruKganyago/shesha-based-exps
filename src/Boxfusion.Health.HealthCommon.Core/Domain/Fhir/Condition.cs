using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Condition")]
    public class Condition : FullAuditedEntity<Guid>
    {
        public virtual RefListClinicalStatus? ClinicalStatus { get; set; }
        public virtual RefListVerificationStatus? VerificationStatus { get; set; }
        public virtual RefListCategory? Category { get; set; }
        public virtual RefListSeverity? Severity { get; set; }
        //public virtual RefListCodingSystem? CodingSystem { get; set; }
        //public virtual string CodeValue { get; set; }
        //public virtual string CodeText { get; set; }
        public virtual RefListBodySites? BodySite { get; set; }
        public virtual Patient Subject { get; set; }
        public virtual Encounter Encounter { get; set; }
        public virtual DateTime? OnsetDateTime { get; set; }
        public virtual int OnsetAge { get; set; }
        public virtual DateTime? OnsetPeriodStart { get; set; }
        public virtual DateTime? OnsetPeriodEnd { get; set; }
        public virtual decimal OnsetRangeLow { get; set; }
        public virtual decimal OnsetRangeHigh { get; set; }
        public virtual string OnsetString { get; set; }
        public virtual DateTime? AbatementDateTime { get; set; }
        public virtual int AbatementAge { get; set; }
        public virtual DateTime? AbatementPeriodStart { get; set; }
        public virtual DateTime? AbatementPeriodEnd { get; set; }
        public virtual decimal AbatementRangeLow { get; set; }
        public virtual decimal AbatementRangeHigh { get; set; }
        public virtual string AbatementString { get; set; }
        public virtual DateTime? RecordedDate { get; set; }
        public virtual PersonFhirBase Recorder  { get; set; }
        public virtual PersonFhirBase Asserter { get; set; }
    }
}
