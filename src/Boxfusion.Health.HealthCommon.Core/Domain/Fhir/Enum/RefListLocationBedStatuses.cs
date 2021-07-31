using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "LocationBedStatuses")]
	public enum RefListLocationBedStatuses : int
	{
		[Description("Closed")]
		C = 1,
		[Description("Housekeeping")]
		H = 2,
		[Description("Isolated")]
		I = 3,
		[Description("Contaminated")]
		K = 4,
		[Description("Occupied")]
		O = 5,
		[Description("Unoccupied")]
		U = 6
	}
}
