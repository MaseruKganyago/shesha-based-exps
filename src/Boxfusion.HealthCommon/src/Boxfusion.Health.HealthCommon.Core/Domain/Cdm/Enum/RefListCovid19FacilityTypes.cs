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
	[ReferenceList("Cdm", "Covid19FacilityTypes")]
	public enum RefListCovid19FacilityTypes : long
	{
        /// <summary>
        /// 
        /// </summary>
        [Description("Hospital")]
        Hospital = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Clinic")]
        Clinic = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Other")]
        Other = 4
    }
}
