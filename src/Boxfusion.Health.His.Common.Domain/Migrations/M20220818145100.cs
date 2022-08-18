using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
	/// <summary>
	/// 
	/// </summary>
	[Migration(20220818145100)]
	public class M20220818145100 : Migration
	{
		/// <summary>
		/// 
		/// </summary>
		public override void Up()
		{
			Alter.Table("Fhir_Encounters")
				.AddForeignKeyColumn("His_BillingClassificationId", "His_BillingClassifications");
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Down()
		{
			throw new NotImplementedException();
		}

	}
}
