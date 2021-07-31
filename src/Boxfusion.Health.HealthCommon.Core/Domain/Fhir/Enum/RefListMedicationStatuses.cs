using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationStatuses")]
	public enum RefListMedicationStatuses: int
	{
		[Description("Active")]
		active = 1,
		[Description("Inactive")]
		inActive = 2,
		[Description("Entered in Error")]
		enteredInError = 3
	}
}
