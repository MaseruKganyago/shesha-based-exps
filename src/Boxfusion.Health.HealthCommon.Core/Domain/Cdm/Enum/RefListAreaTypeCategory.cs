using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Cdm", "AreaTypeCategory")]
	public enum RefListAreaTypeCategory : int
	{
        Municipality = 1,
        Region = 2,
        Province = 3
    }
}
