using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "RequestIntents")]
	public enum RefListRequestIntents : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Proposal")]
		proposal = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Plan")]
		plan = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Directive")]
		directive = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Order")]
		order = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Original Order")]
		originalOder = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Reflex Order")]
		reflexOrder = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Filler Order")]
		filterOrder = 7,
	}
}
