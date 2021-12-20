using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    public interface IHisWardMidnightCensusReportsHelper : ITransientDependency
    {
        Task ResertReportAsync(ResertReportInput input);
    }
}
