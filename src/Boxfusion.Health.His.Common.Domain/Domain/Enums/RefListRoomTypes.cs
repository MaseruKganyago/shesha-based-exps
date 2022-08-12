using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Common.Enums
{
    [ReferenceList("His", "RoomTypes")]
    public enum RefListRoomTypes: long
    {
        [Description("Private Room")]
        privateRoom = 1,
        [Description("General Room")]
        generalRoom = 2,
        [Description("Executive Room")]
        executiveRoom
    }
}
