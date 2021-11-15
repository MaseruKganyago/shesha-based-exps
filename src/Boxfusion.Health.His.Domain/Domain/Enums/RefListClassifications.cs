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
    [ReferenceList("His", "Classifications")]
    public enum RefListClassifications : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("H0")]
        h0 = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("H1")]
        h1 = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("H2")]
        h2 = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("H3")]
        h3 = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("HG")]
        hg = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("PG")]
        pg = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("PF")]
        pf = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("PH")]
        ph = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("WS")]
        ws = 9
    }
}
