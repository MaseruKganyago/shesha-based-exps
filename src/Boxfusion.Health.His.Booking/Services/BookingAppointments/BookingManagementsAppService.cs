using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class BookingManagementsAppService : CdmAppServiceBase, IBookingManagementsAppService
    {

    }
}
