using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "IndicatorCalculationType")]
	public enum RefListIndicatorCalculationType
	{
		Cummulative = 1,
		NonCummulative = 2
	}
}
