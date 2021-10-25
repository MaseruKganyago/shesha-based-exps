using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(Participant))]
	public class ParticipantInput: EntityDto<Guid>
	{
        /// <summary>
        /// 
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Individual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Required { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Status { get; set; }
    }
}
