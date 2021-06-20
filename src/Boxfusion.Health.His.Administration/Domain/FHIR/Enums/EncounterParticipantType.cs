using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Ward speciality e.g. medicine, surgery etc. A speciality can have more than one ward
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterPractionerType")]
    public enum RefListEncounterParticipantType : int
    {
        /// <summary>
        /// The practitioner who is responsible for admitting a patient to a patient encounter.
        /// </summary>
        [Description("Admitter")]
        ADM = 1,
        /// <summary>
        /// The practitioner that has responsibility for overseeing a patient's care during a patient encounter.
        /// </summary>
        [Description("Attender")]
        ATND = 2,
        /// <summary>
        /// A person or organization who should be contacted for follow-up questions about the act in place of the author.
        /// </summary>
        [Description("Callback Contact")]
        CALLBCK = 3,
        /// <summary>
        /// An advisor participating in the service by performing evaluations and making recommendations.
        /// </summary>
        [Description("Consultant")]
        CON = 4,
        /// <summary>
        /// The practitioner who is responsible for the discharge of a patient from a patient encounter.
        /// </summary>
        [Description("Discharger")]
        DIS = 5,
        /// <summary>
        /// Only with Transportation services. A person who escorts the patient.
        /// </summary>
        [Description("Escourt")]
        ESC = 6,
        /// <summary>
        /// A person having referred the subject of the service to the performer (referring physician). Typically, a referring physician will receive a report.
        /// </summary>
        [Description("Referrer")]
        REF = 7,
        /// <summary>
        /// A person assisting in an act through his substantial presence and involvement This includes: assistants, technicians, associates, or whatever the job titles may be.
        /// </summary>
        [Description("Secondary Performer")]
        SPRF = 8,
        /// <summary>
        /// The principal or primary performer of the act.
        /// </summary>
        [Description("Primary Performer")]
        PPRF = 9,
        /// <summary>
        /// Indicates that the target of the participation is involved in some manner in the act, but does not qualify how.
        /// </summary>
        [Description("Participation")]
        PART = 10,
        /// <summary>
        /// A translator who is facilitating communication with the patient during the encounter.
        /// </summary>
        [Description("Translator")]
        Translator = 11,
        /// <summary>
        /// A person to be contacted in case of an emergency during the encounter.
        /// </summary>
        [Description("Emergency")]
        Emergency = 12
    }
}
