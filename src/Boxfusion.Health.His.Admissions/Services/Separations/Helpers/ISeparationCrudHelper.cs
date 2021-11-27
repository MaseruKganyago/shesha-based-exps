using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Helpers
{
    public interface ISeparationCrudHelper
    {
        Task<SeparationResponse> CreateAsync(SeparationInput input, PersonFhirBase currentLoggedInPerson);
    }
}