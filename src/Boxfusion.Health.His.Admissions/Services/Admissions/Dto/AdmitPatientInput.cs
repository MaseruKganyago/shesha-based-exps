using Abp.Application.Services.Dto;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
	/// <summary>
	/// 
	/// </summary>
	public class AdmitPatientInput: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto IdentificationType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string IdentityNumber { get; set; }

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
		public DateTime AdmissionDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string HospitalisationPatientNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AdmissionNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto AdmissionType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Specialty { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> Ward { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<EntityWithDisplayNameDto<Guid?>> Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Province { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Classification { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Nationality { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto OtherCategories { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto AdmissionStatus { get; set; }
	}
}
