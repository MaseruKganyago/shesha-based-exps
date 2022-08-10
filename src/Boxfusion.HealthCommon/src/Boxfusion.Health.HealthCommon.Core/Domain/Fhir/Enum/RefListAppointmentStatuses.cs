using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "AppointmentStatuses")]
    public enum RefListAppointmentStatuses : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Proposed")]
        proposed = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pending")]
        pending = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Booked")]
        booked = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Arrived")]
        arrived = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fulfilled")]
        fulfilled = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cancelled")]
        cancelled = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("No Show")]
        noshow = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entered in error")]
        enteredInerror = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Checked In")]
        checkedIn = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Waitlisted")]
        waitlist = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Called")]
        called = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Absconded")]
        absconded = 21
    }
}
