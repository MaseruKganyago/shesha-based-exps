using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Cdm", "ServiceRequestQueuePriorities")]
	public enum RefListServiceRequestQueuePriorities: int
	{
		[Description("High")]
		high = 1,
		[Description("Medium")]
		medium = 2,
		[Description("Low")]
		low = 3
	}
}
