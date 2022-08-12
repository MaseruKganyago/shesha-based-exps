using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Bed
{
    [Entity(TypeShortAlias = "His.BedTypes")]
    public class BedType: FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
