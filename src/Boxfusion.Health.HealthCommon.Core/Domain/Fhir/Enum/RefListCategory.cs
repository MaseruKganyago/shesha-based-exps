using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "Category")]
    public enum RefListCategory : long
    {
        [Description("Problem List Item")]
        problemListItem = 1
    }
}
