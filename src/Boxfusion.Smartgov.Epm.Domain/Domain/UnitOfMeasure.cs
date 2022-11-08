using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
	[Entity(TypeShortAlias = "Epm.UnitOfMeasure")]
	public class UnitOfMeasure: FullAuditedEntity<Guid>
	{
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual string DisplayFormatString { get; set; }
		public virtual string EditComponent { get; set; }
		public virtual string DisplayComponent { get; set; }
		public virtual string UnitPrefix { get; set; }
		public virtual string UnitSuffix { get; set; }
	}
}
