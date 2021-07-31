using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.AutoMapper.Dto;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
	[AutoMap(typeof(AllergyIntolerance))]
	public class AllergyIntoleranceResponse: EntityDto<Guid>
	{
        public virtual ReferenceListItemValueDto ClinicalStatus { get; set; }
        public virtual ReferenceListItemValueDto VerificationStatus { get; set; }
        public virtual ReferenceListItemValueDto AllergyType { get; set; }
        public virtual ReferenceListItemValueDto Category { get; set; }
        public virtual ReferenceListItemValueDto Criticality { get; set; }
        public virtual ReferenceListItemValueDto Code { get; set; }
        public virtual EntityWithDisplayNameDto<Guid?> Patient { get; set; }
        public virtual EntityWithDisplayNameDto<Guid?> Encounter { get; set; }
        public virtual DateTime? OnsetDateTime { get; set; }
        public virtual int OnsetAge { get; set; }
        public virtual DateTime? OnsetPeriodStart { get; set; }
        public virtual DateTime? OnsetPeriodEnd { get; set; }
        public virtual decimal? OnsetRangeLow { get; set; }
        public virtual decimal? OnsetRangeHigh { get; set; }
        public virtual string OnsetString { get; set; }
        public virtual DateTime? RecordedDate { get; set; }
        public virtual EntityWithDisplayNameDto<Guid?> Recorder { get; set; }
        public virtual EntityWithDisplayNameDto<Guid?> Asserter { get; set; }
        public virtual DateTime? LastOccurence { get; set; }
        public virtual EntityWithDisplayNameDto<Guid?> Reaction { get; set; }
    }
}