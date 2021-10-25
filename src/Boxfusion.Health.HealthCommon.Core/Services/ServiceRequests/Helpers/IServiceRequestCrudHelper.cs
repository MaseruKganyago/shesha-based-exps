using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers
{
    /// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="TResult"></typeparam>
    public interface IServiceRequestCrudHelper<T, TResult>  where T : CdmServiceRequest where TResult: class
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
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<TResult>> GetByPatientAsync(Guid patientId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		Task<List<TResult>> GetByPratitionerAsync(Guid practitionerId);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <param name="entity"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		Task<TResult> CreateAsync(CdmServiceRequestInput input, T entity, Func<Task> action = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="entity"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		Task<TResult> UpdateAsync(CdmServiceRequestInput input, T entity, Func<Task> action = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);
	}
}
