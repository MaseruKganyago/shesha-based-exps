using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Patients;
using Boxfusion.Health.His.Admissions.Domain;
using Boxfusion.Health.His.Admissions.Services.Reports.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.UI;

namespace Boxfusion.Health.His.Admissions.Services.Reports
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisAdmis/[controller]")]
    public class ReportAppService : SheshaAppServiceBase,  IReportAppService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionsRepository;
        private readonly IRepository<HisPatient, Guid> _hisPatientRepository;

        ///
        public ReportAppService(IRepository<WardAdmission, Guid> wardAdmissionsRepository, IRepository<HisPatient, Guid> hisPatientRepository)
        {
            _wardAdmissionsRepository = wardAdmissionsRepository;
            _hisPatientRepository = hisPatientRepository;
        }

        /// <summary>
        /// Returns the report based on the report type, date and ward
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        [HttpGet, Route("Reports")]
        public async Task<List<ReportResponseDto>> GetReport(RefListReportTypes reportType, Guid wardId, DateTime filterDate)
        {
            List<WardAdmission> allAdmissions = new List<WardAdmission>();
            if (reportType == RefListReportTypes.Daily)
                allAdmissions = await _wardAdmissionsRepository.GetAllListAsync(r => r.Ward.Id == wardId && r.CreationTime.Date == filterDate.Date);
            else
                allAdmissions = await _wardAdmissionsRepository.GetAllListAsync(r => r.Ward.Id == wardId && filterDate.Date.AddMonths(-1).Date <= r.CreationTime.Date && r.CreationTime.Date <= filterDate.Date && r.AdmissionStatus != RefListAdmissionStatuses.rejected);

            if (allAdmissions.Count() < 0)
                throw new UserFriendlyException("No results found for the ward");
           
            var allAdmissionReponse = ObjectMapper.Map<List<ReportResponseDto>>(allAdmissions);

            return allAdmissionReponse;
        }
    }
}
