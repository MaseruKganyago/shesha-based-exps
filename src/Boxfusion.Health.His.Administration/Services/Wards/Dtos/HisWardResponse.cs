using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Administration.Services.Wards.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(new[] { typeof(HisWard) })]
    public class HisWardResponse : WardResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto MidnightCensusApprovalModel { get; set; }
    }
}
