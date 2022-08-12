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
    /// Specifies schedule availability (capacity) for a Day based booking model (i.e. people book on a particular day rather than specific time slot)
    /// </summary>
    [Entity(TypeShortAlias = "Cdm.ScheduleAvailabilityForDayBooking")]
    //[Table("Fhir_ScheduleAvailabilities")]
    [DiscriminatorValue("Cdm.ScheduleAvailForDayBooking")]
    public class ScheduleAvailabilityForDayBooking : ScheduleAvailabilityForBookingBase
    {
        

    }
}
