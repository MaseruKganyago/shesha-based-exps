using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs
{
    public interface IHomeAffairsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<HomeAffairsPersonDto> RequestDetailsAsync(string iDNumber);
    }
}
