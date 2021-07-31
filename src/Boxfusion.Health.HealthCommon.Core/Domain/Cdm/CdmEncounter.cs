using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmEncounter")]
    public class CdmEncounter : Encounter
    {
        public virtual bool FollowupIsFeelingBetter { get; set; }

        [ReferenceList("Cdm", "FollowupNotificationStatuses")]
        public virtual int? FollowupNotificationStatus { get; set; }

        public virtual bool FollowupRequired { get; set; }

        public virtual Appointment FollowupAppointment { get; set; }

        public virtual string FollowupSuggestion { get; set; }

        public virtual ChwWorkOrder CHWWorkOrder { get; set; }

        public virtual Decimal? Rating { get; set; }

        public virtual string RatingComment { get; set; }

        public virtual DateTime? RatingTime { get; set; }
    }
}
