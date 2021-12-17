using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Users.Dto
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(new[] { typeof(HisUser) })]
    public class HisUserResponse : PersonFhirBaseResponse
    {
    }
}
