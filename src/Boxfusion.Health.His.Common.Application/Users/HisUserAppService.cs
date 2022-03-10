using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Users
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/Bookings/[controller]")]
    public class HisUserAppService : CdmAppServiceBase
    {
        private readonly PatientManager _userManager;

        /// <summary>
        /// 
        /// </summary>
        public HisUserAppService(PatientManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetFacilitiesAssociatedToUser")]
        public async Task<List<DynamicDto<HisHealthFacility, Guid>>> GetFacilitiesAssociatedToUserAsync()
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            var facilities = await _userManager.GetFacilitiesAssociatedToUserAsync(person.Id);

            var list = new List<DynamicDto<HisHealthFacility, Guid>>();

            foreach (var facility in facilities)
            {
                var facilityDto = await this.MapToDynamicDtoAsync<HisHealthFacility, Guid>(facility);
                list.Add(facilityDto);
            }

            return list;
        }

    }
}
