using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(CdmAddress))]
    public class AddressInput 
    {
        public string OwnerId { get; set; }
        public string OwnerType { get; set; }
        public ReferenceListItemValueDto Use { get; set; }
        public ReferenceListItemValueDto Type { get; set; }
        public string FullAddress { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
