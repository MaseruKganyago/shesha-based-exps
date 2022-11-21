using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Smartgov.Epm.Domain.ComponentProgressReport;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using Microsoft.AspNetCore.Mvc;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.ComponentProgressReports
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Epm/[controller]")]
	public class ProgressReportsAppService: EpmAppServiceBase
	{
		private readonly ComponentProgressReportManager _componentProgressReportManager;
		private readonly IRepository<ProgressReport, Guid> _progressReport;

		public ProgressReportsAppService(ComponentProgressReportManager componentProgressReportManager,
			IRepository<ProgressReport, Guid> progressReport)
		{
			_componentProgressReportManager = componentProgressReportManager;
			_progressReport = progressReport;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPut, Route("[action]")]
		public async Task<DynamicDto<ProgressReport, Guid>> PublishProgressReport(Guid id)
		{
			var progressReport = await _progressReport.GetAsync(id);

			await _componentProgressReportManager.GenerateComponentProgressReportsForProgressReportAsync(progressReport);

			progressReport.Status = (long?)RefListProgressReportingStatus.Open;
			var updatedEntity = await _progressReport.UpdateAsync(progressReport);

			return await MapToDynamicDtoAsync<ProgressReport, Guid>(updatedEntity);
		}
	}
}
