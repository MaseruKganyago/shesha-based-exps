using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "LocationPhysicalTypes")]
	public enum RefListLocationPhysicalTypes : int
	{
		[Description("Site")]
		si = 1,

		[Description("Building")]
		bu = 2,

		[Description("Asap")]
		asap = 3,

		[Description("Stat")]
		stat = 4,

		[Description("Wing")]
		wi = 5,

		[Description("Ward")]
		wa = 6,

		[Description("Level")]
		lvl = 7,

		[Description("Corridor")]
		co = 8,

		[Description("Room")]
		ro = 9,

		[Description("Bed")]
		bd = 10,

		[Description("House")]
		ho = 11,

		[Description("Cabinet")]
		ca = 12,

		[Description("Road")]
		rd = 13,

		[Description("Area")]
		area = 14,

		[Description("Jurisdiction")]
		jdn = 15    
	}
}
