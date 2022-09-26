using Abp.Domain.Entities.Auditing;
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
	[Entity(TypeShortAlias = "HealthCommon.Core.Provenance", GenerateApplicationService = false)]
	public class Provenance: FullAuditedEntity<Guid>
	{
        /// <summary>
        /// 
        /// </summary>
        public virtual string TargetOwnerId { get; set; }

        /// <summary>
        /// /
        /// </summary>
        public virtual string TargetOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OccuredPeriodStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OccuredPeriodEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OccuredDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? Recorded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Policy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual FhirLocation Location { get; set; }

        /// <summary>
        /// Converted from multiValueReferenceList because of too many items
        /// </summary>
        public virtual RefListPurposeOfUses? Reason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListProvenanceActivityTypes? Activity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Signature Signature { get; set; }
	}
}
