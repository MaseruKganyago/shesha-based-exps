using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Services.Patients;
using Shesha;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Administration.Services.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    public class ReportAppService : SheshaAppServiceBase,  IReportAppService
    {
        private readonly IPatientsAppService _patientAppService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientAppService"></param>
        public ReportAppService(IPatientsAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }
    }
}
