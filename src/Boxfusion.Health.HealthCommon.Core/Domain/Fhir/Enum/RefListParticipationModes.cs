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
	[ReferenceList("Fhir", "ParticipationModes")]
	public enum RefListParticipationModes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Electronic Data (ELECTRONIC)")]
		electronicData = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Physical Presence (PHYSICAL)")]
		physicalPresence = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Remote Presence (REMOTE)")]
		remotePresence = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Verbal (VERBAL)")]
		verbal = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("Dictated (DICTATE)")]
		dictated = 16,
		/// <summary>
		/// 
		/// </summary>
		[Description("Face to Face (FACE)")]
		faceToFace = 32,
		/// <summary>
		/// 
		/// </summary>
		[Description("Telephone (PHONE)")]
		telephone = 64,
		/// <summary>
		/// 
		/// </summary>
		[Description("Video Conferencing (VIDEOCONF)")]
		videoConferencing = 128,
		/// <summary>
		/// 
		/// </summary>
		[Description("Written (WRITTEN)")]
		written = 256,
		/// <summary>
		/// 
		/// </summary>
		[Description("TeleFax (FAXWRIT)")]
		teleFax = 1024,
		/// <summary>
		/// 
		/// </summary>
		[Description("Hand Written (HANDWRIT)")]
		handWritten = 2048,
		/// <summary>
		/// 
		/// </summary>
		[Description("Mail (MAILWRIT)")]
		mail = 4096 ,
		/// <summary>
		/// 
		/// </summary>
		[Description("Online Written (ONLINEWRIT)")]
		onlineWritten = 8192,
		/// <summary>
		/// 
		/// </summary>
		[Description("Email (EMAILWRIT)")]
		email = 16384,
		/// <summary>
		/// 
		/// </summary>
		[Description("Type Written (TYPEWRIT)")]
		typeWritten = 32768,
		/// <summary>
		/// 
		/// </summary>
		[Description("Type Chat (REALTIME)")]
		chat = 32769,
		/// <summary>
		/// 
		/// </summary>
		[Description("Type Video (REALTIME)")]
		video = 32740
	}
}
