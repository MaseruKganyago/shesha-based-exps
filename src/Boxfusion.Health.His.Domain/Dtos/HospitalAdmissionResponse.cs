using Abp.AutoMapper;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(HospitalAdmission))]
    public class HospitalAdmissionResponse: HisAdmissionResponse
	{
        /// <summary>
        /// 
        /// </summary>
        public string HospitalAdmissionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto HospitalAdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Classification { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto OtherCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> TransferFroHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> TransferToHospital { get; set; }
    }
}
