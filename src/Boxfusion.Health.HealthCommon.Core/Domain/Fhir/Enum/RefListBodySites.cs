using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Fhir", "BodySites")]
	public enum RefListBodySites: int
	{
		[Description("Cardiovascular")]
		cardiovascular = 1,
		[Description("Respiratory")]
		respiratory = 2,
		[Description("Gastro Intestinal")]
		gastroIntestinal = 3
	}
}
