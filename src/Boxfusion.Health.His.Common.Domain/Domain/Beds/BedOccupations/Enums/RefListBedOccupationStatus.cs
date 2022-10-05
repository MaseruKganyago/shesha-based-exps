using Shesha.Domain.Attributes;
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
	[ReferenceList("His", "BedOccupationStatus")]
	public enum RefListBedOccupationStatus: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Open")]
		Open = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Closed")]
		Closed = 2
	}
}
