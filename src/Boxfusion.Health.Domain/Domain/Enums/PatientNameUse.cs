using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// A human's name with the ability to identify parts and usage.
    /// </summary>
    [ReferenceList("HealthDomain", "PatientNameUse")]
    public enum RefListPatientNameUse : int
    {
        /// <summary>
        /// Known as/conventional/the one you normally use.
        /// </summary>
        [Description("Usual")]
        usual = 1,
        /// <summary>
        /// The formal name as registered in an official (government) registry, but which name might not be commonly used. May be called "legal name".
        /// </summary>
        [Description("Official")]
        official = 2,
        /// <summary>
        /// A temporary name. Name.period can provide more detailed information. This may also be used for temporary names assigned at birth or in 
        /// emergency situations.
        /// </summary>
        [Description("Temp")]
        temp = 3,
        /// <summary>
        /// A name that is used to address the person in an informal manner, but is not part of their formal or usual name.
        /// </summary>
        [Description("Nickname")]
        nickname = 4,
        /// <summary>
        /// Anonymous assigned name, alias, or pseudonym (used to protect a person's identity for privacy reasons).
        /// </summary>
        [Description("Anonymous")]
        anonymous = 5,
        /// <summary>
        /// This name is no longer in use (or was never correct, but retained for records).
        /// </summary>
        [Description("Old")]
        old = 6,
        /// <summary>
        /// A name used prior to changing name because of marriage. This name use is for use by applications that collect and 
        /// store names that were used prior to a marriage. Marriage naming customs vary greatly around the world, and are constantly 
        /// changing. This term is not gender specific. The use of this term does not imply any particular history for a person's name.
        /// </summary>
        [Description("Name changed for Marriage")]
        maiden = 7
    }
}
