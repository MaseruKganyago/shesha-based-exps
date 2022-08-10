using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    [ReferenceList("Cdm", "EncounterHospitalisationDiets")]
    public enum RefListEncounterHospitalisationDiets
    {
        [Description("Vegetarian")]
        vegetarian = 1,

        [Description("Dairy Free")]
        dairyFree = 2,

        [Description("Nut Free")]
        nutFree = 4,

        [Description("Gluten Free")]
        glutenFree = 8,

        [Description("Vegan")]
        vegan = 16,

        [Description("Halal")]
        halal = 32,

        [Description("Kosher")]
        kosher = 64
    }
}
