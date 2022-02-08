using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Administration.Services.Hospitals.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(new[] { typeof(HisHospital) })]
    public class HisHospitalResponse : HospitalResponse
    {
    }
}
