using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Enum
{
	[ReferenceList("HisAdmis", "Classification")]
	public enum RefListClassification : int
	{
		[Description("H0")]
		h0 = 0,

		[Description("H1")]
		h1 = 1,

		[Description("H2")]
		h2 = 2,

		[Description("H3")]
		h3 = 3,

		[Description("HG")]
		hg = 4,

		[Description("PG")]
		pg = 5,

		[Description("PF")]
		pf = 6,

		[Description("PH")]
		ph = 7,

		[Description("WS")]
		ws = 8
	}
}
