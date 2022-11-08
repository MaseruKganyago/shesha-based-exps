using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using DocumentFormat.OpenXml.Drawing.Charts;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
	[Entity(TypeShortAlias = "Epm.ProgressReport")]
	public class ProgressReport: FullAuditedEntity<Guid>
	{
		public virtual PerformanceReport PerformanceReport { get; set; }
		public virtual Period PeriodCovered { get; set; }
		public virtual RefListProgressReportingStatus Status { get; set; }
	}
}
