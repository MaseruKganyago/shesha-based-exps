using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Admissions.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.Admissions.AdmissionsPatient")]
	public class AdmissionsPatient: CdmPatient
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string HospitalisationPatientNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListProvince Province { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListClassification Classification { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListOtherCategories OtherCategories { get; set; }
	}
}
