using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
    [Entity(TypeShortAlias = "Epm.PerformanceReportTemplate")]
    public class PerformanceReportTemplate: FullAuditedEntity<Guid>
    {
        [StringLength(200)]
        public virtual string Name { get; set; }
        [StringLength(20)]
        public virtual string ShortName { get; set; }
        [StringLength(2000)]
        public virtual string Description { get; set; }
        
        [ReferenceList("Shesha.Enterprise", "PeriodType")]
        public virtual long? PeriodTypeCovered { get; set; }
        [ReferenceList("Shesha.Enterprise", "PeriodType")]
        public virtual long? ProgressReportingCycle { get; set; }
        [StringLength(100)]
        public virtual string AdminPermission { get; set; }
        [StringLength(100)]
        public virtual string ProcessManagerPermission { get; set; }
    }
}
