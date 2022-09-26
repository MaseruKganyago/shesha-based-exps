﻿using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Beds.BedFees.Enums
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("His", "BedFeeStatus")]
	public enum RefListBedFeeStatus: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Open")]
		open = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Closed")]
		closed = 2
	}
}
