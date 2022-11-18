using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "Epm.AllowableChildComponentType")]
    public class AllowableChildComponentType: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual ComponentType ParentComponentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ComponentType ChildComponentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool CanBeRoot { get; set; }
    }
}
