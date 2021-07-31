using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Cdm", "ProcedureCodingSystem")]
	public enum RefListProcedureCodingSystem: int
	{
		[Description("Free text")]
		freeText = 1,
		[Description("SNOMED")]
		snomed = 2
	}
}
