using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	[ReferenceList("Fhir", "DoseAndRateTypes")]
	public enum RefListDoseAndRateTypes: long
	{
		[Description("Calculated")]
		calculated = 1,
		[Description("Ordered")]
		ordered = 2
	}
}
