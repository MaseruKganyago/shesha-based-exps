using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Locations.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ILocationCrudHelper<T, TResult> where T: FhirLocation where TResult: class
    {
			/// <summary>
			/// 
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <returns></returns>
			Task<List<TResult>> GetAllAsync();

			/// <summary>
			/// 
			/// </summary>
			/// <typeparam name="T"></typeparam>
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
			Task<TResult> UpdateAsync(LocationInput input, Func<Task> action = null);

			/// <summary>
			/// 
			/// </summary>
			/// <param name="id"></param>
			/// <returns></returns>
			Task DeleteAsync(Guid id);
		}
}
