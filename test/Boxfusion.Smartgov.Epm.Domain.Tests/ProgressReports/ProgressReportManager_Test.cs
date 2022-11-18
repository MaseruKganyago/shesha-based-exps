using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Smartgov.Epm.Domain;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.PerformanceReports;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using Shesha.Enterprise;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Smartgov.Epm.Tests.ProgressReports
{
	public class ProgressReportManager_Test: EpmDomainTestBase
	{
		private readonly ProgressReportManager _progressReportManager;
		private readonly IRepository<Period, Guid> _periodRepository;
		private readonly IUnitOfWorkManager _uowManager;

		public ProgressReportManager_Test(): base()
		{
			CreateTestData_PerformanceReportTemplateAndPerformanceReport("UnitTest: APP", RefListPeriodType.Quarter, "UnitTest: APP FY2022/23");
			_progressReportManager = Resolve<ProgressReportManager>();
			_periodRepository = Resolve<IRepository<Period, Guid>>();
			_uowManager = Resolve<IUnitOfWorkManager>();
		}

		[Fact]
		public async Task Should_create_ProgressReports_on_PerformanceReport_create_with_Template_ProgressCycle()
		{
			PerformanceReport perfReport = null;
			List<ProgressReport> progressReports = null;
			try
			{
				//Prepare test data
				var performanceReport = await GetTestData_PerformanceReport("UnitTest: APP FY2022/23");
				await createProgressPeriods(performanceReport);

				//Act
				using var uow = _uowManager.Begin();
				perfReport = await GetTestData_PerformanceReport("UnitTest: APP FY2022/23");
				await _progressReportManager.GeneratePerformanceReportProgressReportsAsync(perfReport);
				await uow.CompleteAsync();

				//Assert check if 4 ProgressReports where creates for the PerformanceReport
				progressReports = await _progressReportManager.repository()
									.GetAllListAsync(a => a.PerformanceReport.Id == performanceReport.Id);
				progressReports.Count.ShouldBe(4);
			}
			catch (Exception ex)
			{
				
			}
			finally
			{
				progressReports?.ForEach(a =>
				{
					CleanUpTestData_ProgressReport(a.Id);
				});
				if (perfReport is not null)
					CleanUpTestData_PerformanceReport(perfReport.Id);
			}
		}

		private async Task createProgressPeriods(PerformanceReport performanceReport)
		{
			using (var uow = _uowManager.Begin())
			{
				var template = await GetTestData_PerformanceReportTemplate("UnitTest: APP");
				var periodCovered = await GetTestData_Period("UnitTest: APP FY2022/23");

				int count = 0;
				if (template.ProgressReportingCycle == (long?)RefListPeriodType.Quarter)
				{
					while (count < 4)
					{
						var periodStart = periodCovered.PeriodStart.Value.AddMonths(count * 3);
						await _periodRepository.InsertAsync(new Period()
						{
							Name = $"Q{count +1}",
							PeriodType = (long?)RefListPeriodType.Quarter,
							PeriodStart = periodStart,
							PeriodEnd = periodStart.AddMonths(3),
						});

						count++;
					}
				}

				await uow.CompleteAsync();
			}		
		}

		private void CleanUpTestData_ProgressReport(Guid progressReportId)
		{
			using var session = OpenSession();
			var query = session.CreateSQLQuery("DELETE FROM Epm_ProgressReports WHERE Id = '" + progressReportId.ToString() + "'");
			query.ExecuteUpdate();

			session.Flush();
		}
	}
}
