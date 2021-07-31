using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationSubpotentReasons")]
	public enum RefListImmunisationSubpotentReasons: int
	{
		[Description("Partial Dose")]
		partialDose = 1,
		[Description("Cold Chain Break")]
		partialChainBreak = 2,
		[Description("Manufacture Recall")]
		manufactureRecall = 4
	}
}
