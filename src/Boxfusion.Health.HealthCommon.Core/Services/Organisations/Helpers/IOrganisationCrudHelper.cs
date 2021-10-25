using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Organisations.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrganisationCrudHelper<T, TResult> where T : FhirOrganisation where TResult : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<TResult>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TResult> GetAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressInput"></param>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<TResult> CreateAsync(CdmAddressInput addressInput, T entity, Func<Task> action = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<TResult> UpdateAsync(OrganisationInput input, Func<Task> action = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
