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
	public class PerformanceReportEntityChangedEventHandler: IEventHandler<EntityChangedEventData<PerformanceReport>>, ITransientDependency
	{
		private readonly ProgressReportManager _progressReportManager;
		private readonly IRepository<PerformanceReport, Guid> _performanceReportRepository;

		/// <summary>
		/// 
		/// </summary>
		public PerformanceReportEntityChangedEventHandler(ProgressReportManager progressReportManager,
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
		public async void  HandleEvent(EntityChangedEventData<PerformanceReport> eventData)
		{
			var entity = eventData.Entity;

			if ((await _performanceReportRepository.GetAllListAsync(a => a.Id == entity.Id)).Any())
				return;

			await _progressReportManager.GeneratePerformanceReportProgressReportsAsync(entity);
		}
	}
}
