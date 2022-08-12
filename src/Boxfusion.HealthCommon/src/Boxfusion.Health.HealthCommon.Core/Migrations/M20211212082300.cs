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
    [Migration(20211212082300)]
    public class M20211212082300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Persons").AddColumn("Fhir_PersalNumber").AsString().Nullable();
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

