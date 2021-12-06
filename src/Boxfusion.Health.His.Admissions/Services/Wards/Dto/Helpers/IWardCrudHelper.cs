using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards.Dto.Helpers
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
		Task<List<WardResponse>> GetAllAsync();

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
		Task<List<WardResponse>> GetWardByHospitalAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<WardResponse> GetAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<WardResponse> CreateAsync(WardInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<WardResponse> UpdateAsync(WardInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(Guid id);
	}
}
