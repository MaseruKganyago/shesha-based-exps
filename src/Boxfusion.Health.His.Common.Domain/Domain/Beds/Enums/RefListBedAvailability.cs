using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Beds.Enums
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("His", "BedAvailability")]
    public enum RefListBedAvailability : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Available")]
        Available = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occupied")]
        Occupied = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Out Of Service")]
        OutOfService = 3
    }
}
