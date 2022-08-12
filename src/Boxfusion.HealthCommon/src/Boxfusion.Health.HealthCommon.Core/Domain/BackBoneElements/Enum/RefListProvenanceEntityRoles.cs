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
    [ReferenceList("Fhir", "ProvenanceEntityRoles")]
    public enum RefListProvenanceEntityRoles : long
    {  /// <summary>
       /// 
       /// </summary>
        [Description("Derivation")]
        derivation = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Revision")]
        revision = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Quotation")]
        quotation = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source")]
        source = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Removal")]
        removal = 5
    }
}
