using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.His.Admissions.Domain.Enums;
using Shesha.Domain.Attributes;
using Shesha.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Views
{
	/// <summary>
	/// 
	/// </summary>
	[ImMutable]
	[Table("vw_HisAdmis_AdmittedPatientItems")]
	public class AdmittedPatientItems: Entity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListIdentificationType IdentificationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string IdentityNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		public virtual DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListGender Gender { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		public virtual DateTime? StartDateTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string HospitalisationPatientNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PreAdmissionIdentifier { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string FirstName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string LastName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListAdmissionType AdmissionType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListWardSpecialities Speciality { get; set; }

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
		public virtual RefListCountries Nationality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListOtherCategories OtherCategories { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListAdmissionStatus AdmissionStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual int Days { get; set; }
	}
}
