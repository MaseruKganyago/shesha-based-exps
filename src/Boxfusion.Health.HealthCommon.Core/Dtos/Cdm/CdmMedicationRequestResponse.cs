using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(CdmMedicationRequest))]
	public class CdmMedicationRequestResponse : MedicationRequestResponse
    {
		/// <summary>
		/// 
		/// </summary>
		public string MedicationCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Dosage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Route { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Frequency { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Duration { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Repeat { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Instruction { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AdditionalInstruction { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string EScriptPath { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Guid FileId { get; set; }
	}
}
