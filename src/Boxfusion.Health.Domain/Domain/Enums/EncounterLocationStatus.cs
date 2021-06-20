using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// The status of the participants' presence at the specified location during the period specified. 
    /// If the participant is no longer at the location, then the period will have an end date/time.
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterLocationStatus")]
    public enum RefListEncounterLocationStatus : int
    {
        /// <summary>
        /// The patient is planned to be moved to this location at some point in the future.
        /// </summary>
        [Description("Planned")]
        planned = 1,
        /// <summary>
        /// The patient is currently at this location, or was between the period specified. 
        /// A system may update these records when the patient leaves the location to either reserved, or completed.
        /// </summary>
        [Description("Active")]
        active = 2,
        /// <summary>
        /// This location is held empty for this patient.
        /// </summary>
        [Description("Reserved")]
        reserved = 3,
        /// <summary>
        /// The patient was at this location during the period specified. Not to be used when the patient is currently at the location.
        /// </summary>
        [Description("Completed")]
        completed = 4
    }
}
