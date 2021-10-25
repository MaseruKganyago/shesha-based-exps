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
    [ReferenceList("Fhir", "ContactPointUses")]
    public enum RefListContactPointUses : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Home")]
        home = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Work")]
        work = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Temporary")]
        temp = 3,
        /// <summary>
        /// 
        /// </summary>
        [Description("Old")]
        old = 4,
        /// <summary>
        /// 
        /// </summary>
        [Description("Mobile")]
        mobile = 5
    }
}
