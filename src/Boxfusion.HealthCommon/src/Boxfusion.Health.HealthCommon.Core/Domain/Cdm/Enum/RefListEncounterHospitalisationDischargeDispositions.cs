using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "EncounterHospitalisationDischargeDispositions")]
    public enum RefListEncounterHospitalisationDischargeDispositions
    {
        [Description("Home")]
        home = 1,

        [Description("Alternative home")]
        altHome = 2,

        [Description("Other healthcare facility")]
        otherHcf = 3,

        [Description("Hospice")]
        hosp = 4,

        [Description("Long-term care")]
        longt = 5,

        [Description("Long-term care")]
        aadvice = 6,

        [Description("Expired")]
        exp = 7,

        [Description("Psychiatric hospital")]
        psy = 8,

        [Description("Rehabilitation")]
        rehab = 9,

        [Description("Skilled nursing facility")]
        snf = 10,

        [Description("Other healthcare facility")]
        oth = 11,
    }
}
