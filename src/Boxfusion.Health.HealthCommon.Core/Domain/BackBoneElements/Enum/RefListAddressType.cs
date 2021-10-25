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
    [ReferenceList("Fhir", "AddressType")]
    public enum RefListAddressType : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Postal")]
        postal = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Physical")]
        physical = 2
    }
}
