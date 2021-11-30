using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Helpers
{
    public interface ISeparationService
    {
        Task<AdmissionResponse> CreateAsync(SeparationInput input, PersonFhirBase currentLoggedInPerson);
    }
}