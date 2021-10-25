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
    [AutoMap(typeof(Contact))]
    public class ContactResponse : EntityDto<Guid>
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
        public ReferenceListItemValueDto Relationship { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OfficeNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FaxNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid> Organisation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }
    }
}
