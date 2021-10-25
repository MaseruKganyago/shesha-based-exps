using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public interface IPatientCrudHelper<T> where T: CdmPatient
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<T>> GetAllAsync();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<T> GetByIdAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="entity"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		Task<T> CreateOrUpdateAsync(CdmPatientInput input, T entity, Func<Task> action = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);
	}
}
