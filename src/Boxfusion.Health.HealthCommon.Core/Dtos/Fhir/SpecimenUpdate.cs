using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Specimen))]
    public class SpecimenUpdate
    {
        /// <summary>
        /// 
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessionIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Patient Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ReceivedTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Specimen Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceRequest Request { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ReferenceListItemValueDto> Condition { get; set; }
    }
}
