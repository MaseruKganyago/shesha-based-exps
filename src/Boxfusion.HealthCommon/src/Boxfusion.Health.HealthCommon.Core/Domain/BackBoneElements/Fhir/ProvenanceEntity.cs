using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
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
    [Entity(TypeShortAlias = "HealthCommon.Core.ProvenanceEntity")]
    public class ProvenanceEntity : FullAuditedEntity<Guid> 
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListProvenanceEntityRoles Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string WhatOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string WhatOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Provenance Provenance { get; set; }
    }
}
