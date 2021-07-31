using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "CommunicationTopics")]
	public enum RefListCommunicationTopics: int
	{
		[Description("Prescription Refiil Request")]
		prescriptionRefillRequest = 1,
		[Description("Progress Update")]
		progressUpdate = 2,
		[Description("Report Labs")]
		reportLabs = 3,
		[Description("Appointment Reminder")]
		appointmentReminder = 4,
		[Description("Phone Consult")]
		phoneConsult = 5,
		[Description("Summary Report")]
		summaryReport = 6
	}
}
