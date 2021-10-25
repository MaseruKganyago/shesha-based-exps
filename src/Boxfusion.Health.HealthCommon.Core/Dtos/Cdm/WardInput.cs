using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Ward))]
    public class WardInput : LocationInput
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Speciality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? NumberOfBeds { get; set; }
    }
}
