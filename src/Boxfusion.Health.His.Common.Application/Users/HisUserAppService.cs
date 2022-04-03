﻿using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Authorization;
using Boxfusion.Health.His.Common.Practitioners;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.Authorization.Users;
using Shesha.DynamicEntities.Dtos;
using Shesha.Users;
using Shesha.Users.Dto;
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
    [ApiVersion("1")]
    //[Route("api/v{version:apiVersion}/Bookings/[controller]")]
    public class HisUserAppService : CdmAppServiceBase // DynamicCrudAppService<HisPractitioner, DynamicDto<HisPractitioner, Guid>, Guid>, ITransientDependency
    {
        private readonly HisPractitionerManager _practitionerManager;
        private readonly IRepository<HisPractitioner, Guid> _practitionerRepo;

        /// <summary>
        /// 
        /// </summary>
        public HisUserAppService(IRepository<HisPractitioner, Guid> repository, HisPractitionerManager practitionerManager) //:  base(repository)
        {
            _practitionerRepo = repository;
            _practitionerManager = practitionerManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v{version:apiVersion}/Common/[controller]/GetFacilitiesAssociatedToUser")]
        [Route("api/v{version:apiVersion}/Bookings/HisUser/GetFacilitiesAssociatedToUser")]// For legacy
        public async Task<List<DynamicDto<HisHealthFacility, Guid>>> GetFacilitiesAssociatedToUserAsync()
        {
            
            var person = await this.GetCurrentPersonAsync();

            var facilities = await _practitionerManager.GetFacilitiesAssociatedToUserAsync(person.Id);

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