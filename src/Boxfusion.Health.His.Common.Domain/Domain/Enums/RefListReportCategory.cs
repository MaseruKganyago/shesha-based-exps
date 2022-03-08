using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common.Enums
{
    [ReferenceList("Boxfusion.Shesha", "ReportCategory")]
    public enum RefListReportCategory : int
    {
        Leave = 1,
        LeaveGraphs = 2,
        TestSampleReport = 23,

    }
}
