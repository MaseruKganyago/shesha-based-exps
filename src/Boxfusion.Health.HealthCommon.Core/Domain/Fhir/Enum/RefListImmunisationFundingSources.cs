using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationFundingSources")]
	public enum RefListImmunisationFundingSources: int
	{
		[Description("Private Funding")]
		privateFunding = 1,
		[Description("Public Funding")]
		publicFunding = 2
	}
}
