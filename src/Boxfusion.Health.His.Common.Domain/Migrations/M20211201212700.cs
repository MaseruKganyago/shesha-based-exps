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
    [Migration(20211201212700)]
    public class M20211201212700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Facilities").AddColumn("His_MidnightCensusApprovalModelLkp").AsInt64().Nullable();
            Delete.Column("His_MidnightCensusApprovalModelLkp").FromTable("Fhir_Encounters");
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
