using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Cdm.Schedules
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Cdm", "SchedulingModels")]
    public enum RefListSchedulingModels : long
    {
        /// <summary>
        /// Specifies that a schedule observes a day based booking model i.e. where a person books for a particular day rather than a specific time.
        /// </summary>
        [Description("Day based Appointment")]
        DayBasedAppointment = 1,

        /// <summary>
        /// Specifies that a schedule observes a time based booking model i.e. where a person books for a particular time slot.
        /// </summary>
        [Description("Time based Appointment")]
        TimeBasedAppointment = 2,

        /// <summary>
        /// Specifies that a schedule observes a walk-in based booking model i.e. first come first served with no pre-booking.
        /// </summary>
        [Description("Walk-in")]
        Walkin = 3

    }
}
