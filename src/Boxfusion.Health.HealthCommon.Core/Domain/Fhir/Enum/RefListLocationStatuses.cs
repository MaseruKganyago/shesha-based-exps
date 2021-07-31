using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "LocationStatuses")]
	public enum RefListLocationStatuses : int
	{
		[Description("Active")]
		active = 1,
		[Description("Suspended")]
		suspended = 2,
		[Description("Inactive")]
		inactive = 3
	}
}
