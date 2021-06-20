using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Current state of the encounter.
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterStatus")]
    public enum RefListEncounterStatus : int
    {
        /// <summary>
        /// The Encounter has not yet started.
        /// </summary>
        Planned = 1,
        /// <summary>
        /// The Patient is present for the encounter, however is not currently meeting with a practitioner.
        /// </summary>
        Arrived = 2,
        /// <summary>
        /// The patient has been assessed for the priority of their treatment based on the severity of their condition.
        /// </summary>
        Triaged = 3,
        /// <summary>
        /// The Encounter has begun and the patient is present / the practitioner and the patient are meeting.
        /// </summary>
        InProgress = 4,
        /// <summary>
        /// The Encounter has begun, but the patient is temporarily on leave.
        /// </summary>
        OnLeave = 5,
        /// <summary>
        /// The Encounter has ended.
        /// </summary>
        Finished = 6,
        /// <summary>
        /// The Encounter has ended before it has begun.
        /// </summary>
        Cancelled = 7,
        /// <summary>
        /// This instance should not have been part of this patient's medical record.
        /// </summary>
        [Description("Entered in Error")]
        EnteredInError = 8,
        /// <summary>
        /// The encounter status is unknown. Note that "unknown" is a value of last resort and every attempt should be made to provide a meaningful value other than "unknown".
        /// </summary>
        Unknown = 9
    }
}
