using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "EncounterParticipantTypes")]
	public enum RefListEncounterParticipantTypes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Admitter")]
		admitter = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Attender")]
		attender = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Callback Contact")]
		callbackContact = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Consultant")]
		consultant = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Discharger")]
		discharger = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Escort")]
		escort = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("Referrer")]
		referrer = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("Secondary Performer")]
		secondaryPerformer = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Primary Performer")]
		primaryPerformer = 9,

		/// <summary>
		/// 
		/// </summary>
		[Description("Participation")]
		participation = 10,

		/// <summary>
		/// 
		/// </summary>
		[Description("Translator")]
		translator = 11,

		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency")]
		emergency = 12
	}
}
