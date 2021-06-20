using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    [Entity(TypeShortAlias = "HealthDomain.EncounterServiceType")]
    public class EncounterServiceType : FullAuditedEntity<Guid>
    {
        public virtual int? Code { get; set; }
        public virtual string Display { get; set; }
        public virtual string Definition { get; set; }
    }
}
