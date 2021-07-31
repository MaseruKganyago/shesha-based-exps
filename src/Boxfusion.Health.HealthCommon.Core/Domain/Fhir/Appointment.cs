using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    [Entity(TypeShortAlias = "HealthCommon.Core.Appointment")]
    public class Appointment : FullAuditedEntity<Guid>
    {

    }
}