using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "EncounterHospitalisationSpecialCourtesies")]
    public enum RefListEncounterHospitalisationSpecialCourtesies
    {
        [Description("Extended Courtesy")]
        ext = 1,

        [Description("Normal Courtesy")]
        nrm = 2,

        [Description("Professional Courtesy")]
        prf = 4,

        [Description("Staff")]
        stf = 8,

        [Description("Very Important Person")]
        vip = 16
    }
}
