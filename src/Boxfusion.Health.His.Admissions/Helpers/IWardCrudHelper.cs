using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Admissions.Helpers.Dtos;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public interface IWardCrudHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		Task<List<HisWardResponse>> GetAllAsync();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="term"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<List<AutocompleteItemDto>> GetWardByHospitalAutoCompleteAsync(string term, Guid id);

		///// <summary>
		///// 
		///// </summary>
		///// <param name="personId"></param>
		///// <returns></returns>
		//Task<List<AutocompleteItemDto>> GetWardByPersonAutoCompleteAsync(Guid personId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="term"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<List<HisWardResponse>> GetWardByHospitalAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<HisWardResponse> GetAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<HisWardResponse> CreateAsync(HisWardInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<HisWardResponse> UpdateAsync(WardInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardId"></param>
		/// <param name="currentPerson"></param>
		/// <returns></returns>
		Task<bool> IsPersonAssignedToHospital(Guid wardId, Person currentPerson);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardId"></param>
		/// <param name="currentPerson"></param>
		/// <returns></returns>
		Task<bool> IsPersonAssignedToWard(Guid wardId, Person currentPerson);
	}
}
