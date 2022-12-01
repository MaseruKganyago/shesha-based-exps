using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Shesha.Domain.Attributes;
using Shesha.Enterprise;
using Shesha.Enterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.PerformanceReports
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "Epm.PerformanceReport")]
    public class PerformanceReport : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual PerformanceReportTemplate Template { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ShortName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Period PeriodCovered { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("Epm", "PerformanceReportStatus")]
        public virtual long? Status { get; set; }
    }
}
