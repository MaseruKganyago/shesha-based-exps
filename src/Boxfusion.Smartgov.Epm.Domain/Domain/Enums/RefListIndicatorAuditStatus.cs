using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "IndicatorAuditStatus")]
	public enum RefListIndicatorAuditStatus: long
	{
		NotDue = 1,
		OutStanding = 2,
		Completed = 3,
		PartiallyCompleted = 5
	}
}
