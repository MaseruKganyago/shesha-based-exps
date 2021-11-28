using Abp.Application.Services;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations
{
    public interface ISeparationsAppService : IApplicationService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SeparationResponse> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<SeparationResponse> CreateAsync(SeparationInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<SeparationResponse> UpdateAsync(SeparationInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

    }
}
