using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.PerformanceReports
{
	/// <summary>
	/// 
	/// </summary>
	public class PerformanceReportEntityChangingEventHandler: IEventHandler<EntityChangingEventData<PerformanceReport>>, ITransientDependency
	{
		private readonly ProgressReportManager _progressReportManager;
		private readonly IRepository<PerformanceReport, Guid> _performanceReportRepository;

		/// <summary>
		/// 
		/// </summary>
		public PerformanceReportEntityChangingEventHandler(ProgressReportManager progressReportManager,
			IRepository<PerformanceReport, Guid> performanceReportRepository)
		{
			_progressReportManager = progressReportManager;
			_performanceReportRepository = performanceReportRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		/// <exception cref="NotImplementedException"></exception>
		public async void  HandleEvent(EntityChangingEventData<PerformanceReport> eventData)
		{
			var entity = eventData.Entity;

			var reports = await _performanceReportRepository.GetAllListAsync(a => a.Id == entity.Id);
			if (reports.Any())
				return;

			await _progressReportManager.GeneratePerformanceReportProgressReportsAsync(entity);
		}
	}
}
