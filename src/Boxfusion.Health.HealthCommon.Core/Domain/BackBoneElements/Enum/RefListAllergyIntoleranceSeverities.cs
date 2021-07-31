using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	[ReferenceList("Fhir", "AllergyIntoleranceSeverities")]
	public enum RefListAllergyIntoleranceSeverities: int
	{
		[Description("Mild")]
		mild = 1,
		[Description("Moderate")]
		moderate = 2,
		[Description("Severe")]
		severe = 3
	}
}
