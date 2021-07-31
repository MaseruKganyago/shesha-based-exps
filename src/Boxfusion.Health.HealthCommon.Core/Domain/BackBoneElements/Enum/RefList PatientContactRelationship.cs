using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "PatientContactRelationship")]
    public enum RefListPatientContactRelationship
    {
        [Description("Emergency Contact")]
        C = 1,

        [Description("Employer")]
        E = 2,

        [Description("Federal Agency")]
        F = 4,

        [Description("Insurance Company")]
        I = 8,

        [Description("Next-of-Kin")]
        N = 16,

        [Description("State Agency")]
        S = 32,

        [Description("Unknown")]
        U = 64
    }
}
