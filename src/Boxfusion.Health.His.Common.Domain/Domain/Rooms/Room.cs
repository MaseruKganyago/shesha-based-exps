using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.Room
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.Rooms")]
    public class Room : FhirLocation
    {
        /// <summary>
        /// 
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RoomDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RefListRoomTypes RoomType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NumberOfBeds { get; set; }
    }
}
