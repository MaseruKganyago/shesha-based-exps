using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.AutoMapper.Dto;
using Shesha.Notes.Dto;
using System;
using System.Collections.Generic;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
	[AutoMap(typeof(MedicationStatement))]
	public class MedicationStatementResponse: EntityDto<Guid>
	{
        public  string BasedOnOwnerId { get; set; }
        public  string BasedOnOwnerType { get; set; }
        public  string PartOfOwnerId { get; set; }
        public  string PartOfOwnerType { get; set; }
        public  ReferenceListItemValueDto Status { get; set; }
        public  List<ReferenceListItemValueDto> StatusReason { get; set; }
        public  ReferenceListItemValueDto Category { get; set; }
        public  ReferenceListItemValueDto MedicationCodeableConcept { get; set; }
        public EntityWithDisplayNameDto<Guid?> MedicationReference { get; set; }
        public  string MedicationText { get; set; }
        public EntityWithDisplayNameDto<Guid?> Subject { get; set; }
        public  string ContextOwnerId { get; set; }
        public  string ContextOwnerType { get; set; }
        public  DateTime? EffectiveDateTime { get; set; }
        public  DateTime? EffectivePeriodStart { get; set; }
        public  DateTime? EffectivePeriodEnd { get; set; }
        public  DateTime? DateAsserted { get; set; }
        public EntityWithDisplayNameDto<Guid?> InformationSource { get; set; }
        public  string DerivedFromOwnerId { get; set; }
        public  string DerivedFromOwnerType { get; set; }
        public List<ReferenceListItemValueDto> ReasonCode { get; set; }
        public  string ReasonReferenceOwnerId { get; set; }
        public  string ReasonReferenceOwnerType { get; set; }
		public List<NoteDto>  Notes { get; set; }
		public List<DosageResponse> Dosage { get; set; }
    }
}