using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ParticipantRequired")]
	public enum RefListParticipantRequired : int
	{
		[Description("Required")]
		required = 1,

		[Description("Optional")]
		optional = 2,

		[Description("Information Only")]
		informationOnly = 3
	}
}
