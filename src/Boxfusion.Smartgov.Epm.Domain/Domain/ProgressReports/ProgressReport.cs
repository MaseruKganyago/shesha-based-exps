using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.PerformanceReports;
using Shesha.Domain.Attributes;
using Shesha.Enterprise;
using Shesha.Enterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.ProgressReports
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "Epm.ProgressReport")]
    public class ProgressReport : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual PerformanceReport PerformanceReport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Period PeriodCovered { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Epm", "ProgressReportingStatus")]
		public virtual long? Status { get; set; }
    }
}
