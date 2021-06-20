using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// This example value set defines a set of codes that can be used to indicate the type of encounter: a specific code indicating type of service provided.
    /// Specific type of encounter (e.g. e-mail consultation, surgical day-care, skilled nursing, rehabilitation).
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterType")]
    public enum RefListEncounterType : int
    {
        /// <summary>
        /// Annual diabetes mellitus screening
        /// </summary>
        [Description("Annual diabetes mellitus screening")]
        ADMS = 1,
        /// <summary>
        /// Bone drilling/bone marrow punction in clinic
        /// </summary>
        [Description("Bone drilling/bone marrow punction in clinic")]
        BDBMclin = 2,
        /// <summary>
        /// Infant colon screening - 60 minutes
        /// </summary>
        [Description("Infant colon screening - 60 minutes")]
        CCS60 = 3,
        /// <summary>
        /// Outpatient Kenacort injection
        /// </summary>
        [Description("Outpatient Kenacort injection")]
        OKI = 4
    }
}
