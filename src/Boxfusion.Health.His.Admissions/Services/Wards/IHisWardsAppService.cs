using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    public interface  IHisWardsAppService : IApplicationService
    {
        Task<List<WardResponse>> GetAssignedWards();
    }
}
