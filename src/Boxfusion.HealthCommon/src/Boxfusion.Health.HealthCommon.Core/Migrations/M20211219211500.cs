using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211219211500)]
    public class M20211219211500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Addresses").AddColumn("Fhir_FullAddress1").AsString(3999).Nullable();
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

