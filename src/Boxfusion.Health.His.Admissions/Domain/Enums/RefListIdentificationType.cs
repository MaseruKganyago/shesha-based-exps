using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Enums
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("HisAdmis", "IdentificationType")]
	public enum RefListIdentificationType: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("S.A ID")]
		saID = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Passport")]
		passport = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Immigration Documents")]
		immigrationDocuments = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Asylum Documents")]
		asylumDocuments = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Not Provided")]
		notProvided = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Other")]
		other = 6
	}
}
