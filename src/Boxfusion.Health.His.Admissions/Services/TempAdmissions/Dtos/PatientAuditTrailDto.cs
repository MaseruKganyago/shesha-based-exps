using Abp.AutoMapper;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(WardAdmission))]
    public class PatientAuditTrailDto 
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Speciality { get; set; }
    }
}
