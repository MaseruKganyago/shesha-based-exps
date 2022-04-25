using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Patient
{
    public class CdmPatientModAppService : HisAppServiceBase
    {
        private readonly IPatientCrudHelper<CdmPatient, CdmPatient> _patientCrudHelper;


        [HttpGet, Route("/api/services/Cdm/CdmPatient/GetByIdentityNumber/{identityNumber}")]
        public async Task<CdmPatient> GetCdmPatientByIdNumberAsync(string identityNumber)
        {
            return await _patientCrudHelper.GetByIdNumberAsync(identityNumber);
        }
    }
}
