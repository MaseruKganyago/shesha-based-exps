using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(ContactPointResponse))]
    public class ContactPointInput : EntityDto<Guid>
    {
        public string OwnerId { get; set; }
        public string OwnerType { get; set; }

        public ReferenceListItemValueDto System { get; set; }
        public string Value { get; set; }

        public ReferenceListItemValueDto Use { get; set; }
        public int? Rank { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
    }
}
