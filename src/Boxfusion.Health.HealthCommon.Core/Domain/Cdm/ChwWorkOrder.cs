using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.CHWWorkOrder")]
    public class ChwWorkOrder : FullAuditedEntity<Guid>
    {

    }
}