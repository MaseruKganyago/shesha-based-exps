using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.IcdTenCodes
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	public class IcdTenCodeAppServices: CdmAppServiceBase, IIcdTenCodeAppService
	{
		private readonly IRepository<IcdTenCode, Guid> _repository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		public IcdTenCodeAppServices(IRepository<IcdTenCode, Guid> repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="term"></param>
		/// <returns></returns>
		[HttpGet, Route("Autocomplete")]
		public async Task<List<EntityWithDisplayNameDto<Guid>>> IcdTenCodesAutoCompleteList(string term)
		{
			term = (term ?? "").ToLower();

			var codes = await _repository.GetAll()
							 .Where(a => (a.ICDTenCode ?? "").ToLower().Contains(term) || (a.WHOFullDesc ?? "").ToLower().Contains(term))
							 .Take(10).ToListAsync();

			var output = new List<EntityWithDisplayNameDto<Guid>>();
			codes.ForEach(code =>
			{
				output.Add(new EntityWithDisplayNameDto<Guid>(code.Id, $"{code.ICDTenCode} {code.WHOFullDesc}"));
			});

			return output;
		}
	}
}
