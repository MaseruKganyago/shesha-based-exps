using Abp.Authorization;
using Abp.UI;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.His.Admissions.Domain.Domain.Coverages;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Domain.Domain.Coverages;
using Boxfusion.Health.His.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Coverages
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class CoverageAppService : HisAppServiceBase
    {
        private readonly CoverageManager _coverageManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coverageManager"></param>
        public CoverageAppService(CoverageManager coverageManager)
        {
            _coverageManager = coverageManager;
        }

        /// <summary>
        /// Get coverage Id and it's flattened bank account
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("GetSelfCashCoverage")]
        [AbpAuthorize()]
        public async Task<DynamicDto<FlattenedCoverage, Guid>> GetSelfCashCoverage(Guid patientId)
        {
            var selfCashCoverage = await _coverageManager.GetSelfCashCoverage(patientId);

            return (selfCashCoverage is null) ? null 
                : await this.MapToDynamicDtoAsync<FlattenedCoverage, Guid>(selfCashCoverage);
        }
    }
}
