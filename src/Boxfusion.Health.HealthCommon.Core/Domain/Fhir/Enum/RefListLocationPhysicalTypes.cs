using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "LocationPhysicalTypes")]
	public enum RefListLocationPhysicalTypes : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Site")]
		si = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Building")]
		bu = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Asap")]
		asap = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Stat")]
		stat = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Wing")]
		wi = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Ward")]
		wa = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Level")]
		lvl = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Corridor")]
		co = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("Room")]
		ro = 9,
		/// <summary>
		/// 
		/// </summary>
		[Description("Bed")]
		bd = 10,
		/// <summary>
		/// 
		/// </summary>
		[Description("House")]
		ho = 11,
		/// <summary>
		/// 
		/// </summary>
		[Description("Cabinet")]
		ca = 12,
		/// <summary>
		/// 
		/// </summary>
		[Description("Road")]
		rd = 13,
		/// <summary>
		/// 
		/// </summary>
		[Description("Area")]
		area = 14,
		/// <summary>
		/// 
		/// </summary>
		[Description("Jurisdiction")]
		jdn = 15,

		/// <summary>
		/// 
		/// </summary>
		[Description("Virtual")]
		vrt = 16
	}
}
