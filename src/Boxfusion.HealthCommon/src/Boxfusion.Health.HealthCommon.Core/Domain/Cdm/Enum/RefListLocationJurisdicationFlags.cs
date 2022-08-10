using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "LocationJurisdicationFlags")]
	public enum RefListLocationJurisdicationFlags : long
	{
		[Description("Telehealth Service Coverage")]
		telehealthServiceCoverage = 1
	}
}
