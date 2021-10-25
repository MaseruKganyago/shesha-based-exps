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
    [AutoMap(typeof(Identifier))]
    public class IdentifierInput : EntityDto<Guid?>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string OwnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string OwnerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Use { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string System { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PeriodStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PeriodEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Assigner { get; set; }
    }
}
