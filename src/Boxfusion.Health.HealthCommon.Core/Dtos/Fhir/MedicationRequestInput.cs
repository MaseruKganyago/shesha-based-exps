using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(MedicationRequest))]
    public class MedicationRequestInput : EntityDto<Guid>
    {
		/// <summary>
		/// 
		/// </summary>
		public virtual string Identifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto StatusReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto Intent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual List<ReferenceListItemValueDto> Category { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto Priority { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool DoNotPerform { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool ReportedBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReportedReferenceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReportedReferenceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual List<ReferenceListItemValueDto> MedicationCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual EntityWithDisplayNameDto<Guid?> MedicationReference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual EntityWithDisplayNameDto<Guid?> Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual EntityWithDisplayNameDto<Guid?> Encounter { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string SupportingInformationOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string SupportingInformationOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? AuthoredOn { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RequesterOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RequesterOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto PerformerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RecordedOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string RecordedOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual List<ReferenceListItemValueDto> ReasonCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReasonReferenceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReasonReferenceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string BasedOnOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string BasedOnOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string GroupIdentifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto CourseOfTherapyType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string InsuranceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string InsuranceOwnerType { get; set; }
		///// <summary>
		///// 
		///// </summary>
		//public virtual Dosage DosageInstruction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? InitialFillQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual TimeSpan? InitialFillDuration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual TimeSpan? DispenseInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ValidityPeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ValidityPeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ushort? NumberOfRepeatsAllowed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual TimeSpan? ExpectedSupplyDuration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool AllowBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto AllowCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ReferenceListItemValueDto Reason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual EntityWithDisplayNameDto<Guid?> PriorPrescription { get; set; }
		///// <summary>
		///// 
		///// </summary>
		////public virtual DectedIssue DectedIssue { get; set; }
		///// <summary>
		///// 
		///// </summary>
		//public virtual EntityWithDisplayNameDto<Guid?> EventHistory { get; set; }
	}
}
