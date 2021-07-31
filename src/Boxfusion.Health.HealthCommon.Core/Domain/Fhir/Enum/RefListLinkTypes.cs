using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "LinkTypes")]
	public enum RefListLinkTypes : int
	{
		[Description("Replaced-by")]
		replacedBy = 1,
		[Description("Replaces")]
		replaces = 2,
		[Description("Refer")]
		refer = 3,
		[Description("See also")]
		seealso = 4
	}
}
