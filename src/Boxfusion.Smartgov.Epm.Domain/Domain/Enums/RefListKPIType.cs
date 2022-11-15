using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Epm", "KPIType")]
	public enum RefListKPIType: long
	{
		Input = 1,
		Output = 2,
		Outcome = 3,
		Efficiency = 4
	}
}
