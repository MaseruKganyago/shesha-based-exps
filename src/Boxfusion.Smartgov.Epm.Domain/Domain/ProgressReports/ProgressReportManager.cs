using Abp.Domain.Repositories;
using Abp.Domain.Services;
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

		/// <summary>
		/// 
		/// </summary>
		public ProgressReportManager(IRepository<ProgressReport, Guid> repository, IRepository<Period, Guid> periodRepository, IRepository<PerformanceReport, Guid> performanceReport)
		{
			_repository = repository;
			_periodRepository = periodRepository;
			_performanceReport = performanceReport;
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

			var tasks = new List<Task>();
			validReportingCyclePeriods.ForEach(a => tasks.Add(CreateProgressReport(performanceReport, a)));
			await Task.WhenAll(tasks);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="performanceReport"></param>
		/// <param name="period"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<ProgressReport> CreateProgressReport(PerformanceReport performanceReport, Period period,
			RefListProgressReportingStatus status = RefListProgressReportingStatus.Draft)
		{
			return await _repository.InsertAsync(new ProgressReport() 
			{
				PerformanceReport = performanceReport,
				PeriodCovered = period,
				Status = status
			});
		}
	}
}
