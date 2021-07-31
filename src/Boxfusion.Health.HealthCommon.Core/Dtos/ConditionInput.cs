using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(Condition))]
    public class ConditionInput : EntityDto<Guid>
    {
        //public ReferenceListItemValueDto Code { get; set; } //ICD10 Code
		public List<EntityWithDisplayNameDto<Guid?>> Code { get; set; }
		public string Text { get; set; }
        public ReferenceListItemValueDto RecordStatus { get; set; }
    }
}
