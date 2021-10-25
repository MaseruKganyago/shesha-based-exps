using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.EncounterLocation")]
    public class EncounterLocation : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirLocation Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "EncounterLocationStatuses")]
        public virtual int? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Fhir", "LocationPhysicalTypes")]
        public virtual int? PhysicalType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }
    }
}
