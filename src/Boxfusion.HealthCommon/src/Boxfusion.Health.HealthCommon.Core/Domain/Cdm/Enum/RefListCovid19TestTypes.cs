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
	[ReferenceList("Cdm", "Covid19TestTypes")]
	public enum RefListCovid19TestTypes : long
	{
        /// <summary>
        /// 
        /// </summary>
        [Description("PCR Viral Swab Test")]
        PCRViralSwabTest = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Rapid Antigen Test")]
        RapidAntigenTest = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Antibody Serum Test")]
        AntibodySerumTest = 4
    }
}
