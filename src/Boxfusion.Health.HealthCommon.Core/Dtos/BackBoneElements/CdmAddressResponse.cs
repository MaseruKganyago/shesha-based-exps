using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CdmAddress))]

    public class CdmAddressResponse : EntityDto<Guid>
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
        public virtual string District { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Country { get; set; }
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
