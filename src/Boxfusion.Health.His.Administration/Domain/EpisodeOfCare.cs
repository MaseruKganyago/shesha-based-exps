using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    [Entity(TypeShortAlias = "HealthDomain.EpisodeOfCare")]
    public class EpisodeOfCare : FullAuditedEntity<Guid>
    {
    }
}
