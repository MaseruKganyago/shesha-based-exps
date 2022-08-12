using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	[ReferenceList("Cmd", "TimesOfDay")]
	public enum RefListTimesOfDay: long
	{
		[Description("00:00")]
		t0000 = 1,
		[Description("01:00")]
		t0100 = 2,
		[Description("02:00")]
		t0200 = 4,
		[Description("03:00")]
		t0300 = 8,
		[Description("04:00")]
		t0400 = 16,
		[Description("05:00")]
		t0500 = 32,
		[Description("006:00")]
		t0600 = 64,
		[Description("07:00")]
		t0700 = 128,
		[Description("08:00")]
		t0800 = 256,
		[Description("09:00")]
		t0900 = 512,
		[Description("10:00")]
		t1000 = 1024,
		[Description("11:00")]
		t1100 = 2048,
		[Description("12:00")]
		t1200 = 4096,
		[Description("13:00")]
		t1300 = 8192,
		[Description("14:00")]
		t1400 = 32768,
		[Description("15:00")]
		t1500 = 65536,
		[Description("16:00")]
		t1600 = 131072,
		[Description("17:00")]
		t1700 = 262144,
		[Description("18:00")]
		t1800 = 524288,
		[Description("19:00")]
		t1900 = 1048576,
		[Description("20:00")]
		t2000 = 2097152,
		[Description("21:00")]
		t2100 = 4194340,
		[Description("22:00")]
		t2200 = 8388608,
		[Description("23:00")]
		t2300 = 16777216
	}
}
