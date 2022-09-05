using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.His.Common.Procedures;
using Boxfusion.Health.His.Common.Products;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.HisConsumable")]
	public class Consumable: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual HisProcedure Procedure { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal Quantity { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual ConsumableProduct ConsumableProduct { get; set; }
	}
}
