using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationReuestStatuses")]
	public enum RefListMedicationRequestStatuses: int
	{
		[Description("Active")]
		active = 1,
		[Description("On Hold")]
		onHold = 2,
		[Description("Cancelled")]
		cancelled = 3,
		[Description("Completed")]
		completed = 4,
		[Description("Entered in Error")]
		enteredInError = 5,
		[Description("Stopped")]
		stopped = 6,
		[Description("Draft")]
		draft = 7,
		[Description("Unknown")]
		Unknown = 8
	}
}
