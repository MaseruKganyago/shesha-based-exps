using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221108115200)]
	public class M20221108115200 : Migration
	{
		public override void Up()
		{
			//Boxfusion.Smartgov.Epm.Domain.Indicator
			Create.Table("Epm_Indicators")
				.WithIdAsGuid()
				.WithFullAuditColumns();

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
				.WithForeignKeyColumn("IndicatorId", "Epm_Indicators").Nullable()
				.WithForeignKeyColumn("AreaId", "Core_Areas").Nullable()
				.WithForeignKeyColumn("ProjectId", "Entpr_Projects").Nullable()
				.WithForeignKeyColumn("IndicatorDefinitionId", "Epm_IndicatorDefinitions").Nullable()
				.WithColumn("IndicatorProgressReportingMethodLkp").AsInt64().Nullable()
				.WithColumn("FinalIndicatorTarget").AsInt64().Nullable()
				.WithColumn("LatestIndicatorValue").AsInt64().Nullable()
				.WithColumn("FinalExpenditureTarget").AsDecimal().Nullable()
				.WithColumn("LatestExpenditureActual").AsDecimal().Nullable()
				.WithColumn("DataSource").AsString(2000).Nullable()
				.WithColumn("DataLimitations").AsString(2000).Nullable();
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
