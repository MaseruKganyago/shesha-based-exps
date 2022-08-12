using Abp.Authorization;
using Boxfusion.Health.His.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Patients
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisBookings/[controller]")]
    [Obsolete("Should remove once configuration driven entity pickers are implemented")]
    public class HisFacilityPatientAppService : HisAppServiceBase
    {
    }
}
