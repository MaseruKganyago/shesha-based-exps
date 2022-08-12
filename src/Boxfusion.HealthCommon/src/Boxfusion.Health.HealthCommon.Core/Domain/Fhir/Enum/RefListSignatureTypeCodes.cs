using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "SignatureTypeCodes")]
    public enum RefListSignatureTypeCodes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Author's Signature")]
        authorSignature = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coauthor's Signature")]
        coAuthorSignature = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Co-participant's Signature")]
        coParticipantSignature = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transcriptionist/Recorder Signature")]
        transcriptionistRecorderSignature = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Verification Signature")]
        verificationSignature = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Validation Signature")]
        validationSignature = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consent Signature")]
        consentSignature = 64,

        /// <summary>
        /// 
        /// </summary>
        [Description("Signature Witness Signature")]
        signatureWitnessSignature = 128,

        /// <summary>
        /// 
        /// </summary>
        [Description("Event Witness Signature")]
        eventWitnessSignature = 256,

        /// <summary>
        /// 
        /// </summary>
        [Description("Identity Witness Signature")]
        identityWitnessSignature = 512,

        /// <summary>
        /// 
        /// </summary>
        [Description("Consent Witness Signature")]
        consentWitnessSignature = 1024,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interpreter Signature")]
        interpreterSignature = 2048,

        /// <summary>
        /// 
        /// </summary>
        [Description("Review Signature")]
        reviewSignature = 4096,

        /// <summary>
        /// 
        /// </summary>
        [Description("Source Signature")]
        sourceSignature = 8192,

        /// <summary>
        /// 
        /// </summary>
        [Description("Addendum Signature")]
        addendumSignature = 16384,

        /// <summary>
        /// 
        /// </summary>
        [Description("Modification Signature")]
        modificationSignature = 32768,

        /// <summary>
        /// 
        /// </summary>
        [Description("Administrative (Error/Edit) Signature")]
        administrativeErrorEditSignature = 65536,

        /// <summary>
        /// 
        /// </summary>
        [Description("Timestamp Signature	Timestamp Signature")]
        timestampSignatureTimestampSignature = 131072

    }
}
