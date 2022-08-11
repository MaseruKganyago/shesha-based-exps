using Abp.Application.Services.Dto;
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
    [AutoMap(typeof(CdmSchedule))]
    public class CdmScheduleInput : ScheduleInput
    {
        /// <summary>
        /// Name of the schedule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// In cases where a practioner is able to pick appointments from multiple Queues/Schedules, specifies the order in which they should be given preference. Highest is best.
        /// </summary>
        public int? PrioritisationIndex { get; set; }

        /// <summary>
        /// Specifies what type of schedule is followed: Walk-In or Appointment.
        /// </summary>
        public ReferenceListItemValueDto SchedulingModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LimitToCurrentFacility { get; set; }
    }
}
