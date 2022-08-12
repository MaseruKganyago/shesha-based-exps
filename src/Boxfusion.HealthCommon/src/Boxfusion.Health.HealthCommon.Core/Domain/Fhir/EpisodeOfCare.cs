using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.EpisodeOfCare")]
    public class EpisodeOfCare : FullAuditedEntity<Guid>
    {
    }
}