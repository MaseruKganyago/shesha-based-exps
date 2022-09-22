using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Common.Patients;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.PatientRegistrations
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(HisPatient))]
	public class RegisterPatientDto: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public int? Title { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PassportNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? RegistrationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? PatientType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? IdentificationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string IdentityNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? Gender { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? Race { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? HomeLangauge { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? MaritalStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string CellNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AlternativeNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? Province { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ResidentialAddress { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SecondResidentialAddress { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? Nationality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? Religion { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? NumberOfDependents { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public long? EducationLevel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsEmployed { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Occupation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string NameOfEmployer { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string WorkTelephoneNo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string WorkAddress { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SecondWorkAddress { get; set; }
	}
}
