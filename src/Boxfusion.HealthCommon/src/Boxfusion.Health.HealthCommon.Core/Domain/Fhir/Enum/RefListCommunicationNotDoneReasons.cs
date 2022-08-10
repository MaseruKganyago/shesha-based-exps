using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "CommunicationNotDoneReasons")]
	public enum RefListCommunicationNotDoneReasons: long
	{
		[Description("Unknown")]
		unknown = 1,
		[Description("System Error")]
		systemError = 2,
		[Description("Invalid Phone Number")]
		invalidPhoneNumber = 3,
		[Description("Recipient Unavailable")]
		recipientUnavailable = 4,
		[Description("Family Objection")]
		familyObjection = 5,
		[Description("Patient Objection")]
		patientObjection = 6
	}
}
