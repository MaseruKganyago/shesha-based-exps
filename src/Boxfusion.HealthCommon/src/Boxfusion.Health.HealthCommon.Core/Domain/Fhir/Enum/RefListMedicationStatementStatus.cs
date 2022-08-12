using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationStatementStatus")]
	public enum RefListMedicationStatementStatus: long
	{
		[Description("Active")]
		active = 1,
		[Description("Completed")]
		completed = 2,
		[Description("Entered in Error")]
		enteredInError = 3,
		[Description("Intended")]
		intended = 4,
		[Description("Stopped")]
		stopped = 5,
		[Description("On Hold")]
		onHold = 6,
		[Description("Unknown")]
		unknown = 7,
		[Description("Not Taken")]
		notTaken = 8
    }
}
