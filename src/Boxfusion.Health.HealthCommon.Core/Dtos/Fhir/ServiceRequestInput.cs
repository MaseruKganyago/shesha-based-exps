using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(ServiceRequest))]
	public class ServiceRequestInput : EntityDto<Guid>
    {
		/// <summary>
		/// 
		/// </summary>
		public string Identifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BasedOnOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BasedOnOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> Replaces { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Requisition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Intent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> Category { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Priority { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool DoNotPerform { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Code { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> OrderDetail { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal QuantityQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal QuantityRatioNumerator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal QuantityRatioDenominator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal QuantityRangeLow { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal QuantityRangeHigh { get; set; }
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
		public DateTime? OccurenceDateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OccurencePeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OccurencePeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool AsNeededBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto AsNeededCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AuthoredOn { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string RequestOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string RequestOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto PerformerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string PerformerOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string PerformerOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto LocationCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> LocationReference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> ReasonCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ReasonReferenceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ReasonReferenceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string InsuranceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string InsuranceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SupportingInfoOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SupportingInfoOwnerType { get; set; }

		//public EntityWithDisplayNameDto<Guid?> Specimen { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> BodySite { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<NoteInput> Notes { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PatientInstruction { get; set; }

		//public EntityWithDisplayNameDto<Guid?> RelevantHistory { get; set; }
	}
}
