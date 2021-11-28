using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards
{
    [AbpAuthorize]
    //[ApiVersion("1")]
    //[Route("api/v{version:apiVersion}/HisAdmis/[controller]")]
    public class HisWardsAppService : SheshaAppServiceBase, IHisWardsAppService
    {
        public HisWardsAppService()
        {

        }

        public async Task<List<WardResponse>> GetAssignedWards() 
        {
            var currentPerson = await GetCurrentPersonAsync();
            var appointmentService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<WardRoleAppointedPerson, Guid>>();
            var wards = await appointmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Ward).ToListAsync();

            return ObjectMapper.Map<List<WardResponse>>(wards);
        }
    }
}
