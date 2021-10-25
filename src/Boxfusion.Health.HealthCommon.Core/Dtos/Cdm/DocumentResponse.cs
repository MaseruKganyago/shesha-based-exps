using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
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
    public class DocumentResponse : EntityDto<Guid>
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

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> StoredFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public EncounterLocationResponse Location { get; set; }
    }
}
