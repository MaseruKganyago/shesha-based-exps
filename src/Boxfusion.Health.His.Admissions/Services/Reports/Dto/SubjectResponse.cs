using Abp.AutoMapper;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class SubjectResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Nationality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto PatientProvince { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto IdentificationType { get; set; }
    }
}
