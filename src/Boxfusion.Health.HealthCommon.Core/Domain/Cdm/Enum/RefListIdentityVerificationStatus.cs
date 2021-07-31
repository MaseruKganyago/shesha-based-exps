using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Cdm", "IdentityVerificationStatus")]
	public enum RefListIdentityVerificationStatus : int
	{
		[Description("Electronic Document")]
		electronicDocument = 1,

		[Description("Verification Against Register")]
		verificationAgainstRegister = 2,

		[Description("Name Challenge")]
		nameChallenge = 3
	}
}
