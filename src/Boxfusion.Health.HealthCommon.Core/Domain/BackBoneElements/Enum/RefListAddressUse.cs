using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "AddressUse")]
    public enum RefListAddressUse : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Home")]
        home = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Work")]
        work = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Temporary")]
        temp = 3,
        /// <summary>
        /// 
        /// </summary>
        [Description("Old / Incorrect")]
        old = 4,
        /// <summary>
        /// 
        /// </summary>
        [Description("Billing")]
        billing = 5
    }
}
