using Abp.Domain.Entities.Auditing;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Participant")]
    public class Participant : FullAuditedEntity<Guid>
    {
        public virtual string OwnerId { get; set; }

        public virtual string OwnerType { get; set; }

        [ReferenceList("Fhir", "EncounterParticipantTypes")]
        public virtual int? Type { get; set; }

        public virtual DateTime? StartDateTime { get; set; }

        public virtual DateTime? EndDateTime { get; set; }

        public virtual Person Individual { get; set; }

        [ReferenceList("Fhir", "ParticipantRequired")]
        public virtual int? Required { get; set; }

        [ReferenceList("Fhir", "ParticipationStatus")]
        public virtual int? Status { get; set; }
    }
}
