using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Type's of person's nationality identification
    /// </summary>
    [ReferenceList("HealthDomain", "IdentificationType")]
    public enum RefListIdentificationType : int
    {
        /// <summary>
        /// South African Identity document
        /// </summary>
        [Description("SA I.D. Number")]
        IdentityNumber = 1,
        /// <summary>
        /// Passport identification document
        /// </summary>
        [Description("Passport Number")]
        PassportNumber = 2,
        /// <summary>
        /// Immigration identification document
        /// </summary>
        [Description("Immigrant Number")]
        ImmigrantNumber = 3,
        /// <summary>
        /// Asylum identification document
        /// </summary>
        [Description("Asylum Number")]
        AsylumNumber = 4,
        /// <summary>
        /// No identification document provided
        /// </summary>
        [Description("Not Provided")]
        NotProvided = 5,
        /// <summary>
        /// Other form of identification provided
        /// </summary>
        [Description("Other")]
        Other = 6,
    }
}
