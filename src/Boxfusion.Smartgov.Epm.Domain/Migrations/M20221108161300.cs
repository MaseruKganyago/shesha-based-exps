using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221108161300)]
	public class M20221108161300 : Migration
	{
		public override void Up()
		{
			//Boxfusion.Smartgov.Epm.Domain.ProgressReport
			Create.Table("Epm_ProgressReports")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("PerformanceReportId", "Epm_PerformanceReport").Nullable()
				.WithForeignKeyColumn("PeriodCoveredId", "Entpr_Periods").Nullable()
				.WithColumn("StatusLkp").AsInt64().Nullable();

			//Boxfusion.Smartgov.Epm.Domain.ComponentProgressReport
			Create.Table("Epm_ComponentProgressReports")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("ProgressReportId", "Epm_ProgressReports").Nullable()
				.WithForeignKeyColumn("ComponentId", "Epm_Components").Nullable()
				.WithForeignKeyColumn("Parent", "Epm_ComponentProgressReports").Nullable()
				.WithColumn("SkipReportingThisPeriod").AsBoolean()
				.WithColumn("PerfIndex").AsInt64().Nullable()
				.WithColumn("RAGValueLkp").AsInt64().Nullable()
				.WithColumn("TrendLkp").AsInt64().Nullable()
				.WithColumn("IndicatorTarget").AsInt64().Nullable()
				.WithColumn("IndicatorActual").AsInt64().Nullable()
				.WithColumn("ExpenditureActual").AsDecimal().Nullable()
				.WithColumn("ExpenditureTarget").AsDecimal().Nullable()
				.WithColumn("Achievements").AsString(2000).Nullable()
				.WithColumn("VarianceReason").AsString(2000).Nullable()
				.WithColumn("CorrectiveMeasure").AsString(2000).Nullable()
				.WithColumn("PoeRequired").AsBoolean()
				.WithForeignKeyColumn("PortfolioOfEvidenceId", "Frwk_StoredFiles").Nullable()
				.WithColumn("OtherComments").AsString(2000).Nullable()
				.WithColumn("ProgressReportStatusLkp").AsInt64().Nullable()
				.WithForeignKeyColumn("ReportedById", "Core_Persons").Nullable()
				.WithColumn("ReportedDate").AsDateTime().Nullable()
				.WithForeignKeyColumn("QA1CompletedById", "Core_Persons").Nullable()
				.WithColumn("QA1CompletedDate").AsDateTime().Nullable()
				.WithColumn("QA1Comments").AsString(2000).Nullable()
				.WithForeignKeyColumn("QA2CompletedById", "Core_Persons").Nullable()
				.WithColumn("QA2CompletedDate").AsDateTime().Nullable()
				.WithColumn("QA2Comments").AsString(2000).Nullable()
				.WithColumn("AuditOutComeLkp").AsInt64().Nullable()
				.WithColumn("AuditStatusLkp").AsInt64().Nullable()
				.WithForeignKeyColumn("AuditCompleteById", "Core_Persons").Nullable()
				.WithColumn("AuditCompleteDate").AsDateTime().Nullable()
				.WithColumn("AuditComments").AsString(2000).Nullable();

		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
