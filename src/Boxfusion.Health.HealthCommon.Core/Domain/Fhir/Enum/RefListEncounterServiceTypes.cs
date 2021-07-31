using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "EncounterServiceTypes")]
	public enum RefListEncounterServiceTypes : int
	{
		[Description("General Practice")]
		generalPractice = 1
	}
}
