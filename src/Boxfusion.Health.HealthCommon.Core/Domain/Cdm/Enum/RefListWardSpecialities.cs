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
    [ReferenceList("Fhir", "WardSpecialities")]
    public enum RefListWardSpecialities : long
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("Gynaecology")]
		gynaecology = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Maternity")]
		maternity = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Medicine")]
		medicine = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Orthopaedic")]
		orthopaedic = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Paediatric")]
		paediatric = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Psychiatry")]
		psychiatry = 6
	}
}
