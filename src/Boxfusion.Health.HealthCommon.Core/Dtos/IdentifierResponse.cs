using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMapFrom(typeof(Identifier))]
    public class IdentifierResponse : EntityDto<Guid>
    {
        public virtual string OwnerId { get; set; }
        public virtual string OwnerType { get; set; }
        public ReferenceListItemValueDto Use { get; set; }
        public ReferenceListItemValueDto Type { get; set; }
        public string System { get; set; }
        public string Value { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public EntityWithDisplayNameDto<Guid?> Assigner { get; set; }
    }
}
