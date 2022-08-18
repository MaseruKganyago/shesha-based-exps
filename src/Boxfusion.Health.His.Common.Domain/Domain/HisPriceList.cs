using Shesha.Domain.Attributes;
using Shesha.Enterprise.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.HisPriceList")]
	public class HisPriceList: PriceList
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "BillingClassificationType")]
		public virtual long? ClassificationType { get; set; }
	}
}
