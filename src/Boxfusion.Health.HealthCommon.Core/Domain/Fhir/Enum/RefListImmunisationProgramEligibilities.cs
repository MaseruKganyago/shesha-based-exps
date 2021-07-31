using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationProgramEligibilities")]
	public enum RefListImmunisationProgramEligibilities: int
	{
		[Description("Not Eligible")]
		notEligible = 1,
		[Description("Uninsured")]
		unInsured = 2
	}
}
