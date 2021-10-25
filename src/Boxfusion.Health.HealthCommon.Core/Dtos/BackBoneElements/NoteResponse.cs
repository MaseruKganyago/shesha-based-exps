using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements
{
    /// <summary>
    /// 
    /// </summary>
    public class NoteResponse
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
