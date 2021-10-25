using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsultationSummaryResponse
	{
		/// <summary>
		/// 
		/// </summary>
		public string DiagnosisText { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<MedicationTextModel> MedicationTextList { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ChwVisitRequestText { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ReferToFacilityText { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AmbulanceServiceRequestText { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string EscalateToDrText { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SickNoteText { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class MedicationTextModel
	{
		/// <summary>
		/// 
		/// </summary>
		public string MedicationName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Dosage { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class FacilityHolder
	{
		/// <summary>
		/// 
		/// </summary>
		public string FacilityName { get; set; }
	}
}
