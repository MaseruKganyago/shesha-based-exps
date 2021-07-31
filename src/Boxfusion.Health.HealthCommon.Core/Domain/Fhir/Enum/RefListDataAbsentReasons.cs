using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "DataAbsentReasons")]
	public enum RefListDataAbsentReasons: int
	{
		[Description("Unknown")]
		unknown = 1,
		[Description("Asked But Unknown")]
		askedButUnknown = 2,
		[Description("Temporarily Unknown")]
		temporarilyUnknown = 3,
		[Description("Not Asked")]
		notAsked = 4,
		[Description("Asked But Declined")]
		askedDeclined = 5,
		[Description("Masked")]
		masked = 6,
		[Description("Not Applicable")]
		notApplicable = 7,
		[Description("Unsupported")]
		unsupported = 8,
		[Description("As Text")]
		asText = 9,
		[Description("Error")]
		error = 10,
		[Description("Not a Number (NaN)")]
		notANumber = 11,
		[Description("Negative Infinity (NINF)")]
		negativeInfinity = 12,
		[Description("Positive Infinity (PINF)")]
		positiveInfinity = 13,
		[Description("Not Performed")]
		notPerformed = 14,
		[Description("Not Permitted")]
		notPermitted = 15
	}
}
