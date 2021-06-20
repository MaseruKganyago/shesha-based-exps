using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// The purpose of this address.
    /// </summary>
    [ReferenceList("HealthDomain", "AddressUse")]
    public enum RefListAddressUse : int
    {
        /// <summary>
        /// Home
        /// </summary>
        [Description("Home")]
        home = 1,
        /// <summary>
        /// Work
        /// </summary>
        [Description("Work")]
        work = 2,
        /// <summary>
        /// Temporary
        /// </summary>
        [Description("Temporary")]
        temp = 3,
        /// <summary>
        /// Old / Incorrect
        /// </summary>
        [Description("Old / Incorrect")]
        old = 4,
        /// <summary>
        /// Billing
        /// </summary>
        [Description("Billing")]
        billing = 5
    }
}
