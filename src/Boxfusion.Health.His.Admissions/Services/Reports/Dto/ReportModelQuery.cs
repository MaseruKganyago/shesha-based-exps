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
    public class ReportModelQuery : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public long? IdentificationType { get; set; }

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
        public int? Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? AdmissionDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? SeparationDate { get; set; }

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
        public long? AdmissionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Speciality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? PatientProvince { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Classification { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Nationality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? OtherCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? AdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PatientDays { get; set; }
    }
}
