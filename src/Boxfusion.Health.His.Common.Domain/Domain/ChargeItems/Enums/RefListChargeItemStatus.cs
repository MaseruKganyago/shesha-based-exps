using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("His", "ChargeItemStatus")]
	public enum RefListChargeItemStatus: long
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
