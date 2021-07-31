using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Cdm", "VisitTypes")]
	public enum RefListVisitTypes: int
	{
		[Description("Checkup")]
		checkUp = 1,
		[Description("Education & Health Promotion")]
		educationAndHealthPromotion = 2,
		[Description("Clinical Management")]
		clinicalManagement = 3,
		[Description("Administration")]
		administration = 4
	}
}
