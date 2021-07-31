using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Dosage")]
	public class Dosage: FullAuditedEntity<Guid>
	{
		public virtual int? Sequence { get; set; }
		public virtual string Text { get; set; }
		[ReferenceList("Fhir", "SNOMEDCTAdditionalDosageInstructions")]
		public virtual int? AdditionalInstruction { get; set; }
		public virtual string ParentInstruction { get; set; }
		[MultiValueReferenceList("Cmd", "TimesOfDay")]
		public virtual int? TimingEvent { get; set; }
		public virtual TimeSpan? TimingRepeatBoundsDuration { get; set; }
		public virtual decimal TimingRepeatBoundsRangeLow { get; set; }
		public virtual decimal TimingRepeatBoundsRangeHigh { get; set; }
		public virtual DateTime? TimingRepeatBoundsPeriodStart { get; set; }
		public virtual DateTime? TimingRepeatBoundsPeriodEnd { get; set; }
		public virtual ushort? TimingRepeatCount { get; set; }
		public virtual ushort? TimingRepeatCountMax { get; set; }
		public virtual decimal TimingRepeatDuration { get; set; }
		public virtual decimal TimingRepeatDurationMax { get; set; }
		[ReferenceList("Fhir", "UnitsOfTimes")]
		public virtual int? TimingRepeatDurationUnit { get; set; }
		public virtual ushort? TimingRepeatFrequency { get; set; }
		public virtual ushort? TimingRepeatFrequencyMax { get; set; }
		public virtual decimal TimingRepeatPeriod { get; set; }
		public virtual decimal TimingRepeatPeriodMax { get; set; }
		[ReferenceList("Fhir", "UnitsOfTimes")]
		public virtual int? TimingRepeatPeriodUnit { get; set; }
		[MultiValueReferenceList("Fhir", "DaysOfWeek")]
		public virtual int? TimingRepeatDayOfWeek { get; set; }
		[MultiValueReferenceList("Cmd", "TimesOfDay")]
		public virtual int? TimingRepeatTimeOfDay { get; set; }
		[ReferenceList("Fhir", "EventTimings")]
		public virtual int? TimingRepeatWhen { get; set; }
		public virtual ushort? TimingRepeatOffSet { get; set; }
		[ReferenceList("Fhir", "TimingAbbreviations")]
		public virtual int? TimingCode { get; set; }
		public virtual string AsNeeded { get; set; }
		public virtual bool AsNeededBoolean { get; set; }
		[ReferenceList("Fhir", "ConditionProblemDiagnosisCodes")]
		public virtual int? AsNeededCodeableConcept { get; set; }
		[ReferenceList("Fhir", "BodySites")]
		public virtual int? Site { get; set; }
		[ReferenceList("Fhir", "SNOMEDCTRouteCodes")]
		public virtual int? Route { get; set; }
		[ReferenceList("Fhir", "SNOMEDCTAdministrationMethodCodes")]
		public virtual int? Method { get; set; }
		[ReferenceList("Fhir", "DoseAndRateTypes")]
		public virtual int? DosageAndRateType { get; set; }
		public virtual decimal DosageAndRateDoseRangeStart { get; set; }
		public virtual decimal DosageAndRateDoseRangeEnd { get; set; }
		public virtual decimal DosageAndRateDoseQuantity { get; set; }
		public virtual decimal DosageAndRateRateRationNumerator { get; set; }
		public virtual decimal DosageAndRateRateRatioDenominator { get; set; }
		public virtual decimal DosageAndRateRangeStart { get; set; }
		public virtual decimal DosageAndRateRangeEnd { get; set; }
		public virtual decimal DosageAndRateRateQuantity { get; set; }
		public virtual decimal MaxDosePerPeriodStart { get; set; }
		public virtual decimal MaxDosePerPeriodEnd { get; set; }
		public virtual decimal MaxDosePerAdministration { get; set; }
		public virtual decimal MaxDosePerLifetime { get; set; }

	}
}
