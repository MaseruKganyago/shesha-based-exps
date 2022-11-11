
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221111150200)]
	public class M20221111150200 : Migration
	{
		public override void Up()
		{
			Alter.Column("ProgressDetailsSubForm").OnTable("Epm_ComponentTypes").AsString().Nullable();
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
