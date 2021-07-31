using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(CdmAddress))]

    public class CdmAddressResponse : EntityDto<Guid>
    {
        public virtual string OwnerId { get; set; }
        public virtual string OwnerType { get; set; }
        public ReferenceListItemValueDto Use { get; set; }
        public ReferenceListItemValueDto Type { get; set; }
        public virtual string District { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
    }
}
