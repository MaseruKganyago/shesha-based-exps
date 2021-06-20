using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Identifies the purpose for the contact point.
    /// </summary>
    [ReferenceList("HealthDomain", "ContactPointUse")]
    public enum RefListContactPointUse : int
    {
        /// <summary>
        /// A communication contact point at a home; attempted contacts for business purposes might intrude privacy and chances are one 
        /// will contact family or other household members instead of the person one wishes to call. Typically used with urgent cases, 
        /// or if no other contacts are available.
        /// </summary>
        [Description("Home")]
        home = 1,
        /// <summary>
        /// An office contact point. First choice for business related contacts during business hours.
        /// </summary>
        [Description("Work")]
        work = 2,
        /// <summary>
        /// A temporary contact point. The period can provide more detailed information.
        /// </summary>
        [Description("Temp")]
        temp = 3,
        /// <summary>
        /// This contact point is no longer in use (or was never correct, but retained for records).
        /// </summary>
        [Description("Old")]
        old = 4,
        /// <summary>
        /// A telecommunication device that moves and stays with its owner. May have characteristics of all other use codes, suitable 
        /// for urgent matters, not the first choice for routine business.
        /// </summary>
        [Description("Mobile")]
        mobile = 5
    }
}
