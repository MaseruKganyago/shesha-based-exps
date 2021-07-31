using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Diagnosis")]
    public class Diagnosis : FullAuditedEntity<Guid>
    {
        public virtual string OwnerId { get; set; }

        public virtual string OwnerType { get; set; }

        public virtual Condition Condition { get; set; }

        [ReferenceList("Fhir", "EncounterDiagnosisRoles")]
        public virtual int? Use { get; set; }

        public virtual int? Rank { get; set; }
    }
}
