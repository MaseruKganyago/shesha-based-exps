using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "NodeProgressReportStatus")]
	public enum RefListNodeProgressReportStatus: long
	{
		[Description("The node needs to be reported on, but not for this specific period (e.g report only required every second period.)")]
		NonReportingPeriod = 5,

		NotDue = 10,

		[Description("Progress report is due and has not been completed for this mode.")]
		Outstanding = 20,

		AwaitingLevelOneQA = 30,
		AwaitingLevelTwoQA = 40,
		Completed = 50,

		[Description("The node does not require to be reported on.")]
		NotApllicable = 90
	}
}
