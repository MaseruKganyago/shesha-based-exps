using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "Trend")]
	public enum RefListTrend: long
	{
		Increasing = 1,
		Decreasing = 2,
		Flat = 3,
		NotAvailalble = 4
	}
}
