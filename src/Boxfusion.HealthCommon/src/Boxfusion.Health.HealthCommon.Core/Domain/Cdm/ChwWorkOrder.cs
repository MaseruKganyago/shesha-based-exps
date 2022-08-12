using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.CHWWorkOrder", GenerateApplicationService = false)]
    public class ChwWorkOrder : FullAuditedEntity<Guid>
    {

    }
}