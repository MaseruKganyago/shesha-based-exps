using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Common;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(HisPatient))]
    public class HisPatientInput: NonUserCdmPatientInput
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
	}
}
