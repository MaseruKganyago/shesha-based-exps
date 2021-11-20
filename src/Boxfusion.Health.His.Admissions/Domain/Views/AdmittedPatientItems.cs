using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.His.Domain.Domain.Enums;
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
		public virtual RefListIdentificationTypes IdentificationType { get; set; }

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
		public virtual string WardAdmissionNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>5
		public virtual string FirstName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string LastName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListAdmissionTypes AdmissionType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListWardSpecialities Speciality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListProvinces Province { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListClassifications Classification { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListCountries Nationality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListOtherCategories OtherCategory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListAdmissionStatuses AdmissionStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual int Days { get; set; }
	}
}
