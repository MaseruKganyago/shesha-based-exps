using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.Enums
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Epm", "RAGValues")]
	public enum RefListRAGValues: long
	{
		Green = 1,
		Amber = 2,
		Red = 3,
		NotApplicable = 99
	}
}
