using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MaritalStatus")]
	public enum RefListMaritalStatus : int
	{
		[Description("Annulled")]
		A = 1,
		[Description("Divorced")]
		D = 2,
		[Description("Interlocutory")]
		I = 3,
		[Description("Legally Separated")]
		L = 4,
		[Description("Married")]
		M = 5,
		[Description("Polygamous")]
		P = 6,
		[Description("Never Married")]
		S = 7,
		[Description("Domestic partner")]
		T = 8,
		[Description("Unmarried")]
		U = 9,
		[Description("Widowed")]
		W = 10,
		[Description("Unknown")]
		UNK = 11
	}
}
