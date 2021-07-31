using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "CommunicationCategories")]
	public enum RefListCommunicationCategories: int
	{
		[Description("Alert")]
		alert = 1,
		[Description("Notification")]
		notification = 2,
		[Description("Reminder")]
		reminder = 3,
		[Description("Instruction")]
		instruction = 4
	}
}
