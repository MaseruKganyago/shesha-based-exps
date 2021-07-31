using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationStatuses")]
	public enum RefListImmunisationStatuses: int
	{
		[Description("Preparation")]
		preparation = 1,
		[Description("In Progress")]
		inProgress = 2,
		[Description("Not Done")]
		notDone = 3,
		[Description("On Hold")]
		onHold = 4,
		[Description("Stopped")]
		stopped = 5,
		[Description("Completed")]
		completed = 6,
		[Description("Entered in Error")]
		enteredInError = 7,
		[Description("Unknown")]
		unknown = 8
	}
}
