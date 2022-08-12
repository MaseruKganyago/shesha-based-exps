using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Medication")]
	public class Medication: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[EntityDisplayName]
		public virtual string Identifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationCodes? Code { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationStatuses? Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation Manufacture { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListMedicationFormCodes? Form { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal AmountNumerator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual decimal AmountDenominator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string BatchLotNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? BatchExpirationDate { get; set; }
	}
}
