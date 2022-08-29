using Abp.Application.Services.Dto;
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
	public class RegisterPatientDto: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto RegistrationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto PatientType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto IdentificationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string IdNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Surname { get; set; }

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
		public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Gender { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Race { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto HomeLangauge { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto MaritalStatus { get; set; }

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
		public ReferenceListItemValueDto Province { get; set; }

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
		public ReferenceListItemValueDto Nationality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Religion { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string NumberOfDependents { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto EducationLevel { get; set; }

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
