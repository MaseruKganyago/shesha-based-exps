using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	[ReferenceList("Epm", "RefListIndexCalculationMethod")]
	public enum RefListIndexCalculationMethod: long
	{
		[Description("The index is calculated directly from the Indicator. Thi only applies if the node itself is a KPI.")]
		Indicator = 1,

		[Description("Will average the index value of all the current node's child nodes.")]
		AverageOfChildren = 2,

		[Description("Will apply a weighted average of the index value of all the current node's child nodes.")]
		WeightedChildren = 3,

		[Description("Allows execution of custom logic in real-time to recalculate the Index value.")]
		CustomCalculation = 4,

		[Description("Index value will be recalculated as a back-ground job on a periodic basis.")]
		BackgroundCalculation = 5,
	}
}
