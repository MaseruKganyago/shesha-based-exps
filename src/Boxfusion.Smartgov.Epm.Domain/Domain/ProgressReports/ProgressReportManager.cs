using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.PerformanceReports;
using Shesha.Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.ProgressReports
{

	/// <summary>
	/// 
	/// </summary>
	public class ProgressReportManager: DomainService
	{
		private readonly IRepository<ProgressReport, Guid> _repository;
		private readonly IRepository<Period, Guid> _periodRepository;
		private readonly IRepository<PerformanceReport, Guid> _performanceReport;
		private readonly IUnitOfWorkManager _uowManager;

		/// <summary>
		/// 
		/// </summary>
		public ProgressReportManager(IRepository<ProgressReport, Guid> repository,
			IRepository<Period, Guid> periodRepository,
			IRepository<PerformanceReport, Guid> performanceReport,
			IUnitOfWorkManager uowManager)
		{
			_repository = repository;
			_periodRepository = periodRepository;
			_performanceReport = performanceReport;
			_uowManager = uowManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IRepository<ProgressReport, Guid> repository()
		{
			return _repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="performanceReport"></param>
		/// <returns></returns>
		public async Task GeneratePerformanceReportProgressReportsAsync(PerformanceReport performanceReport)
		{
			var performanceReportPeriod = performanceReport.PeriodCovered;
			var performanceReportTemplate = performanceReport.Template;

			var coveredPeriods = await _periodRepository.GetAllListAsync(a => a.PeriodStart.Value.Date >= performanceReportPeriod.PeriodStart.Value.Date
													&& a.PeriodEnd.Value.Date <= performanceReportPeriod.PeriodEnd.Value.Date);

			var validReportingCyclePeriods = coveredPeriods
					.Where(a => a.PeriodType == performanceReportTemplate.ProgressReportingCycle).ToList();

			foreach (var period in validReportingCyclePeriods)
			{
				await CreateProgressReportAsync(performanceReport, period);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="performanceReport"></param>
		/// <param name="period"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task CreateProgressReportAsync(PerformanceReport performanceReport, Period period,
			RefListProgressReportingStatus status = RefListProgressReportingStatus.Draft)
		{
			try
			{
				using (var uow = _uowManager.Begin())
				{
					var localReport = await _performanceReport.GetAsync(performanceReport.Id);
					var newProgressReport = new ProgressReport()
					{
						PerformanceReport = localReport,
						PeriodCovered = period,
						Status = (long?)status
					};
					await _repository.InsertAsync(newProgressReport);
					await uow.CompleteAsync();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
