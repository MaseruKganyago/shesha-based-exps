using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain;
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
    [AutoMap(typeof(CdmSlot))]
    public class CdmSlotInput : SlotInput
    {
        /// <summary>
        /// The ScheduleAvailability from which the Slot was generated.
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> IsGeneratedFrom { get; set; }

        /// <summary>
        /// Regular, Overflow
        /// </summary>
        public ReferenceListItemValueDto CapacityType { get; set; }

        /// <summary>
        /// The number of Appointments allowed to be booked against this Slot.
        /// </summary>
        public int? Capacity { get; set; }

        /// <summary>
        /// Calculated column: (Capacity - SUM(Active Appointments against this Slot)) The capacity still available.
        /// </summary>
        public int? RemainingCapacity { get; set; }
    }
}
