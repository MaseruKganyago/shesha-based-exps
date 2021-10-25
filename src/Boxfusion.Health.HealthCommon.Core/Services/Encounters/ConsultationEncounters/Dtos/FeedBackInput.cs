using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.AutoMapper.Dto;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(ConsultationEncounter))]
    public class FeedBackInput
    {
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RatingComment { get; set; }
    }
}
