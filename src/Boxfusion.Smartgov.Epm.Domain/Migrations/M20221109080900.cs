using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221109080900)]
	public class M20221109080900: Migration
	{
		public override void Up()
		{
			//Boxfusion.Smartgov.Epm.Domain.ComponentType
			Create.Table("Epm_ComponentTypes")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString().Nullable()
				.WithColumn("Caption").AsString().Nullable()
				.WithColumn("Description").AsString().Nullable()
				.WithColumn("Icon").AsString().Nullable()
				.WithColumn("AdminTreeCreateForm").AsString().Nullable()
				.WithColumn("AdminTreeDetailsForm").AsString().Nullable()
				.WithColumn("AdminTreeUpdateForm").AsString().Nullable()
				.WithColumn("ViewerTreeDetailsForm").AsString().Nullable()
				.WithColumn("IsIndicator").AsBoolean()
				.WithColumn("ShowInAdminTree").AsBoolean()
				.WithColumn("ShowInViewerTree").AsBoolean()
				.WithColumn("ProgressReportingRequired").AsBoolean()
				.WithColumn("ProgressDetailsSubForm").AsString()
				.WithColumn("ProgressQA1Required").AsBoolean()
				.WithColumn("ProgressQA2Required").AsBoolean()
				.WithColumn("ProgressAuditRequired").AsBoolean();

			Create.Table("Epm_PerformanceReportTemplates")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString(200).Nullable()
				.WithColumn("ShortName").AsString(20).Nullable()
				.WithColumn("Description").AsString(2000).Nullable()
				.WithColumn("PeriodTypeCoveredLkp").AsInt64().Nullable()
				.WithColumn("ProgressReportingCycleLkp").AsInt64().Nullable()
				.WithColumn("AdminPermission").AsString(100).Nullable()
				.WithColumn("ProcessManagerPermission").AsString(100).Nullable();

			////Here will include refList migration
			//this.Shesha().ReferenceListUpdate("Shesha.Enterprise", "PeriodType")
			//	.AddItem(1, "Financial Year", 1, "Financial Year")
			//	.AddItem(2, "MTSF", 2, "Medium Term Strategic Framework - 5 Year reporting cycle dictated centrally by National Treasury that specifies the reporting cycles for the Strategic Plans")
			//	.AddItem(3, "Month", 3, "Month")
			//	.AddItem(4, "Financial Quarter", 4, "Financial Quarter");

			Create.Table("Epm_PerformanceReports")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString().Nullable()
				.WithColumn("ShortName").AsString().Nullable()
				.WithColumn("StatusLkp").AsInt64().Nullable()
				.WithForeignKeyColumn("TemplateId", "Epm_PerformanceReports").Nullable()
				.WithForeignKeyColumn("PeriodCoveredId", "entpr_Periods").Nullable();

			//Boxfusion.Smartgov.Epm.Domain.UnitOfMeasure
			Create.Table("Epm_UnitOfMeasures")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString().Nullable()
				.WithColumn("Description").AsString().Nullable()
				.WithColumn("DisplayFormatString").AsString().Nullable()
				.WithColumn("EditComponent").AsString().Nullable()
				.WithColumn("DisplayComponent").AsString().Nullable()
				.WithColumn("UnitPrefix").AsString().Nullable()
				.WithColumn("UnitSuffix").AsString().Nullable();

			//Boxfusion.Smartgov.Epm.Domain.IndicatorDefinition
			Create.Table("Epm_IndicatorDefinitions")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString().Nullable()
				.WithColumn("StatusLkp").AsInt64().Nullable()
				.WithColumn("Description").AsString().Nullable()
				.WithForeignKeyColumn("UnitOfMeasureId", "Epm_UnitOfMeasures").Nullable()
				.WithColumn("Purpose").AsString(2000).Nullable()
				.WithColumn("WhatMeasured").AsString(2000).Nullable()
				.WithColumn("MethodOfCalculation").AsString(2000).Nullable()
				.WithColumn("CalculationTypeLkp").AsInt64().Nullable();

			//Boxfusion.Smartgov.Epm.Domain.Component
			Create.Table("Epm_Components")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("PerformanceReportId", "Epm_PerformanceReports").Nullable()
				.WithColumn("Name").AsString(200).Nullable()
				.WithColumn("RefNo").AsString(20).Nullable()
				.WithColumn("Description").AsString(2000).Nullable()
				.WithColumn("OrderIndex").AsInt64().Nullable()
				.WithForeignKeyColumn("ComponentTypeId", "Epm_ComponentTypes").Nullable()
				.WithForeignKeyColumn("ParentId", "Epm_Components").Nullable()
				.WithForeignKeyColumn("PredecessorId", "Epm_Components").Nullable()
				.WithForeignKeyColumn("ResponsibleOrganisationId", "Core_Organisations").Nullable()
				.WithForeignKeyColumn("ResponsibleReportingId", "Core_Persons").Nullable()
				.WithForeignKeyColumn("ResponsibleQA1Id", "Core_Persons").Nullable()
				.WithForeignKeyColumn("ResponsibleQA2Id", "Core_Persons").Nullable()
				.WithColumn("LatestPerfIndex").AsInt64().Nullable()
				.WithColumn("PerfIndexCalculationMethodLkp").AsInt64().Nullable()
				.WithColumn("PerfIndexWeight").AsInt16().Nullable()
				.WithColumn("LatestRAGValueLkp").AsInt64().Nullable()
				.WithColumn("RAGCalculationMethod").AsInt64().Nullable()
				.WithColumn("RAGThresholds").AsStringMax().Nullable()
				.WithForeignKeyColumn("AreaId", "Core_Areas").Nullable()
				.WithForeignKeyColumn("IndicatorDefinitionId", "Epm_IndicatorDefinitions").Nullable()
				.WithColumn("IndicatorProgressReportingMethodLkp").AsInt64().Nullable()
				.WithColumn("FinalIndicatorTarget").AsInt64().Nullable()
				.WithColumn("LatestIndicatorValue").AsInt64().Nullable()
				.WithColumn("FinalExpenditureTarget").AsDecimal().Nullable()
				.WithColumn("LatestExpenditureActual").AsDecimal().Nullable()
				.WithColumn("DataSource").AsString(2000).Nullable()
				.WithColumn("DataLimitations").AsString(2000).Nullable();

			//Boxfusion.Smartgov.Epm.Domain.ProgressReport
			Create.Table("Epm_ProgressReports")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("PerformanceReportId", "Epm_PerformanceReports").Nullable()
				.WithForeignKeyColumn("PeriodCoveredId", "entpr_Periods").Nullable()
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

			Create.Table("Epm_PerformanceReportAllowedComponentTypes")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("PerformanceReportTemplateId", "Epm_PerformanceReportTemplates").Nullable()
				.WithForeignKeyColumn("ComponentTypeId", "Epm_ComponentTypes").Nullable()
				.WithColumn("CanBeRoot").AsBoolean();

			Create.Table("Epm_AllowableChildComponentTypes")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("ParentComponentTypeId", "Epm_ComponentTypes").Nullable()
				.WithForeignKeyColumn("ChildComponentTypeId", "Epm_ComponentTypes").Nullable()
				.WithColumn("CanBeRoot").AsBoolean();
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
