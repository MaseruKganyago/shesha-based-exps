using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.AutoMapper.Dto;
using Shesha.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(WardAdmission),typeof(HisPatient),typeof(HospitalAdmission))]
    public class ReportResponseDto : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto IdentificationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WardAdmissionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HospitalPatientNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AdmissionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Speciality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto PatientProvince { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Classification { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Nationality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto OtherCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PatientDays { get; set; }
    }
}
