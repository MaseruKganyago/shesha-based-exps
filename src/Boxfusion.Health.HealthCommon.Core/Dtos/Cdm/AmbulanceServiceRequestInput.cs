using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Newtonsoft.Json;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(AmbulanceServiceRequest))]
    public class AmbulanceServiceRequestInput : CdmServiceRequestInput
    {
        /// <summary>
        /// 
        /// </summary>
        public CdmAddressInput PickUpAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto ProvisionalCondition { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
    }
}
