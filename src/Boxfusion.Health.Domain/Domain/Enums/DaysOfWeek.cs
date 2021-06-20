using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Indicates which days of the week are available between the start and end Times.
    /// </summary>
    [ReferenceList("HealthDomain", "DaysOfWeek")]
    public enum RefListDaysOfWeek : int
    {
        /// <summary>
        /// Monday.
        /// </summary>
        [Description("Monday")]
        mon = 1,
        /// <summary>
        /// Tuesday.
        /// </summary>
        [Description("Tuesday")]
        tue = 2,
        /// <summary>
        /// Wednesday.
        /// </summary>
        [Description("Wednesday")]
        wed = 3,
        /// <summary>
        /// Thursday.
        /// </summary>
        [Description("Thursday")]
        thu = 4,
        /// <summary>
        /// Friday.
        /// </summary>
        [Description("Friday")]
        fri = 5,
        /// <summary>
        /// Saturday.
        /// </summary>
        [Description("Saturday")]
        sat = 6,
        /// <summary>
        /// Sunday.
        /// </summary>
        [Description("Sunday")]
        sun = 7
    }
}
