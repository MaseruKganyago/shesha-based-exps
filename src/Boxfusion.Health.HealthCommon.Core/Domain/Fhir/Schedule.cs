using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Schedule")]
    public class Schedule : FullAuditedEntity<Guid>
    {
        public virtual bool IsActive { get; set; }
        public virtual RefListServiceCategory ServiceCategory { get; set; }
        public virtual RefListServiceType ServiceType { get; set; }
        public virtual RefListSpeciality Speciality { get; set; }
        public virtual string ActorOwnerId { get; set; }
        public virtual string ActorOwnerType { get; set; }
        public virtual DateTime PlanningHorizonStartDate { get; set; }
        public virtual DateTime PlanningHorizonEndDate { get; set; }
        public virtual string Comment { get; set; }
    }
}
