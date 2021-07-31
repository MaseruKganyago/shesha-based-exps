using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Cdm", "ConsultServiceRequestStatuses")]
	public enum RefListConsultServiceRequestStatuses: int
	{
		[Description("In Progress")]
		inProgress = 1,
		[Description("Completed")]
		completed = 2
	}
}
