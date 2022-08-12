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
    [ReferenceList("Fhir", "ProvenanceParticipantTypes")]
    public enum RefListProvenanceParticipantTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Enterer")]
        enterer = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Performer")]
        performer = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Author")]
        author = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Verifier")]
        verifier = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Legal Authenticator")]
        legal = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Attester")]
        attester = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Informant")]
        informant = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Custodian")]
        custodian = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Assembler")]
        assembler = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Composer")]
        composer = 10,
    }
}
