using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Smartgov.Epm.Domain;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.PerformanceReports;
using Boxfusion.Smartgov.Epm.Domain.ProgressReports;
using Shesha.Enterprise;
using Shesha.Enterprise.Domain;
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
			CreateTestData_PerformanceReportTemplateAndPerformanceReport("UnitTest: AOP", RefListPeriodType.Month, "UnitTest: AOP FY2022/23");
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
				await createProgressPeriods("UnitTest: APP", "UnitTest: APP FY2022/23");

				//Act
				using var uow = _uowManager.Begin();
				perfReport = await GetTestData_PerformanceReport("UnitTest: APP FY2022/23");
				await _progressReportManager.GeneratePerformanceReportProgressReportsAsync(perfReport);
				await uow.CompleteAsync();

				//Assert check if 4 ProgressReports where creates for the PerformanceReport
				progressReports = await _progressReportManager.repository()
									.GetAllListAsync(a => a.PerformanceReport.Id == performanceReport.Id);
				progressReports.Count.ShouldBe(4); //Check for 4 since APP is Quaterly.
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

		[Fact]
		public async Task Should_create_ProgressReports_for_all_Months_of_the_year_for_PerformanceReport()
		{
			PerformanceReport perfReport = null;
			List<ProgressReport> progressReports = null;
			try
			{
				//Prepare test data
				var performanceReport = await GetTestData_PerformanceReport("UnitTest: AOP FY2022/23");
				await createProgressPeriods("UnitTest: AOP", "UnitTest: AOP FY2022/23");

				//Act
				using var uow = _uowManager.Begin();
				perfReport = await GetTestData_PerformanceReport("UnitTest: AOP FY2022/23");
				await _progressReportManager.GeneratePerformanceReportProgressReportsAsync(perfReport);
				await uow.CompleteAsync();

				//Assert check if 12 ProgressReports where created for the PerformanceReport
				progressReports = await _progressReportManager.repository()
									.GetAllListAsync(a => a.PerformanceReport.Id == performanceReport.Id);
				progressReports.Count.ShouldBe(12); //Checks for 12 since AOP is monthly
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

		private async Task createProgressPeriods(string templateName, string performanceReportName)
		{
			using (var uow = _uowManager.Begin())
			{
				var template = await GetTestData_PerformanceReportTemplate(templateName);
				var periodCovered = await GetTestData_Period(performanceReportName);

				int count = 0;
				if (template.ProgressReportingCycle == (long?)RefListPeriodType.Quarter)
				{
					while (count < 4)
					{
						var periodStart = periodCovered.PeriodStart.Value.AddMonths(count * 3);
						await _periodRepository.InsertAsync(new Period()
						{
							Name = $"Q{count + 1}",
							PeriodType = (long?)RefListPeriodType.Quarter,
							PeriodStart = periodStart,
							PeriodEnd = periodStart.AddMonths(3),
						});

						count++;
					}
				}
				else if (template.ProgressReportingCycle == (long?)RefListPeriodType.Month)
				{
					while (count < 12)
					{
						var periodStart = periodCovered.PeriodStart.Value.AddMonths(count);
						await _periodRepository.InsertAsync(new Period()
						{
							Name = $"Month {count +1}",
							PeriodType = (long?)RefListPeriodType.Month,
							PeriodStart = periodStart,
							PeriodEnd = count%2 == 0 ? periodStart.AddDays(29) : periodStart.AddDays(30),
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
