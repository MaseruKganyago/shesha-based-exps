using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221108093100)]
	public class M20221108093100: Migration
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
				.WithColumn("IsIndicator").AsBoolean().Nullable()
				.WithColumn("ShowInAdminTree").AsBoolean().Nullable()
				.WithColumn("ShowInViewerTree").AsBoolean().Nullable()
				.WithColumn("ProgressReportingRequired").AsBoolean().Nullable()
				.WithColumn("ProgressDetailsSubForm").AsString().Nullable()
				.WithColumn("ProgressQA1Required").AsBoolean().Nullable()
				.WithColumn("ProgressQA2Required").AsBoolean().Nullable()
				.WithColumn("ProgressAuditRequired").AsBoolean().Nullable();
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
