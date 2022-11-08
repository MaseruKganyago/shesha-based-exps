using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
    [Entity(TypeShortAlias = "Epm.PerformanceReport")]
    public class PerformanceReportAllowedComponentType: FullAuditedEntity<Guid>
    {
        public virtual PerformanceReportTemplate PerformanceReportTemplate { get; set; }
        public virtual ComponentType ComponentType { get; set; }
        public virtual bool CanBeRoot { get; set; }
    }
}
