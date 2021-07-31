using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ObservationStatuses")]
	public enum RefListObservationStatuses : int
	{
		[Description("Registered")]
		registered = 1,
		[Description("Preliminary")]
		preliminary = 2,
		[Description("Final")]
		final = 3,
		[Description("Amended")]
		amended = 4,
		[Description("Corrected")]
		corrected = 5,
		[Description("Cancelled")]
		cancelled = 6,
		[Description("Entered in Error")]
		enteredInError = 7,
		[Description("Unknown")]
		unknown = 8
	}
}
