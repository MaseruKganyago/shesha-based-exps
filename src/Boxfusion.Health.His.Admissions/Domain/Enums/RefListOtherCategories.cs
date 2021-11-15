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
	[ReferenceList("HisAdmis", "OtherCategories")]
	public enum RefListOtherCategories: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Maternal Deaths")]
		materalDeaths = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Prisoner")]
		prisoner = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("MVA")]
		mva = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Gunshot")]
		gunshot = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Burn Wounds")]
		burnWounds = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Stab Wounds")]
		stabWounds = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("Day Patients")]
		dayPatients = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("Lodgers")]
		lodgers = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Cancellations")]
		cancellations = 9
	}
}
