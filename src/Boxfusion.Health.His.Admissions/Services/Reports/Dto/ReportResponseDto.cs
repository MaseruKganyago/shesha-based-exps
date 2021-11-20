using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(WardAdmission),typeof(HisPatient))]
    public class ReportResponseDto : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid PatientId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListIdentificationTypes? IdentificationType { get; set; }
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
        public RefListGender? Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AdminstrationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HospitalPatientNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WardAdmissionNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PatientSurname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListAdmissionTypes? AdmissionType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListWardSpecialities? Speciality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Diagnosis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListProvinces? PatientProvice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListClassifications? Classification { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Nationality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListOtherCategories? OtherCategories { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListAdmissionStatuses? AdmissionStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PatientDays { get; set; }

    }
}
