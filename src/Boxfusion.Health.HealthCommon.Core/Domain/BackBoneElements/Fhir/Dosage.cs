using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Dosage")]
	public class Dosage: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual int? Sequence { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Text { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListSNOMEDCTAdditionalDosageInstructions? AdditionalInstruction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ParentInstruction { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Cmd", "TimesOfDay")]
		public virtual RefListTimesOfDay TimingEvent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual TimeSpan? TimingRepeatBoundsDuration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal TimingRepeatBoundsRangeLow { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal TimingRepeatBoundsRangeHigh { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? TimingRepeatBoundsPeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? TimingRepeatBoundsPeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ushort? TimingRepeatCount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ushort? TimingRepeatCountMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal TimingRepeatDuration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal TimingRepeatDurationMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListUnitsOfTimes? TimingRepeatDurationUnit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ushort? TimingRepeatFrequency { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual ushort? TimingRepeatFrequencyMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal TimingRepeatPeriod { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal TimingRepeatPeriodMax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListUnitsOfTimes? TimingRepeatPeriodUnit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "DaysOfWeek")]
		public virtual RefListDaysOfWeek TimingRepeatDayOfWeek { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Cmd", "TimesOfDay")]
		public virtual RefListTimesOfDay TimingRepeatTimeOfDay { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListEventTimings? TimingRepeatWhen { get; set; }
		public virtual ushort? TimingRepeatOffSet { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListTimingAbbreviations? TimingCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string AsNeeded { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool AsNeededBoolean { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListConditionProblemDiagnosisCodes? AsNeededCodeableConcept { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListBodySite? Site { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListSNOMEDCTRouteCodes? Route { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListSNOMEDCTAdministrationMethodCodes? Method { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListDoseAndRateTypes? DosageAndRateType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateDoseRangeStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateDoseRangeEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateDoseQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateRateRationNumerator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateRateRatioDenominator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateRangeStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateRangeEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal DosageAndRateRateQuantity { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal MaxDosePerPeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal MaxDosePerPeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal MaxDosePerAdministration { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal MaxDosePerLifetime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerType { get; set; }
	}
}
