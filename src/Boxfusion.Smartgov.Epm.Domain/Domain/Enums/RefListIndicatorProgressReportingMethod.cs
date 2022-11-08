using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "IndicatorProgressReportingMethod")]
	public enum RefListIndicatorProgressReportingMethod: long
	{
		[Description("The progress values will be populated by the system in the background. The user should not be able to input.")]
		System = 1,

		Manual = 2
	}
}
