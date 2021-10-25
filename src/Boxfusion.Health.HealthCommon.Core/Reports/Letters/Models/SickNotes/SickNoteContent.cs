using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using Shesha.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.TeleHealth.Reports.Letters.Models
{
	/// <summary>
	/// 
	/// </summary>
	public class SickNoteContent
	{
		/// <summary>
		/// 
		/// </summary>
		public SickNoteContent()
		{
		}
		/// <summary>
		/// 
		/// </summary>
		public string HealthcareProviderName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string HPCSANo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string DispensaryNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string PatientFullName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ConsultationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SickLeaveStartDateText { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SickLeaveEndDateText { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string AdditionalComments { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ConsultationType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Location { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string DueTo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string PleaseExcusePatientFrom { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime SickLeaveStartDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime SickLeaveEndDate { get; set; }
	}
}
