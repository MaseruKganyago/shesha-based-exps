using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
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
    [AutoMap(typeof(HisPatient))]
    public class HisPatientInput : NonUserCdmPatientInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string PatientMasterIndexNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HospitalPatientNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto IdentificationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto PatientProvince { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Ward { get; set; }
    }
}
