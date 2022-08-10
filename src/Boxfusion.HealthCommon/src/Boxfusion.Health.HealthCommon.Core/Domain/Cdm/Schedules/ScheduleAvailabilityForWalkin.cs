using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Cdm.Schedules
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.ScheduleAvailabilityForWalkin")]
    [Table("Fhir_ScheduleAvailabilities")]
    public class ScheduleAvailabilityForWalkin : ScheduleAvailability
    {
        /// <summary>
        /// The maximum number of walk-ins allowed per day on this ScheduleAvailability.
        /// </summary>
        public virtual int? MaxNumWalkIns { get; set; }

        /// <summary>
        /// The latest time by which a user must enter the queue.
        /// </summary>
        public virtual TimeSpan? LatestWalkInTime { get; set; }
    }
}
