using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(Contact))]
    public class ContactInput : EntityDto<Guid>
    {
        public string OwnerId { get; set; }
        public string OwnerType { get; set; }

        public ReferenceListItemValueDto Relationship { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string OfficeNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }

        public ReferenceListItemValueDto Gender { get; set; }
        public EntityWithDisplayNameDto<Guid?> Organisation { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
    }
}
