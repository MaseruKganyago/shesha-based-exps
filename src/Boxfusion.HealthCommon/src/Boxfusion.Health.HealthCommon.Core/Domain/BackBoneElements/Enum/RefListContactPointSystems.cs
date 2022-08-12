using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "ContactPointSystems")]
    public enum RefListContactPointSystems
    {
        [Description("Phone")]
        phone = 1,
        [Description("Fax")]
        fax = 2,
        [Description("Email")]
        email = 3,
        [Description("Pager")]
        pager = 4,
        [Description("Url")]
        url = 5,
        [Description("SMS")]
        sms = 6,
        [Description("Other")]
        other = 7
    }
}
