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
        private readonly IRepository<WardAdmission, Guid> _wardAdminssionsRepository;
        private readonly IRepository<HisPatient, Guid> _hisPatientRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdminssionsRepository"></param>
        /// <param name="hisPatientRepository"></param>
        public ReportAppService(IRepository<WardAdmission, Guid> wardAdminssionsRepository, IRepository<HisPatient, Guid> hisPatientRepository)
        {
            _wardAdminssionsRepository = wardAdminssionsRepository;
            _hisPatientRepository = hisPatientRepository;
        }

        /// <summary>
        /// Returns the report based on the report type, date and ward
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        [HttpGet, Route("Report")]
        public async Task<List<ReportResponseDto>> GetReport(RefListReportTypes reportType, Guid wardId, DateTime filterDate)
        {
            var allAdmissions = await _wardAdminssionsRepository.GetAllListAsync(r => r.SeparationDestinationWard.Id == wardId);
            var patients = await _hisPatientRepository.GetAllListAsync();
            if (allAdmissions == null)
                throw new UserFriendlyException("No results found for the ward");

            var totalAddmissions = new List<WardAdmission>();
            if (reportType == RefListReportTypes.Daily)
                totalAddmissions = allAdmissions.Where(r => r.CreationTime.Day == filterDate.Day).ToList();
            else
                totalAddmissions = allAdmissions.Where(r => filterDate.Date.AddMonths(-1).Date <= r.CreationTime.Date && r.CreationTime.Date <= filterDate.Date).ToList();

            var reportResposnseResults = allAdmissions.Select(r => ObjectMapper.Map<ReportResponseDto>(r));
            foreach (var item in reportResposnseResults)
            {
                var patient = patients.FirstOrDefault(e => e.Id == item.PatientId);
                if (patient != null)
                    ObjectMapper.Map(patient, item);
            }
            return reportResposnseResults.ToList();
           
        }
    }
}
