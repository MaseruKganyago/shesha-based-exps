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
	[ReferenceList("Cdm", "EducationLevel")]
	public enum RefListEducationLevel : long
	{
        /// <summary>
        /// 
        /// </summary>
        Primary = 1,
        /// <summary>
        /// 
        /// </summary>
        Secondary = 2,
        /// <summary>
        /// 
        /// </summary>
        Tertiarty = 3,

    }
}
