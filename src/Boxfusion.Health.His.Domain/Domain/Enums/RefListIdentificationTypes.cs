using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("His", "IdentificationTypes")]
    [Obsolete]
    public enum RefListIdentificationTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("SA I.D.")]
        SAID = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Passport")]
        Passport = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Immigration Documents")]
        ImmigrationDocuments = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Asylum Documents")]
        AsylumDocuments = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Not Provided")]
        NotProvided = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other")]
        Other = 6
    }
}
