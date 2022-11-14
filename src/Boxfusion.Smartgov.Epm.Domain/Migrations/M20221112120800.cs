
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221112120800)]
	public class M20221112120800 : Migration
	{
		public override void Up()
		{
			Delete.Column("RAGThresholds").FromTable("Epm_Components");

			Alter.Table("Epm_Components")
				.AddColumn("RAGGreenThreshold").AsInt64().Nullable()
				.AddColumn("RAGRedThershold").AsInt64().Nullable();
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
