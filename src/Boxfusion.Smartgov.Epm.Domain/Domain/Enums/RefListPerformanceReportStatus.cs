using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
    [ReferenceList("Epm", "PerformanceReportStatus")]
    public enum RefListPerformanceReportStatus: long
    {

        [Description("Report is still not published and is still at Planning stage where reporting hierarchy, " +
			"targets etc... are still being finalised i.e. should only be visible to Admins")]
        Planning = 10,

        [Description("We are within the period covered by the report and progress reporting is still in progress.")]
        ReportingInProgress = 20,

        [Description("The all progress reporting has been completed and report values have been vetted and finalised.")]
        Finalised = 30
    }
}
