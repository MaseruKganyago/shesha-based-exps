using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
    [Entity(TypeShortAlias = "Epm.AllowableChildComponentType")]
    public class AllowableChildComponentType: FullAuditedEntity<Guid>
    {
        public virtual ComponentType ParentComponentType { get; set; }
        public virtual ComponentType ChildComponentType { get; set; }
        public virtual bool CanBeRoot { get; set; }
    }
}
