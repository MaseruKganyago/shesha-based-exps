using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Cdm", "IdentityVerificationStatus")]
	public enum RefListIdentityVerificationStatus : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Electronic Document")]
		electronicDocument = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Verification Against Register")]
		verificationAgainstRegister = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Name Challenge")]
		nameChallenge = 3
	}
}
