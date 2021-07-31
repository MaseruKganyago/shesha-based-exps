using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "RequestIntents")]
	public enum RefListRequestIntents : int
	{
		[Description("Proposal")]
		proposal = 1,
		[Description("Plan")]
		plan = 2,
		[Description("Directive")]
		directive = 3,
		[Description("Order")]
		order = 4,
		[Description("Original Order")]
		originalOder = 5,
		[Description("Reflex Order")]
		reflexOrder = 6,
		[Description("Filler Order")]
		filterOrder = 7,
	}
}
