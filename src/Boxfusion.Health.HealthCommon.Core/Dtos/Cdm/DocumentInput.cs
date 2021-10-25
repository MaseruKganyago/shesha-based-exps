using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Document))]
    public class DocumentInput : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Practitioner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Type { get; set; }
    }
}
