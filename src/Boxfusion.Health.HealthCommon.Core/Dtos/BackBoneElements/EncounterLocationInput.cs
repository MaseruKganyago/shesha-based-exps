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
	[AutoMap(typeof(EncounterLocation))]
	public class EncounterLocationInput: EntityDto<Guid>
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
        public EntityWithDisplayNameDto<Guid?> Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto PhysicalType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDateTime { get; set; }
    }
}
