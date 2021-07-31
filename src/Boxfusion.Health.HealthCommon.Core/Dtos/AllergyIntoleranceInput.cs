using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(AllergyIntolerance))]
    public class AllergyIntoleranceInput : EntityDto<Guid>
    {
        public ReferenceListItemValueDto Code { get; set; } 
        public string Text { get; set; }
        public ReferenceListItemValueDto RecordStatus { get; set; }
    }
}