using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Indicates the urgency of the encounter.
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterPriority")]
    public enum RefListEncounterPriority : int
    {
        /// <summary>
        /// As soon as possible, next highest priority after stat.
        /// </summary>
        [Description("ASAP")]
        A = 1,
        /// <summary>
        /// Filler should contact the placer as soon as results are available, even for preliminary results. (Was "C" in HL7 version 2.3's reporting priority.)
        /// </summary>
        [Description("Callback Results")]
        CR  = 2,
        /// <summary>
        /// Filler should contact the placer (or target) to schedule the service. (Was "C" in HL7 version 2.3's TQ-priority component.)
        /// </summary>
        [Description("Callback for Scheduling")]
        CS = 3,
        /// <summary>
        /// Filler should contact the placer to schedule the service. (Was "C" in HL7 version 2.3's TQ-priority component.)
        /// </summary>
        [Description("Callback Placer for Scheduling")]
        CSP = 4,
        /// <summary>
        /// Filler should contact the service recipient (target) to schedule the service. (Was "C" in HL7 version 2.3's TQ-priority component.)
        /// </summary>
        [Description("Contact Recipient for Scheduling")]
        CSR = 5,
        /// <summary>
        /// Beneficial to the patient but not essential for survival.
        /// </summary>
        [Description("Elective")]
        EL = 6,
        /// <summary>
        /// An unforeseen combination of circumstances or the resulting state that calls for immediate action.
        /// </summary>
        [Description("Emergency")]
        EM = 7,
        /// <summary>
        /// Used to indicate that a service is to be performed prior to a scheduled surgery. When ordering a service and using the pre-op priority, a check is done to see the amount of time that must be allowed for performance of the service. When the order is placed, a message can be generated indicating the time needed for the service so that it is not ordered in conflict with a scheduled operation.
        /// </summary>
        [Description("Preop")]
        P = 8,
        /// <summary>
        /// An "as needed" order should be accompanied by a description of what constitutes a need. This description is represented by an observation service predicate as a precondition.
        /// </summary>
        [Description("As Needed")]
        PRN = 9,
        /// <summary>
        /// Routine service, do at usual work hours.
        /// </summary>
        [Description("Routine")]
        R = 10,
        /// <summary>
        /// A report should be prepared and sent as quickly as possible.
        /// </summary>
        [Description("Rush Reporting")]
        RR = 11,
        /// <summary>
        /// With highest priority (e.g., emergency).
        /// </summary>
        [Description("Stat")]
        S = 12,
        /// <summary>
        /// It is critical to come as close as possible to the requested time (e.g., for a through antimicrobial level).
        /// </summary>
        [Description("Timing Critical")]
        T = 13,
        /// <summary>
        /// Drug is to be used as directed by the prescriber.
        /// </summary>
        [Description("Use as Directed")]
        UD = 14,
        /// <summary>
        /// Calls for prompt action.
        /// </summary>
        [Description("Urgent")]
        UR = 15
    }
}
