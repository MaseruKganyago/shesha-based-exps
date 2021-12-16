﻿using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Wards.Dto
{
    [AutoMap(new[] { typeof(HisHospital) })]
    public class HisHospitalResponse : HospitalResponse
    {
    }
}