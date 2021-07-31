using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "EncounterStatuses")]
	public enum RefListEncounterStatuses : int
	{
		[Description("Planned")]
		planned = 1,

		[Description("Arrived")]
		arrived = 2,

		[Description("Triaged")]
		triaged = 3,

		[Description("In Progress")]
		inprogressed = 4,

		[Description("On Leave")]
		onleave = 5,

		[Description("Finished")]
		finished = 6,

		[Description("Cancelled")]
		cancelled = 7,

		[Description("Entered in Error")]
		enteredInError = 8,

		[Description("Unknown")]
		unknown = 9
	}
}
