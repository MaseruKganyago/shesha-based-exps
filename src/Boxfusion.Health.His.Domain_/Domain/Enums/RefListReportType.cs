﻿using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common.Enums
{
    [ReferenceList("His", "ReportType")]
    public enum RefListReportType : long
    {
        Daily = 1,
        Monthly = 2
    }
}
