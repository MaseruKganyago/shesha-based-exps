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
    [Entity(TypeShortAlias = "Epm.PerformanceReportAllowedComponentType")]
    public class PerformanceReportAllowedComponentType: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual PerformanceReportTemplate PerformanceReportTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ComponentType ComponentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool CanBeRoot { get; set; }
    }
}
