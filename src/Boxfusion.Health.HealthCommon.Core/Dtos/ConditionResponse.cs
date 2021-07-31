using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
	[AutoMap(typeof(Condition))]
	public class ConditionResponse: EntityDto<Guid>
	{
        public ReferenceListItemValueDto ClinicalStatus { get; set; }
        public ReferenceListItemValueDto VerificationStatus { get; set; }
        public ReferenceListItemValueDto Category { get; set; }
        public ReferenceListItemValueDto Severity { get; set; }
        public List<EntityWithDisplayNameDto<Guid?>> Code { get; set; }
        public ReferenceListItemValueDto BodySite { get; set; }
        public EntityWithDisplayNameDto<Guid?> Subject { get; set; }
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }
        public  DateTime? OnsetDateTime { get; set; }
        public  int? OnsetAge { get; set; }
        public  DateTime? OnsetPeriodStart { get; set; }
        public  DateTime? OnsetPeriodEnd { get; set; }
        public  decimal? OnsetRangeLow { get; set; }
        public  decimal? OnsetRangeHigh { get; set; }
        public  string OnsetString { get; set; }
        public  DateTime? AbatementDateTime { get; set; }
        public  int? AbatementAge { get; set; }
        public  DateTime? AbatementPeriodStart { get; set; }
        public  DateTime? AbatementPeriodEnd { get; set; }
        public  decimal? AbatementRangeLow { get; set; }
        public  decimal? AbatementRangeHigh { get; set; }
        public  string AbatementString { get; set; }
        public  DateTime? RecordedDate { get; set; }
        public EntityWithDisplayNameDto<Guid?> Recorder { get; set; }
        public EntityWithDisplayNameDto<Guid?> Asserter { get; set; }
    }
}