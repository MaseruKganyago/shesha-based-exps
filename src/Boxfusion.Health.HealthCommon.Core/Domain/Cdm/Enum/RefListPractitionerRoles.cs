using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Cdm", "PractitionerRoles")]
	public enum RefListPractitionerRoles : int
	{
		[Description("Doctor")]
		doctor = 1,

		[Description("Nurse")]
		nurse = 2,

		[Description("Clinical Associate")]
		clinicalAssociate = 3,

		[Description("Clinical Associate")]
		adminClerk = 224608005,

		[Description("Community Health Worker")]
		chw = 224608005,
	}
}
