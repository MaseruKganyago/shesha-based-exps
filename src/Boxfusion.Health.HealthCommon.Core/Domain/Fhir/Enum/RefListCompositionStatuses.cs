using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "CompositionStatuses")]
	public enum RefListCompositionStatuses: int
	{
		[Description("Preliminary")]
		premilinary = 1,
		[Description("Final")]
		final = 2,
		[Description("Amended")]
		amended = 3,
		[Description("Entered in Error")]
		enteredInError = 4
	}
}
