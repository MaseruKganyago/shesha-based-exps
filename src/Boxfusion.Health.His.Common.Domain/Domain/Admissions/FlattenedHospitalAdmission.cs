using Abp.Domain.Entities;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Admissions
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.FlattenedHospitalAdmission")]
	[Table("vw_His_FlattenedHospitalAdmissions")]
	[ImMutable]
	public class FlattenedHospitalAdmission: Entity<Guid>
	{
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
		public virtual DateTime? DateOfBirth { get; set; }

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
		public virtual string MobileNumber1 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Cdm", "Countries")]
		public virtual long? Nationality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Shesha.Core", "Gender")]
		public virtual long? Gender { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string HospitalAdmissionNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid PatientId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? StartDateTime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? EndDateTime { get; set; }

		/// <summary>
		///
		/// </summary>
		[ReferenceList("Fhir", "EncounterClasses")]
		public virtual long? Class { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "Classifications")]
		public virtual long? Classification { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid WardAdmissionId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string WardName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "AdmissionStatuses")]
		public virtual long? WardAdmissionStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? LOS { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PatientMasterIndexNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string BillingClassificationName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid BillingClassificationId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Single? NumberOfAccounts { get; set; }
	}
}
