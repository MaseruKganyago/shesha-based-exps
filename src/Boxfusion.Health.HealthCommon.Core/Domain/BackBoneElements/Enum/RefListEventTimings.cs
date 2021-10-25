using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	[ReferenceList("Fhir", "EventTimings")]
	 public enum RefListEventTimings: long
	{
		[Description("Second")]
		second = 1,
		[Description("Minute")]
		minute = 2,
		[Description("Hour")]
		hour = 3,
		[Description("Day")]
		day = 4,
		[Description("Week")]
		week = 5,
		[Description("Month")]
		month = 6,
		[Description("Year")]
		year = 7
	}
}
