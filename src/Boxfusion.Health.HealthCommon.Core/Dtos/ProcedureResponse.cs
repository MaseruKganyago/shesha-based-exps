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
        public virtual string Identifier { get; set; }

        public virtual string BasedOnOwnerId { get; set; }

        public virtual string BasedOnOwnerType { get; set; }

        public virtual string PartOfOwnerId { get; set; }

        public virtual string PartOfOwnerType { get; set; }

        public virtual ReferenceListItemValueDto Status { get; set; }

        public virtual ReferenceListItemValueDto StatusReason { get; set; }

        public virtual List<ReferenceListItemValueDto> Category { get; set; }

        public virtual ReferenceListItemValueDto CodingSystem { get; set; }

        public virtual ReferenceListItemValueDto CodeValue { get; set; }

        public virtual string CodeText { get; set; }

        public virtual EntityWithDisplayNameDto<Guid?> Subject { get; set; }

        public virtual EntityWithDisplayNameDto<Guid?> Encounter { get; set; }

        public virtual DateTime? PerformedDateTime { get; set; }

        public virtual DateTime? PerformedPeriodStart { get; set; }

        public virtual string PerformedString { get; set; }

        public virtual int? PerformedAge { get; set; }

        public virtual Decimal? PerformedRangeLow { get; set; }

        public virtual Decimal? PerformedRangeHigh { get; set; }

        public virtual EntityWithDisplayNameDto<Guid?> Recorder { get; set; }

        public virtual EntityWithDisplayNameDto<Guid?> Asserter { get; set; }

        public virtual ReferenceListItemValueDto PerformerFunction { get; set; }

        public virtual string PerformerActorOwnerId { get; set; }

        public virtual string PerformerActorOwnerType { get; set; }

        public virtual EntityWithDisplayNameDto<Guid?> PerformerOnBehalfOf { get; set; }

        public virtual EntityWithDisplayNameDto<Guid?> Location { get; set; }

        public virtual List<ReferenceListItemValueDto> ReasonCode { get; set; }

        public virtual string ReasonReferenceOwnerId { get; set; }

        public virtual string ReasonReferenceOwnerType { get; set; }

        public virtual List<ReferenceListItemValueDto> BodySite { get; set; }

        public virtual ReferenceListItemValueDto Outcome { get; set; }

        public virtual string ReportOwnerId { get; set; }

        public virtual string ReportOwnerType { get; set; }

        public virtual ReferenceListItemValueDto Complication { get; set; }

        public virtual EntityWithDisplayNameDto<Guid?> ComplicationDetail { get; set; }

        public virtual List<ReferenceListItemValueDto> FollowUp { get; set; }
    }
}