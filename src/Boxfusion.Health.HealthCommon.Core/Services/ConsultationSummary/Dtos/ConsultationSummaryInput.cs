using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsultationSummaryInput
	{
		/// <summary>
		/// 
		/// </summary>
		[Required]
		public Guid PractitionerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Required]
		public Guid PatientId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Required]
		public Guid EncounterId { get; set; }
	}
}
