using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain.Enums
{ 
    [ReferenceList("Boxfusion.Shesha", "ReportType")]
    public enum RefListReportingReportTypes : int
    {
        Report = 1,
        Pivot = 2,
        Dashboard = 3,
    }
}
