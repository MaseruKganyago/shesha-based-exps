using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(AllergyIntolerance))]
    public class AllergyIntoleranceInput : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto ClinicalStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto VerificationStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AllergyType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Criticality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid?>> AllergyCodes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Patient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? OnsetDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int OnsetAge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? OnsetPeriodStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? OnsetPeriodEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OnsetRangeLow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? OnsetRangeHigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OnsetString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? RecordedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Recorder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Asserter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastOccurence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Reaction { get; set; }
    }
}