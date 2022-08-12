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
	[ReferenceList("Cdm", "Covid19ReferralReasons")]
	public enum RefListCovid19ReferralReasons : long
	{
        /// <summary>
        /// 
        /// </summary>
        [Description("Travel")]
        Travel = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Covid-19 Symptoms")]
        Covid19Symptoms = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Potential Contact")]
        PotentialContact = 4
    }
}
