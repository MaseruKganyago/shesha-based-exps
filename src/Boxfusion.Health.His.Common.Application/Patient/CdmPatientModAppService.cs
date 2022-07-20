using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Patients;
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
        private readonly IRepository<CdmPatient, Guid> _patientRepo;

		public CdmPatientModAppService(IRepository<CdmPatient, Guid> patientRepo)
		{
			_patientRepo = patientRepo;
		}

		[HttpGet, Route("/api/services/Cdm/CdmPatient/GetByIdentityNumber/{identityNumber}")]
        public async Task<CdmPatient> GetCdmPatientByIdNumberAsync(string identityNumber)
        {
            return await _patientRepo.FirstOrDefaultAsync(a => a.IdentityNumber == identityNumber);
        }
    }
}
