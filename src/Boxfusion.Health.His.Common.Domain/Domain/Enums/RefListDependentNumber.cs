using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Common.Enums
{
  
    
    [ReferenceList("His", "DependentNumber")]
    public enum RefListDependentNumber: long
    {
        
        /// <summary>
        /// 
        /// </summary>
        [Description("00")]
        
        D01 = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("01")]
        D02 = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("03")]
        D03 = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("04")]
        D04 = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("05")]
        D05 = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("06")]
        D06 = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("07")]
        D07 = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("08")]
        D08 = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("09")]
        D09 = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("010")]
        D010 = 10
    }
}
