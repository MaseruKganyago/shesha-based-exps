using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
	[AutoMap(typeof(Procedure))]
	public class ProcedureResponse: EntityDto<Guid>
	{
        public string Identifier { get; set; }

        public string BasedOnOwnerId { get; set; }

        public string BasedOnOwnerType { get; set; }

        public string PartOfOwnerId { get; set; }

        public string PartOfOwnerType { get; set; }

        public ReferenceListItemValueDto Status { get; set; }

        public ReferenceListItemValueDto StatusReason { get; set; }

        public List<ReferenceListItemValueDto> Category { get; set; }

        public ReferenceListItemValueDto CodingSystem { get; set; }

        public ReferenceListItemValueDto CodeValue { get; set; }

        public string CodeText { get; set; }

        public EntityWithDisplayNameDto<Guid?> Subject { get; set; }

        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }

        public DateTime? PerformedDateTime { get; set; }

        public DateTime? PerformedPeriodStart { get; set; }

        public string PerformedString { get; set; }

        public int? PerformedAge { get; set; }

        public Decimal? PerformedRangeLow { get; set; }

        public Decimal? PerformedRangeHigh { get; set; }

        public EntityWithDisplayNameDto<Guid?> Recorder { get; set; }

        public EntityWithDisplayNameDto<Guid?> Asserter { get; set; }

        public ReferenceListItemValueDto PerformerFunction { get; set; }

        public string PerformerActorOwnerId { get; set; }

        public string PerformerActorOwnerType { get; set; }

        public EntityWithDisplayNameDto<Guid?> PerformerOnBehalfOf { get; set; }

        public EntityWithDisplayNameDto<Guid?> Location { get; set; }

        public List<ReferenceListItemValueDto> ReasonCode { get; set; }

        public string ReasonReferenceOwnerId { get; set; }

        public string ReasonReferenceOwnerType { get; set; }

        public List<ReferenceListItemValueDto> BodySite { get; set; }

        public ReferenceListItemValueDto Outcome { get; set; }

        public string ReportOwnerId { get; set; }

        public string ReportOwnerType { get; set; }

        public ReferenceListItemValueDto Complication { get; set; }

        public EntityWithDisplayNameDto<Guid?> ComplicationDetail { get; set; }

        public List<ReferenceListItemValueDto> FollowUp { get; set; }
    }
}