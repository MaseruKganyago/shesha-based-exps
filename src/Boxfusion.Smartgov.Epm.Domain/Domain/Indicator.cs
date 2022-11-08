using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
	[Entity(TypeShortAlias = "Pdm.Indicator")]
	public class Indicator: FullAuditedEntity<Guid>
	{
	}
}
