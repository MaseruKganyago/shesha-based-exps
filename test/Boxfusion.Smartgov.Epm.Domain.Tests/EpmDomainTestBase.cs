using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Smartgov.Epm.Domain;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Boxfusion.Smartgov.Epm.Domain.PerformanceReports;
using Shesha.Enterprise;
using Shesha.Enterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Tests
{
	public class EpmDomainTestBase: SheshaNhTestBase
	{
		private readonly IRepository<PerformanceReportTemplate, Guid> _performanceReportTemplateRepostory;
		private readonly IRepository<PerformanceReport, Guid> _performanceReport;
		private readonly IRepository<Period, Guid> _periodRepository;
		private readonly IUnitOfWorkManager _uowManager;

		public EpmDomainTestBase()
		{
			_performanceReportTemplateRepostory = Resolve<IRepository<PerformanceReportTemplate, Guid>>();
			_performanceReport = Resolve<IRepository<PerformanceReport, Guid>>();
			_periodRepository = Resolve<IRepository<Period, Guid>>();
			_uowManager = Resolve<IUnitOfWorkManager>();
		}

		protected async void CreateTestData_PerformanceReportTemplateAndPerformanceReport(string name, RefListPeriodType reportingCycle, string performanceReportName)
		{
			LoginAsHost("admin");
			using (var uow = _uowManager.Begin())
			{
				// Checking if test data has previously been added
				var template = _performanceReportTemplateRepostory.FirstOrDefault(e => e.Name == name);
				if (template is null)
				{
					var newTemplate = new PerformanceReportTemplate()
					{
						Name = name,
						PeriodTypeCovered = (long?)RefListPeriodType.FinancialYear,
						ProgressReportingCycle = (long?)reportingCycle
					};
					template = _performanceReportTemplateRepostory.Insert(newTemplate);
				}
				CreateTestData_PerformanceReport(performanceReportName, template);

				await uow.CompleteAsync();
			}
		}

		protected PerformanceReport CreateTestData_PerformanceReport(string name, PerformanceReportTemplate template)
		{
			var period = _periodRepository.FirstOrDefault(e => e.Name == name);
			if (period is null)
			{
				var newPeriod = new Period()
				{
					Name = name,
					PeriodType = (long?)RefListPeriodType.FinancialYear,
					PeriodStart = DateTime.Parse("2022/04/01"),
					PeriodEnd = DateTime.Parse("2023/03/31")
				};
				period = _periodRepository.Insert(newPeriod);
			}

			var report = _performanceReport.FirstOrDefault(e => e.Name == name);
			if (report is null)
			{
				var newReport = new PerformanceReport()
				{
					Name = name,
					Template = template,
					PeriodCovered = period
				};

				report = _performanceReport.Insert(newReport);
			}

			return report;
		}

		protected async Task<PerformanceReport> GetTestData_PerformanceReport(string name)
		{
			return await _performanceReport.FirstOrDefaultAsync(a => a.Name == name);
		}

		protected async Task<PerformanceReportTemplate> GetTestData_PerformanceReportTemplate(string name)
		{
			return await _performanceReportTemplateRepostory.FirstOrDefaultAsync(a => a.Name == name);
		}

		protected async Task<Period> GetTestData_Period(string name)
		{
			return await _periodRepository.FirstOrDefaultAsync(a => a.Name == name);
		}

		protected void CleanUpTestData_PerformanceReportTemplate(Guid templateId)
		{
			using var session = OpenSession();
			var query = session.CreateSQLQuery("DELETE FROM Epm_PerformanceReportTemplates WHERE Id = '" + templateId.ToString() + "'");
			query.ExecuteUpdate();

			session.Flush();
		}

		protected void CleanUpTestData_PerformanceReport(Guid performanceReportId)
		{
			using var session = OpenSession();
			var query = session.CreateSQLQuery("DELETE FROM Epm_PerformanceReports WHERE Id = '" + performanceReportId.ToString() + "'");
			query.ExecuteUpdate();

			session.Flush();
		}

		protected void CleanUpTestData_Period(Guid periodId)
		{
			using var session = OpenSession();
			var query = session.CreateSQLQuery("DELETE FROM entpr_Products WHERE Id = '" + periodId.ToString() + "'");
			query.ExecuteUpdate();

			session.Flush();
		}
	}
}
