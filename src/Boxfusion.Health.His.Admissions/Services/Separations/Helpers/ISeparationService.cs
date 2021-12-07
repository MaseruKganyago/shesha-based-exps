using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Helpers
{
    public interface ISeparationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        Task<AdmissionResponse> CreateAsync(SeparationInput input, PersonFhirBase currentLoggedInPerson);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admissionId"></param>
        /// <param name="currentLoggedInPerson"></param>
        /// <returns></returns>
        Task<AdmissionResponse> UndoSeparation(Guid admissionId, PersonFhirBase currentLoggedInPerson);
    }
}