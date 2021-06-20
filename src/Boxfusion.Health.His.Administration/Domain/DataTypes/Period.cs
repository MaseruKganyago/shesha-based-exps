using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.DataTypes
{
    [Entity(TypeShortAlias = "HealthDomain.Period")]
    public class Period : FullAuditedEntity<Guid>
    {
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }

    }
}
