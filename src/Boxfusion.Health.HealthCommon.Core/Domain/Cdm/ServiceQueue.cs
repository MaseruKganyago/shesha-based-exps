using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.ServiceQueue")]
    public class ServiceQueue : Schedule
    {
        public virtual RefListServiceQueueStatuses Status { get; set; }
        public virtual RefListServiceType ServiceType { get; set; }
        public virtual RefListTeleHealthSkills Skill { get; set; }
        public virtual RefListFacility Facility { get; set; }
        public virtual Location Fhir_ServiceQueueCapacities { get; set; }
        public virtual int SlotSizeInMinutes { get; set; }
    }
}
