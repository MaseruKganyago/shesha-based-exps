using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "Epm.UnitOfMeasure")]
	public class UnitOfMeasure: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string DisplayFormatString { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string EditComponent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string DisplayComponent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string UnitPrefix { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string UnitSuffix { get; set; }
	}
}
