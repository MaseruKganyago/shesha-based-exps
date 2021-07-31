using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.HoursOfOperation")]
    public class HoursOfOperation : FullAuditedEntity<Guid>
    {
        public virtual string OwnerId { get; set; }
        public virtual string OwnerType { get; set; }
        [MultiValueReferenceList("Fhir", "DaysOfWeek")]
        public virtual int? DaysOfWeek { get; set; }
        public virtual bool AllDay { get; set; }
        public virtual DateTime? AvailableStartTime { get; set; }
        public virtual DateTime? AvailableEndime { get; set; }
    }
}
