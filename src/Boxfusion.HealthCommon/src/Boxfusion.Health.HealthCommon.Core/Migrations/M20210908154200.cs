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
    [Migration(20210908154200)]
    public class M20210908154200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Dosages")
                 .AddColumn("OwnerId").AsString()
                 .AddColumn("OwnerType").AsString();
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

