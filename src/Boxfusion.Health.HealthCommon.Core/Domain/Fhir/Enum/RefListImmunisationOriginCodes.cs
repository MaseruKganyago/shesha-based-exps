using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationOriginCodes")]
	public enum RefListImmunisationOriginCodes: int
	{
		[Description("Other Provider")]
		otherProvider = 1,
		[Description("Written Record")]
		writtenRecord = 2,
		[Description("Parent/ Guardian/ Patient Recall")]
		parentGuardianPateintRecall = 3,
		[Description("School Record")]
		schoolRecord = 4
	}
}
