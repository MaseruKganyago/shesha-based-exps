using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using JetBrains.Annotations;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(LocationJurisdiction))] 
    public class LocationJurisdictionInput
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Comments { get; set; }
        public List<ReferenceListItemValueDto> Flags { get; set; }
        public EntityWithDisplayNameDto<Guid?> ParentArea { get; set; }
        public ReferenceListItemValueDto AreaType { get; set; }
        public List<PolygonDto> Coordinates { get; set; }
        [CanBeNull] public PolygonDto Center { get; set; }
    }
}
