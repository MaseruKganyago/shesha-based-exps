using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Cdm.Schedules
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.ScheduleRoleAppointment")]
    [Table("Core_ShaRoleAppointments")]
    public class ScheduleRoleAppointment: ShaRoleAppointedPerson
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        public virtual CdmSchedule Schedule  { get; set; }

        [NotMapped]
        public virtual string? FacilityName
        {
            get
            {
                return Schedule?.HealthFacilityOwner?.Name;
            }
        }


    }
}
