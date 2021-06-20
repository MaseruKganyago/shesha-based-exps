using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// This value set defines a set of codes that can be used to indicate from where the patient came in.
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterAdmitSource")]
    public enum RefListEncounterAdmitSource : int
    {
        /// <summary>
        /// The Patient has been transferred from another hospital for this encounter.
        /// </summary>
        [Description("Transferred from other hospital")]
        hospTrans = 1,
        /// <summary>
        /// The patient has been transferred from the emergency department within the hospital. This is typically used in the transition to an 
        /// inpatient encounter
        /// </summary>
        [Description("From accident/emergency department")]
        emd = 2,
        /// <summary>
        /// The patient has been transferred from an outpatient department within the hospital.
        /// </summary>
        [Description("From outpatient department")]
        outp = 3,
        /// <summary>
        /// The patient has been admitted due to a referred from a General Practitioner.
        /// </summary>
        [Description("General Practitioner referral")]
        gp = 4,
        /// <summary>
        /// The patient has been admitted due to a referred from a Specialist (as opposed to a General Practitioner).
        /// </summary>
        [Description("Medical Practitioner/physician referral")]
        mp = 5,
        /// <summary>
        /// The patient has been transferred from a nursing home.
        /// </summary>
        [Description("From nursing home")]
        nursing = 6,
        /// <summary>
        /// The patient has been transferred from a psychiatric facility.
        /// </summary>
        [Description("From psychiatric hospital")]
        psych = 7,
        /// <summary>
        /// The patient has been transferred from a rehabilitation facility or clinic.
        /// </summary>
        [Description("From rehabilitation facility")]
        rehab = 9,
        /// <summary>
        /// The patient has been admitted from a source otherwise not specified here.
        /// </summary>
        [Description("Other")]
        other = 10,
    }
}
