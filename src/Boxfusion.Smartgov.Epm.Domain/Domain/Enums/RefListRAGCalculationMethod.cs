using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "RAGCalculationMethod")]
	public enum RefListRAGCalculationMethod: long
	{
		DefaultThresholds = 1,
		CustomThresholds = 2,

		[Description("Custom logic defined in C# will be invoked to calculate the RAG value")]
		CustomLogic = 3
	}
}
