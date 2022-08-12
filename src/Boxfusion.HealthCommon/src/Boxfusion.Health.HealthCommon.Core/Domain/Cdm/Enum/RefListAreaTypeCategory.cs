using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    /// <summary>
    /// 
    /// </summary>
	[ReferenceList("Cdm", "AreaTypeCategory")]
	public enum RefListAreaTypeCategory : long
	{
        /// <summary>
        /// 
        /// </summary>
        Municipality = 1,
        /// <summary>
        /// 
        /// </summary>
        Region = 2,
        /// <summary>
        /// 
        /// </summary>
        Province = 3
    }
}
