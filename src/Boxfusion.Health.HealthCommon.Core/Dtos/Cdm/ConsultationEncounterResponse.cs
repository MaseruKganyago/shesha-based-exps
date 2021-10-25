using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
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
    [AutoMap(typeof(ConsultationEncounter))]
    public class ConsultationEncounterResponse : FhirEncounterResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public bool FollowupIsFeelingBetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto FollowupNotificationStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FollowupRequired { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> FollowupAppointment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FollowupSuggestion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> CHWWorkOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RatingComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? RatingTime { get; set; }        
    }
}
