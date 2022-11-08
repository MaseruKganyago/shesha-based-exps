using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "ProgressReportingStatus")]
	public enum RefListProgressReportingStatus
	{
		Draft = 0,

		[Description("The report is not yet due.")]
		NotDue = 10,

		[Description("Reporting")]
		Open = 20,

		[Description("Reporting has been closed for this period i.e no more Progress Reports may be submitted.")]
		Closed = 30,

		[Description("The report has been finalised. i.e passed whatever QA was required.")]
		Finalised = 40
	}
}
