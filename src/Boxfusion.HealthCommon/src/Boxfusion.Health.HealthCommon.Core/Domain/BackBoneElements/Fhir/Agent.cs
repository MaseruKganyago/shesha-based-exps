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
    [Entity(TypeShortAlias = "HealthCommon.Core.Agent")]
    public class Agent : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListProvenanceParticipantTypes Type { get; set; }

        /// <summary>
        /// Converted to type "reference list" due to many entities.
        /// </summary>
        public virtual RefListSecurityRoleTypes Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string WhoOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string WhoOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OnBehalfOfOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string OnBehalfOfOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Provenance Provenance { get; set; }
    }
}
