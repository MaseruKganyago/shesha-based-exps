using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "LocationModes")]
	public enum RefListLocationModes : int
	{
		[Description("Instance")]
		instance = 1,
		[Description("Kind")]
		kind = 2
	}
}
