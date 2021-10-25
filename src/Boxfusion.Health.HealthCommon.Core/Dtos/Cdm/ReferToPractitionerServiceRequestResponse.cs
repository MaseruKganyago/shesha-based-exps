using System;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(ReferToPractitionerServiceRequest))]
    public class ReferToPractitionerServiceRequestResponse: ReferralServiceRequestResponse
    {
       
    }
}
