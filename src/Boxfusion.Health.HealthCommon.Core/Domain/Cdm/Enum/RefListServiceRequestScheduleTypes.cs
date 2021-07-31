using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Cdm", "ServiceRequestScheduleTypes")]
	public enum RefListServiceRequestScheduleTypes: int
	{
		[Description("Queue")]
		queue = 1,
		[Description("Appointment")]
		appointment = 2
	}
}
