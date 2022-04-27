using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Boxfusion.Health.His.Common.Patients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Patient
{
    public class FacilityPatientModAppService : HisAppServiceBase
    {
        private readonly IPatientCrudHelper<FacilityPatient, FacilityPatient> _patientCrudHelper;


        [HttpGet, Route("/api/services/Common/FacilityPatient/GetByIdentityNumber/{identityNumber}")]
        public async Task<FacilityPatient> GetPatientByIdNumberAsync(string identityNumber)
        {
           var patient =  await _patientCrudHelper.GetByIdNumberAsync(identityNumber);

            if (patient == null)
                return null;
            return patient;
        }
    }
}
