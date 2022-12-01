using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using NHibernate.Linq;
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
		private readonly IUnitOfWorkManager _uowManager;

		/// <summary>
		/// 
		/// </summary>
		public PerformanceReportEntityChangedEventHandler(ProgressReportManager progressReportManager,
			IRepository<PerformanceReport, Guid> performanceReportRepository,
			IUnitOfWorkManager uowManager)
		{
			_progressReportManager = progressReportManager;
			_performanceReportRepository = performanceReportRepository;
			_uowManager = uowManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		/// <exception cref="NotImplementedException"></exception>
		public async void  HandleEvent(EntityChangedEventData<PerformanceReport> eventData)
		{
			using (var uow = _uowManager.Begin())
			{
				var entity = eventData.Entity;

				var progressReports = await _progressReportManager.repository().GetAllListAsync(a => a.PerformanceReport.Id == entity.Id);
				if (progressReports.Any())
					return;

				await _progressReportManager.GeneratePerformanceReportProgressReportsAsync(entity);

				await uow.CompleteAsync();
			}
		}
	}
}
