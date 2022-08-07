using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Admissions
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.FlatWardAdmission")]
	[Table("vw_His_FlattenedWardAdmissions")]
	[ImMutable]
	public class FlattenedWardAdmission
	{
		/// <summary>
		/// WardAdmissionId
		/// </summary>
		public virtual Guid Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid WardId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid HospitalId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string WardAdmissionNumber { get; set; }

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
		public virtual DateTime DateOfBirth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime AdmissionDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime SeparationDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "AdmissionStatuses")]
		public virtual long? Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual int? NumOfDaysAdmitted { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "AdmissionTypes")]
		public virtual long? AdmissionType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Shesha.Core", "Gender")]
		public virtual long? Gender { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "IdentificationTypes")]
		public virtual long? IdentificationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string IdentityNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string HospitalAdmissionNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "Classifications")]
		public virtual long? Classification { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "Provinces")]
		public virtual long? PatientProvince { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Cdm", "Countries")]
		public virtual long? Nationality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "OtherCategories")]
		public virtual long? OtherCategory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "WardSpecialities")]
		public virtual long? Speciality { get; set; }
	}
}
