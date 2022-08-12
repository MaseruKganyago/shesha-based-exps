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
	[ReferenceList("Fhir", "DocumentReferenceStatuses")]
	public enum RefListDocumentReferenceStatuses: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Current")]
		current = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Superseded")]
		superseded = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Entered in Error")]
		enteredInError = 3
	}
}
