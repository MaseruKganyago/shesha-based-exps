using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Note))]
    public class NoteInput : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Priority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Parent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NoteText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Author { get; set; }
    }
}
