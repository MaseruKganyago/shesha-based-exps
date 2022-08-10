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
	[ReferenceList("Cdm", "ProvisionalCondition")]
	public enum RefListProvisionalCondition : long
	{
        /// <summary>
        /// 
        /// </summary>
        Medical = 1,
        /// <summary>
        /// 
        /// </summary>
        Maternity = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Transport Accident")]
        TransportAccident = 3,
        /// <summary>
        /// 
        /// </summary>
        Suicide = 4,
        /// <summary>
        /// 
        /// </summary>
        Disaster = 5,
        /// <summary>
        /// 
        /// </summary>
        Trauma = 6
    }
}
