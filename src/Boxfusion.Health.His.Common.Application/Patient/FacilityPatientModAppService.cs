
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Common.Domain.Domain.Dtos.Patients;
using Boxfusion.Health.His.Common.Domain.Domain.Patients;
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
 
        IRepository<FacilityPatient, Guid> _patientRepository;

        public FacilityPatientModAppService(IRepository<FacilityPatient, Guid> repository) 
        {
            _patientRepository = repository;
        }

        [HttpGet, Route("/api/services/Common/FacilityPatient/GetByIdentityNumber/{identityNumber}")]
        public async Task<FacilityPatientDto> GetPatientByIdNumberAsync(string identityNumber)
        {
            var response = new FacilityPatientDto();

            try
            {
                var patients = await _patientRepository.GetAllListAsync(facilityPatient => facilityPatient.IdentityNumber == identityNumber || facilityPatient.OtherIdentityNumber == identityNumber || facilityPatient.PassportNumber == identityNumber);
      
                if (patients.Count == 0)
                {
                    response.Code = "OK";
                    response.Message = "That ID is unique";
                    return response;
                }
                else
                {
                    var patientNames = "";
                    patients.ForEach(patient => patientNames += patient.FullNameWithTitle + Environment.NewLine);

                    response.Code = "DUPLICATE";
                    response.Message = "That ID already belongs to : " + Environment.NewLine + patientNames;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Code = "ERROR";
                response.Message = ex.Message;
                return response;
            }
          
               
           
        }
    }
}
