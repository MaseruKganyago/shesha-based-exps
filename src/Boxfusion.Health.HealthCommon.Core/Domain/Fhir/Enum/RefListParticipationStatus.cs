using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ParticipationStatus")]
	public enum RefListParticipationStatus : int
	{
		[Description("Required")]
		accepted = 1,

		[Description("Declined")]
		declined = 2,

		[Description("Tentative")]
		Tentative = 3,

		[Description("Needs Action")]
		needAction = 4
	}
}
