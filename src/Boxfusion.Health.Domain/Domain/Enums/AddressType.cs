using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Distinguishes between physical addresses (those you can visit) and mailing addresses (e.g. PO Boxes and care-of addresses). 
    /// Most addresses are both.
    /// </summary>
    [ReferenceList("HealthDomain", "AddressType")]
    public enum RefListAddressType : int
    {
        /// <summary>
        /// Postal
        /// </summary>
        [Description("Postal")]
        postal = 1,
        /// <summary>
        /// Physical
        /// </summary>
        [Description("Physical")]
        physical = 2,
        /// <summary>
        /// Postal & Physical
        /// </summary>
        [Description("Postal & Physical")]
        both = 3
    }
}
