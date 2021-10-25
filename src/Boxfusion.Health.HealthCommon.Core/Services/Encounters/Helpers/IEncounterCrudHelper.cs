using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public interface IEncounterCrudHelper<T> where T : Encounter
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		Task<List<T>> GetAllAsync();

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<T> GetByIdAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<T>> GetByPatientAsync(Guid patientId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		Task<List<T>> GetByPratitionerAsync(Guid practitionerId);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <param name="entity"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		Task<T> CreateOrUpdateAsync(FhirEncounterInput input, T entity, Func<Task> action = null);


		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="result"></param>
		/// <returns></returns>
		Task MapEncounterBackboneElements<TResult>(TResult result) where TResult : FhirEncounterResponse;
	}
}
