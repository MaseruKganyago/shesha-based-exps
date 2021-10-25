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
	[Entity(TypeShortAlias = "HealthCommon.Core.Slot")]
	public class Slot: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "SlotServiceCategories")]
		public virtual RefListServiceCategories ServiceCategory { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ServiceTypes")]
		public virtual RefListServiceTypes ServiceType { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "PracticeSettingCodeValueSets")]
		public virtual RefListPracticeSettingCodeValueSets Speciality { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListAppointmentReasonCodes AppointmentType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Schedule Schedule { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListSlotStatuses Status { get; set; }

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
		public virtual bool Overbooked { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Comment { get; set; }
	}
}
