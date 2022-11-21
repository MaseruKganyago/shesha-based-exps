
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	/// <summary>
	/// 
	/// </summary>
	[Migration(20221121171400)]
	public class M20221121171400 : Migration
	{
		/// <summary>
		/// 
		/// </summary>
		public override void Up()
		{
			Rename.Column("AuditCompleteDate").OnTable("Epm_ComponentProgressReports").To("AuditCompletedDate");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
