using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ParticipationModes")]
	public enum RefListParticipationModes: int
	{
		[Description("Electronic Data (ELECTRONIC)")]
		electronicData = 1,
		[Description("Physical Presence (PHYSICAL)")]
		physicalPresence = 2,
		[Description("Remote Presence (REMOTE)")]
		remotePresence = 4,
		[Description("Verbal (VERBAL)")]
		verbal = 8,
		[Description("Dictated (DICTATE)")]
		dictated = 16,
		[Description("Face to Face (FACE)")]
		faceToFace = 32,
		[Description("Telephone (PHONE)")]
		telephone = 64,
		[Description("Video Conferencing (VIDEOCONF)")]
		videoConferencing = 128,
		[Description("Written (WRITTEN)")]
		written = 256,
		[Description("TeleFax (FAXWRIT)")]
		teleFax = 1024,
		[Description("Hand Written (HANDWRIT)")]
		handWritten = 2048,
		[Description("Mail (MAILWRIT)")]
		mail = 4096 ,
		[Description("Online Written (ONLINEWRIT)")]
		onlineWritten = 8192,
		[Description("Email (EMAILWRIT)")]
		email = 16384,
		[Description("Type Written (TYPEWRIT)")]
		typeWritten = 32768
	}
}
