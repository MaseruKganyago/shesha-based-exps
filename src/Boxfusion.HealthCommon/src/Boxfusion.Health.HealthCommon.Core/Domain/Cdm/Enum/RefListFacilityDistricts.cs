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
    
    public enum RefListFacilityDistricts : long
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("Sedibeng District")]
		sedibengDistrict = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("City of Ekurhuleni")]
		cityOfEkurhuleni = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("City of Tshwane")]
		cityOfTshwane = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("City of Johannesburg")]
		cityOfJohannesburg = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("West Rand District")]
		westRandDistrict = 5
	}
}
