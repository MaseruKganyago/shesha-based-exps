using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220929102300)]
    public class M20220929102300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Column("His_BillingClassificationId").OnTable("entpr_Accounts").AsGuid().Nullable();

			#region Delete BillingClassificationId ForeignKey column
			Delete.ForeignKey("FK_entpr_Accounts_BillingClassificationId_His_BillingClassifications_Id").OnTable("entpr_Accounts");
			Delete.Index("IX_entpr_Accounts_BillingClassificationId").OnTable("entpr_Accounts");
			Delete.Column("BillingClassificationId").FromTable("entpr_Accounts");
			#endregion
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
