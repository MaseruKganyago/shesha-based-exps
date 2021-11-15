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
	[ReferenceList("HisAdmis", "Province")]
	public enum RefListProvince: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Eastern Cape")]
		easternCape = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Free State")]
		freeState = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Gauteng")]
		gauteng = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Kwa-Zulu Natal")]
		kwaZuluNatal = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Limpopo")]
		limpopo = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Mpumalanga")]
		mpumalang = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("North West")]
		northWest = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("Northern Cape")]
		northernCape = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Western Cape")]
		westernCape = 9,

		/// <summary>
		/// 
		/// </summary>
		[Description("Not Provided")]
		notProvided = 10,

		/// <summary>
		/// 
		/// </summary>
		[Description("Other")]
		other = 11
	}
}
