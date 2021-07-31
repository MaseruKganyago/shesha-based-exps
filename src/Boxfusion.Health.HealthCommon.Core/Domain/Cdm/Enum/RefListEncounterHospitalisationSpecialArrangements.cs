using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "EncounterHospitalisationSpecialArrangements")]
    public enum RefListEncounterHospitalisationSpecialArrangements
    {
        [Description("Wheelchair")]
        wheel = 1,

        [Description("Additional bedding")]
        addBed = 2,

        [Description("Interpreter")]
        inte = 4,

        [Description("Attendant")]
        att = 8,

        [Description("Guide dog")]
        dog = 16
    }
}
