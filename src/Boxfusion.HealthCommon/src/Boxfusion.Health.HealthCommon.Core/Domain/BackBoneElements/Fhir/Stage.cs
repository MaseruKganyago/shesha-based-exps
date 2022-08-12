using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Stage")]
    public class Stage : FullAuditedEntity<Guid>
    {
        public virtual RefListConditionStage Summary { get; set; }
        public virtual string AssessmentOwnerId { get; set; }
        public virtual string AssessmentOwnerType { get; set; }
        public virtual RefListConditionStageType Type { get; set; }
        public virtual Condition Condition { get; set; }
    }
}
