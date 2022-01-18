﻿using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Wards.Dto
{
    [AutoMap(new[] { typeof(HisWard) })]
    public class HisWardInput : WardInput
    {
        public ReferenceListItemValueDto MidnightCensusApprovalModel { get; set; }
    }
}