using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Collection")]
    public class Collection : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string CollectorOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string CollerctorOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? CollectedDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? CollectedStartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? CollectedEndDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DurationStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DurationEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Decimal? Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListFhirSpecimenCollectionMethods? Method { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListBodySite? BodySite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListRelevantClinicalInformations? FastingStatusCodeableConcept { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? FastingStatusStartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? FastingStatusEndDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Specimen Specimen { get; set; }

    }
}
