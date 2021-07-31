using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(MedicationStatement))]
    public class MedicationStatementInput : EntityDto<Guid>
    {
        public ReferenceListItemValueDto MedicationCode { get; set; }
        public string MedicationText { get; set; }
        public ReferenceListItemValueDto RecordStatus { get; set; }
    }
}