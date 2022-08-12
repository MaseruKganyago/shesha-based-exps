using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Participant")]
    public class Participant : FullAuditedEntity<Guid>
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
        public virtual RefListEncounterParticipantTypes? Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase Individual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListParticipantRequired? Required { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListParticipationStatus? Status { get; set; }
    }
}
