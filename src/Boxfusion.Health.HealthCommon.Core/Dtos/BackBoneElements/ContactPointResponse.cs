using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(ContactPoint))]
    public class ContactPointResponse : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OwnerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto System { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Use { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }
    }
}
