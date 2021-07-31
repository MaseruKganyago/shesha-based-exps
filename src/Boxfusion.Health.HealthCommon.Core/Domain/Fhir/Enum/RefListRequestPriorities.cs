using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "RequestPriosities")]
	public enum RefListRequestPriorities : int
	{
		[Description("Routine")]
		routine = 1,
		[Description("Urgent")]
		urgent = 2,
		[Description("Asap")]
		asap = 3,
		[Description("Stat")]
		stat = 4
	}
}
