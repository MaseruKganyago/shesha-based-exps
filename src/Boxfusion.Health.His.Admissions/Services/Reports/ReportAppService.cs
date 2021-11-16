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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdminssionsRepository"></param>
        /// <param name="wardRepository"></param>
        public ReportAppService(IRepository<WardAdmission, Guid> wardAdminssionsRepository)
        {
            _wardAdminssionsRepository = wardAdminssionsRepository;
        }

        /// <summary>
        /// Returns the report based on the report type, date and ward
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="wardId"></param>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        [HttpGet, Route("report")]
        public async Task<List<ReportResponseDto>> GetReport(RefListReportTypes reportType, Guid wardId, DateTime filterDate)
        {
            List<ReportResponseDto> results = new List<ReportResponseDto>();
            var allAdmissions = await _wardAdminssionsRepository.GetAllListAsync(r => r.SeparationDestinationWard.Id == wardId);
            if (allAdmissions == null)
                throw new UserFriendlyException("No results found for the ward");

            if (reportType == RefListReportTypes.Daily)
            {
                var todayAdmissions = allAdmissions.Where(r => r.CreationTime.Day == filterDate.Day);
                var response = allAdmissions.Select(r => new ReportResponseDto()
                {
                    IDNumber = r.Subject.IdentityNumber,
                    AdminstrationDate = r.CreationTime,
                    AdmissionStatus = r.AdmissionStatus,
                    AdmissionType = r.AdmissionType,
                    Speciality = r.SeparationDestinationWard.Speciality,
                    DOB = r.Subject.DateOfBirth,
                    Gender = r.Subject.Gender,
                   // HospitalPatientNumber = r.WardAdmissionNumber,
                    Nationality = r.Subject.Nationality,
                    PatientName = r.Subject.FirstName,
                    PatientSurname = r.Subject.LastName,
                    WardAdmissionNumber = r.WardAdmissionNumber,
                    // PatientDays = 
                    //PatientProvice = r.pro
                   // OtherCategories = r.SeparationDes
                    //IDType = r.Subject.do
                    //Diagnosis = r.Subject
                });

                results.AddRange(response);
            }
            else
            {

            }

            return results;
        }
    }
}
