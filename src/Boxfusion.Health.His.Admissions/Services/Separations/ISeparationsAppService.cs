using Abp.Application.Services;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations
{
    public interface ISeparationsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AdmissionResponse> CreateAsync(SeparationInput input);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AdmissionResponse> UndoSeparationAsync(Guid id);

    }
}
