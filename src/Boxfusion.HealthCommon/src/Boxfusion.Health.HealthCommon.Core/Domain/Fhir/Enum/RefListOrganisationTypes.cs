using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    [ReferenceList("Fhir", "OrganisationTypes")]
    public enum RefListOrganisationTypes
    {
        [Description("Healthcare Provider")]
        prov = 1,

        [Description("Hospital Department")]
        dept = 2,

        [Description("Organizational team")]
        team = 3,

        [Description("Government")]
        govt = 4,

        [Description("Insurance Company")]
        ins = 5,

        [Description("Payer")]
        pay = 6,

        [Description("Educational Institute")]
        edu = 7,

        [Description("Religious Institution")]
        reli = 8,

        [Description("Clinical Research Sponsor")]
        crs = 9,

        [Description("Community Group")]
        cg = 10,

        [Description("Non-Healthcare Business or Corporation")]
        bus = 11,

        [Description("Other")]
        other = 12
    }
}
