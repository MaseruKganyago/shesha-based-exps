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
    [AutoMap(typeof(Hospital))]
    public class HospitalInput : OrganisationInput
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal? Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Altitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Speciality { get; set; }
    }
}
