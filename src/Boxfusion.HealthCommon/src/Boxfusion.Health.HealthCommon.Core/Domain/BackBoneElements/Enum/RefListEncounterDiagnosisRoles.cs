using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    [ReferenceList("Fhir", "EncounterDiagnosisRoles")]
    public enum RefListEncounterDiagnosisRoles
    {
        [Description("Admission diagnosis")]
        AD = 1,
        [Description("Discharge diagnosis")]
        DD = 2,
        [Description("Chief complaint")]
        CC = 3,
        [Description("Comorbidity diagnosis")]
        CM = 4,
        [Description("Pre-op diagnosis")]
        preop = 5,
        [Description("Post-op diagnosis")]
        postop = 6,
        [Description("Billing")]
        bill = 7,
        [Description("Tele Consultation")]
        teleConsultation = 8
    }
}
