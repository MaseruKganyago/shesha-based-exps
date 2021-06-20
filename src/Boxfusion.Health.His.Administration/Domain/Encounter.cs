using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.DataTypes;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Period = Shesha.Domain.Period;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// The parent encouter from which all other encounters inherit from
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Encounter")]
    public class Encounter<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// Identifier(s) by which this encounter is known. (This is a business identifier, not a resource identifier)
        /// </summary>
        public virtual Identifier<T> Identifier { get; set; }

        /// <summary>
        /// Current state of the encounter (e.g. planned | arrived | triaged | in-progress | onleave | finished | cancelled +.)
        /// </summary>
        public virtual RefListEncounterStatus? Status { get; set; }

        /// <summary>
        /// Concepts representing classification of patient encounter such as ambulatory (outpatient), inpatient, emergency, home health or others due to local variations.
        /// </summary>
        public virtual RefListEncounterClass? Class { get; set; }

        /// <summary>
        /// Specific type of encounter (e.g. e-mail consultation, surgical day-care, skilled nursing, rehabilitation).
        /// </summary>
        public virtual RefListEncounterType? Type { get; set; }

        /// <summary>
        /// Broad categorization of the service that is to be provided (e.g. cardiology).
        /// </summary>
        public virtual EncounterServiceType ServiceType { get; set; }

        /// <summary>
        /// Indicates the urgency of the encounter.
        /// </summary>
        public virtual RefListEncounterPriority? Priority { get; set; }

        /// <summary>
        /// The patient or group present at the encounter
        /// </summary>
        public virtual Patient<T> Subject { get; set; }

        /// <summary>
        /// Episode(s) of care that this encounter should be recorded against
        /// </summary>
        public virtual EpisodeOfCare EpisodeOfCare { get; set; }

        /// <summary>
        /// The ServiceRequest that initiated this encounter
        /// </summary>
        public virtual ServiceRequest BasedOn { get; set; }

        /// <summary>
        /// The appointment that scheduled this encounter
        /// </summary>
        public virtual Appointment Appointment { get; set; }

        /// <summary>
        /// The start and end time of the encounter
        /// </summary>
        public virtual Period Period { get; set; }

        /// <summary>
        /// Quantity of time the encounter lasted (less time absent)
        /// </summary>
        public virtual TimeSpan Length { get; set; }

        /// <summary>
        /// Coded reason the encounter takes place
        /// </summary>
        public virtual EncouterReasonCode ReasonCode { get; set; }

        /// <summary>
        /// Reason the encounter takes place (reference)
        /// </summary>
        public virtual Condition<T> ReasonReference { get; set; }

        /// <summary>
        /// The set of accounts that may be used for billing for this Encounter
        /// </summary>
        public virtual Account Account { get; set; }






        /// <summary>
        /// the date that the encounter took place
        /// </summary>
        public virtual DateTime? EncounterDate { get; set; }

        /// <summary>
        /// The practitioner (not necessarily a doctor or nurse, even admin clerk) that was responsible for the encounter
        /// </summary>
        public virtual Facility ServiceProvider { get; set; }

        /// <summary>
        /// The patient involved in the encounter
        /// </summary>

    }
}
