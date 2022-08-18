using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "MedicationAdministrationStatuses")]
	public enum RefListMedicationAdministrationStatuses: long
	{
		[Description("In Progress")]
		inProgress = 1,

		[Description("Not Done")]
		notDone = 2,

		[Description("On Hold")]
		onHold = 3,

		[Description("Completed")]
		completed = 4,

		[Description("Entered in Error")]
		enrteredInError = 5,

		[Description("Stopped")]
		stopped = 6,

		[Description("Unknown")]
		unknown = 7
	}
}
