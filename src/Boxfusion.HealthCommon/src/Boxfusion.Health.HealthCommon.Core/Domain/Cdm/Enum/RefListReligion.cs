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
	[ReferenceList("Cdm", "Religion")]
	public enum RefListReligion : long
	{
        /// <summary>
        /// 
        /// </summary>
        Christianity = 1,
        /// <summary>
        /// 
        /// </summary>
        Islam = 2,
        /// <summary>
        /// 
        /// </summary>
        Hinduism = 3,
        /// <summary>
        /// 
        /// </summary>
        Judaism = 4,
        /// <summary>
        /// 
        /// </summary>
        Other = 4
    }
}
