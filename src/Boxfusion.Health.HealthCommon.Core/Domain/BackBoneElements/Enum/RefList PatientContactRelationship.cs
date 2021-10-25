using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "PatientContactRelationship")]
    public enum RefListPatientContactRelationship
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency Contact")]
        C = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Employer")]
        E = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Federal Agency")]
        F = 4,
        /// <summary>
        /// 
        /// </summary>
        [Description("Insurance Company")]
        I = 8,
        /// <summary>
        /// 
        /// </summary>
        [Description("Next-of-Kin")]
        N = 16,
        /// <summary>
        /// 
        /// </summary>
        [Description("State Agency")]
        S = 32,
        /// <summary>
        /// 
        /// </summary>
        [Description("Unknown")]
        U = 64
    }
}
