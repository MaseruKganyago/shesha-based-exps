using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "DaysOfWeek")]
    public enum RefListDaysOfWeek: long
    {
        [Description("Monday")]
        mon = 1,
        [Description("Tuesday")]
        tue = 2,
        [Description("Wednesday")]
        wed = 4,
        [Description("Thursday")]
        thu = 8,
        [Description("Friday")]
        fri = 16,
        [Description("Saturday")]
        sat = 32,
        [Description("Sunday")]
        sun = 64,        
        [Description("Public Holidays")]
        pub = 128
    }
}
