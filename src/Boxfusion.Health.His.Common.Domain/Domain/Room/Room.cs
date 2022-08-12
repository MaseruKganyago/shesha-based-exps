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
    [Entity(TypeShortAlias = "His.Rooms")]
    public class Room : FhirLocation
    {
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public RefListRoomTypes RoomType { get; set; }
        public int? NumberOfBeds { get; set; }

    }
}
