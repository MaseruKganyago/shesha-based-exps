using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ServiceRequestStatuses")]
	public enum RefListServiceRequestStatuses : long
	{
		[Description("Draft")]
		draft = 1,
		[Description("Active")]
		active = 2,
		[Description("On Hold")]
		onHold = 3,
		[Description("Revoked")]
		revoked = 4,
		[Description("Completed")]
		completed = 5,
		[Description("Entered in Error")]
		enteredInError = 6,
		[Description("Cancelled")]
		cancelled = 7,
		[Description("Unknown")]
		unknown = 8
	}
}
