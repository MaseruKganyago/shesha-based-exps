using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(Qualification))]
    public class QualificationResponse : EntityDto<Guid>
    {
        public EntityWithDisplayNameDto<Guid?> Owner { get; set; }
        public string Identifier { get; set; }
        public ReferenceListItemValueDto Code { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public EntityWithDisplayNameDto<Guid?> Issuer { get; set; }
    }
}
