using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
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
    [Entity(TypeShortAlias = "HealthCommon.Core.ScheduleAvailability", GenerateApplicationService = false)]
    [Table("Fhir_ScheduleAvailabilities")]
    [Discriminator]
    //[DiscriminatorValue("Cdm.ScheduleAvailability")]
    public class ScheduleAvailability: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// The schedule this Availability configuration belongs to.
        /// </summary>
        public virtual Schedule Schedule { get; set; }

        /// <summary>
        /// Indicates if Availability configuration is active
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// Date Availability applies from.
        /// </summary>
        public virtual DateTime? ValidFromDate { get; set; }

        /// <summary>
        /// Date Availability applies until.
        /// </summary>
        public virtual DateTime? ValidToDate { get; set; }

        /// <summary>
        /// Short string to prefix the ticket number on the tickets issued to a client upon arrival.
        /// </summary>
        public virtual string TicketPrefix { get; set; }

        /// <summary>
        /// The days of the week the booking applies.
        /// </summary>
        [MultiValueReferenceList("Fhir", "DaysOfWeek")]
        public virtual RefListDaysOfWeek? ApplicableDays { get; set; }

        /// <summary>
        /// The time from which appointments may be accepted.
        /// </summary>
        public virtual TimeSpan? StartTime { get; set; }

        /// <summary>
        /// The time until appointments will be fullfilled.
        /// </summary>
        public virtual TimeSpan? EndTime{ get; set; }

        /// <summary>
        /// The date of the last slot generated for this ScheduleAvailbility.
        /// </summary>
        public virtual DateTime? LastGeneratedSlotDate { get; set; }

    }
}
