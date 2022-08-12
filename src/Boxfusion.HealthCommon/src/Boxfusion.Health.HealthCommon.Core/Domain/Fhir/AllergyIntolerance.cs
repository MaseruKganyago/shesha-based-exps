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
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.AllergyIntolerance")]
    public class AllergyIntolerance : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAllergyIntoleranceClinical ClinicalStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAllergyIntoleranceVerification VerificationStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAllergyIntoleranceType AllergyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAllergyIntoleranceCategory Category { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAllergyIntoleranceCriticality Criticality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAllergyIntoleranceCode Code { get; set; }
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
        public virtual DateTime? OnsetDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int OnsetAge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OnsetPeriodStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OnsetPeriodEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal OnsetRangeLow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal OnsetRangeHigh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string OnsetString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? RecordedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase Recorder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase Asserter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastOccurence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Reaction Reaction { get; set; }
    }
}
