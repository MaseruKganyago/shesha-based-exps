using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Cdm/[controller]")]
    public class HomeAffairsAppService : HomeAffairsBaseService, IHomeAffairsAppService
    {

        /// <summary>
        /// 
        /// </summary>
        [HttpGet, Route("{iDNumber}/Validate")]
        public async Task<HomeAffairsPersonDto> RequestDetailsAsync(string iDNumber)
        {
            return await DoTaskAsync<HomeAffairsPersonDto>(async () =>
            {
                var person = await ValidateIdentityNumber(iDNumber);
                return person;
            });
        }
    }
}
