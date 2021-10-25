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
	[ReferenceList("Fhir", "ServiceRequestProcedureReasons")]
	public enum RefListServiceRequestProcedureReasons: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Ward laboratory procedure, screening (procedure)")]
		LaboratoryProcedure = 1,
	}
}
