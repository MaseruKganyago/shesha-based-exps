using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Smartgov.Epm.Domain.Components;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.ComponentProgressReports
{
    /// <summary>
    /// 
    /// </summary>
    public class ComponentProgressReportManager: DomainService
	{
		private readonly IRepository<ComponentProgressReport, Guid> _repository;
		private readonly IRepository<ProgressReport, Guid> _progressReport;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="progressReport"></param>
		public ComponentProgressReportManager(IRepository<ComponentProgressReport, Guid> repository,
			IRepository<ProgressReport, Guid> progressReport)
		{
			_repository = repository;
			_progressReport = progressReport;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IRepository<ComponentProgressReport, Guid> repository()
		{
			return _repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="component"></param>
		/// <returns></returns>
		public async Task GenerateComponentProgressReportsForComponentAsync(Component component)
		{
			var performanceReport = component.PerformanceReport;

			var progressReports = await _progressReport.GetAllListAsync(a => a.PerformanceReport.Id == performanceReport.Id);

			var tasks = new List<Task>();
			progressReports.ForEach(a => tasks.Add(CreateComponentProgressReportAsync(a, component)));

			await Task.WhenAll(tasks);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="progressReport"></param>
		/// <param name="component"></param>
		/// <returns></returns>
		public async Task<ComponentProgressReport> CreateComponentProgressReportAsync(ProgressReport progressReport, Component component)
		{
			return await _repository.InsertAsync(new ComponentProgressReport()
			{
				ProgressReport = progressReport,
				Component = component,
				ProgressReportStatus = (long?)RefListNodeProgressReportStatus.NotDue,
				IndicatorTarget = component.FinalIndicatorTarget,
				ExpenditureTarget = component.FinalExpenditureTarget
			});
		}
	}
}
