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
		[Description("In-Progress ChargeItem")]
		inProgress = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Finalized ChargeItem")]
		finalized = 2
	}
}
