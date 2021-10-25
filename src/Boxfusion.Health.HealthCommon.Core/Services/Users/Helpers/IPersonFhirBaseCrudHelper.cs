using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Users.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPersonFhirBaseCrudHelper<T, TResult> where T: PersonFhirBase where TResult: class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<TResult>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        Task<TResult> GetByIdNumberAsync(string identityNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TResult> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<TResult> CreateAsync(PersonFhirBaseInput input, T entity, Func<Task> action = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<TResult> UpdateAsync(PersonFhirBaseInput input, Func<Task> action = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
