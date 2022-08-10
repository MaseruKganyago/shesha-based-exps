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
	[ReferenceList("Fhir", "DocumentRelationshipTypes")]
	public enum RefListDocumentRelationshipTypes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Replaces")]
		replaces = 1,
		
		/// <summary>
		/// 
		/// </summary>
		[Description("Transforms")]
		transforms = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Signs")]
		signs = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Appends")]
		appends = 4
	}
}
