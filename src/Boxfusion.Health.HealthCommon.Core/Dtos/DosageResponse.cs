using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(Dosage))]
	public class DosageResponse : EntityDto<Guid?>
	{
		/// <summary>
		/// 
		/// </summary>
		public int? Sequence { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Text { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto AdditionalInstruction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ParentInstruction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto TimingEvent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public TimeSpan? TimingRepeatBoundsDuration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal TimingRepeatBoundsRangeLow { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal TimingRepeatBoundsRangeHigh { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TimingRepeatBoundsPeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TimingRepeatBoundsPeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ushort? TimingRepeatCount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ushort? TimingRepeatCountMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal TimingRepeatDuration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal TimingRepeatDurationMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto TimingRepeatDurationUnit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ushort? TimingRepeatFrequency { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ushort? TimingRepeatFrequencyMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  decimal TimingRepeatPeriod { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal TimingRepeatPeriodMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto TimingRepeatPeriodUnit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> TimingRepeatDayOfWeek { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> TimingRepeatTimeOfDay { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto TimingRepeatWhen { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ushort? TimingRepeatOffSet { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto TimingCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AsNeeded { get; set; }
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
		public ReferenceListItemValueDto Site { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Route { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Method { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto DosageAndRateType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal DosageAndRateDoseRangeStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal DosageAndRateDoseRangeEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal DosageAndRateDoseQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal DosageAndRateRateRationNumerator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal DosageAndRateRateRatioDenominator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  decimal DosageAndRateRangeStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal DosageAndRateRangeEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal DosageAndRateRateQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal MaxDosePerPeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal MaxDosePerPeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal MaxDosePerAdministration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal MaxDosePerLifetime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string OwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string OwnerType { get; set; }
	}
}
