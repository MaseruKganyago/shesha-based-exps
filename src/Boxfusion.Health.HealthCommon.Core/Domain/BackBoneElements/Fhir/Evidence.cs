using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Evidence")]
    public class Evidence : FullAuditedEntity<Guid>
    {
        public virtual RefListCode Code { get; set; }
        public virtual string DetailOwnerId { get; set; }
        public virtual string DetailOwnerType { get; set; }
        public virtual Condition Condition { get; set; }
    }
}
