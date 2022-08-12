using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Cdm.Schedules
{
    /// <summary>
    /// Specifies schedule availability (capacity) for a Time based booking model (i.e. people book on a particular time slot rather than day)
    /// </summary>
    [Entity(TypeShortAlias = "Cdm.ScheduleAvailabilityForTimeBooking")]
    //[Table("Fhir_ScheduleAvailabilities")]
    [DiscriminatorValue("Cdm.ScheduleAvailForTimeBooking")]
    public class ScheduleAvailabilityForTimeBooking : ScheduleAvailabilityForBookingBase
    {

        /// <summary>
        /// Duration in Minutes of the slots to be genated.
        /// </summary>
        public virtual int? SlotDuration { get; set; }

        /// <summary>
        /// Interval in minutes after a slot before creating another slot (i.e. allows introducing a break between slots)
        /// </summary>
        public virtual int? BreakIntervalAfterSlot { get; set; }


    }
}
