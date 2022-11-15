
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221114163000)]
	public class M20221114163000 : Migration
	{
		public override void Up()
		{
			Rename.Column("RAGCalculationMethod").OnTable("Epm_Components").To("RAGCalculationMethodLkp");
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
