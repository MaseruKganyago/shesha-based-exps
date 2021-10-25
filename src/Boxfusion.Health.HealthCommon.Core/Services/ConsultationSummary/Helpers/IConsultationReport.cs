using Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConsultationReport
    {
        Task GenerateConsultationReport(ConsultationSummaryInput input);
    }
}
