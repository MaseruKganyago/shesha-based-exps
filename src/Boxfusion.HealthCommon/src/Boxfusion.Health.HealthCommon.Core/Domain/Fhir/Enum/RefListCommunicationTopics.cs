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
	[ReferenceList("Fhir", "CommunicationTopics")]
	public enum RefListCommunicationTopics: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Prescription Refiil Request")]
		prescriptionRefillRequest = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Progress Update")]
		progressUpdate = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Report Labs")]
		reportLabs = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Appointment Reminder")]
		appointmentReminder = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Phone Consult")]
		phoneConsult = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Summary Report")]
		summaryReport = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Chat Consult")]
		chatConsult = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Video Consult")]
		videoConsult = 8,
	}
}
