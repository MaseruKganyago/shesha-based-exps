using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// /
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmEncounter")]
    [Table("Fhir_Encounters")]
    public class ConsultationEncounter : Encounter
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual bool FollowupIsFeelingBetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListFollowupNotificationStatuses FollowupNotificationStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool FollowupRequired { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Appointment FollowupAppointment { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual string FollowupSuggestion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ChwWorkOrder CHWWorkOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal? Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string RatingComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? RatingTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public virtual RefListFollowUpDay FollowUpDay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? FollowUpDate { get; set; }
    }
}
