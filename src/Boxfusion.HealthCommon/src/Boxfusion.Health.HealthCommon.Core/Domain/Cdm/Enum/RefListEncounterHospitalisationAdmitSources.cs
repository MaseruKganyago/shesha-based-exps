using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "EncounterHospitalisationAdmitSources")]
    public enum RefListEncounterHospitalisationAdmitSources
    {
        [Description("Transferred from other hospital")]
        hospTrans = 1,

        [Description("From accident/emergency department")]
        emd = 2,

        [Description("From outpatient department")]
        outp = 3,

        [Description("Born in hospital")]
        born = 4,

        [Description("General Practitioner referral")]
        gp = 5,

        [Description("Medical Practitioner/physician referral")]
        mp = 6,

        [Description("From nursing home")]
        nursing = 7,

        [Description("From psychiatric hospital")]
        psych = 8,

        [Description("From rehabilitation facility")]
        rehab = 9,

        [Description("Other")]
        other = 9,
    }
}
