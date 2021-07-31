using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "EncounterPriorities")]
	public enum RefListEncounterPriorities : int
	{
		[Description("ASAP")]
		A = 1,

		[Description("Callback results")]
		CR = 2,

		[Description("Callback for scheduling")]
		CS = 3,

		[Description("Contact placer for scheduling")]
		CSR = 4,

		[Description("Elective")]
		EL = 5,

		[Description("Emergency")]
		EM = 6,

		[Description("Preop")]
		P = 7,

		[Description("As needed")]
		PRN = 8,

		[Description("Routine")]
		R = 9,

		[Description("Rush Reporting")]
		RR = 10,

		[Description("Stat")]
		S = 11,

		[Description("Timing Critical")]
		T = 12,

		[Description("Use as directed")]
		UD = 13,

		[Description("Urgent")]
		UR = 14
	}
}
