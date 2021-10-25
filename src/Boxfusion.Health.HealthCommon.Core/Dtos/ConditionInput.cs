using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Condition))]
    public class ConditionInput : EntityDto<Guid>
    {
        //public ReferenceListItemValueDto Code { get; set; } //ICD10 Code
        /// <summary>
        /// 
        /// </summary>
		public List<EntityWithDisplayNameDto<Guid?>> Code { get; set; }
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
        public List<ReferenceListItemValueDto> Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Severity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ReferenceListItemValueDto> BodySite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? OnsetDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  int OnsetAge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? OnsetPeriodStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? OnsetPeriodEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  decimal OnsetRangeLow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  decimal OnsetRangeHigh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string OnsetString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? AbatementDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  int AbatementAge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? AbatementPeriodStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? AbatementPeriodEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  decimal AbatementRangeLow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  decimal AbatementRangeHigh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string AbatementString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? RecordedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Recorder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Asserter { get; set; }
    }
}
