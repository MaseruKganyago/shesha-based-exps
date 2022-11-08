using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "IndicatorAuditOutcome")]
	public enum RefListIndicatorAuditOutcome: long
	{
		Satisfied = 1,
		Inconclusive = 2,
		NotSatisfied = 3,
		NotNecessaryToAudit = 4,
	}
}
