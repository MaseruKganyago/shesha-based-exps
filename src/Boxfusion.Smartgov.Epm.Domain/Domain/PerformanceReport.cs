using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Shesha.Domain.Attributes;
using Shesha.Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
	[Entity(TypeShortAlias = "Epm.PerformanceReport")]
	public class PerformanceReport: FullAuditedEntity<Guid>
	{
		public virtual PerformanceReportTemplate Template { get; set; }
		public virtual string ShortName { get; set; }
		public virtual string Name { get; set; }
		public virtual Period PeriodCovered { get; set; }
		public virtual RefListPerformanceReportStatus? Status { get; set; }
	}
}
