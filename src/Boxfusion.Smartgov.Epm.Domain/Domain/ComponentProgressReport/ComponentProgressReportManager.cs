using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.ComponentProgressReport
{
	/// <summary>
	/// 
	/// </summary>
	public class ComponentProgressReportManager: DomainService
	{
		private readonly IRepository<ComponentProgressReport, Guid> _repository;
		private readonly IRepository<Component, Guid> _componentRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="componentRepository"></param>
		public ComponentProgressReportManager(IRepository<ComponentProgressReport, Guid> repository, IRepository<Component, Guid> componentRepository)
		{
			_repository = repository;
			_componentRepository = componentRepository;
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
		/// <param name="progressReport"></param>
		/// <returns></returns>
		public async Task GenerateComponentProgressReportsForProgressReportAsync(ProgressReport progressReport)
		{
			var performanceReport = progressReport.PerformanceReport;

			var components = await _componentRepository.GetAllListAsync(a => a.PerformanceReport.Id == performanceReport.Id &&
							 a.ComponentType.Icon == EpmDomainConsts.IconLevel5);

			var tasks = new List<Task>();
			components.ForEach(a => tasks.Add(CreateComponentProgressReportAsync(progressReport, a)));

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
				ProgressReportStatus = RefListNodeProgressReportStatus.AwaitingLevelOneQA
			});
		}
	}
}
