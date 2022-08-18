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
    [Migration(20220818224400)]
    public class M20220818224400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Persons")
               .AddColumn("NumberOfDependents").AsInt32().Nullable()
               .AddColumn("Occupation").AsString().Nullable()
               .AddColumn("NameOfEmployer").AsString().Nullable()
               .AddColumn("WorkTelephone").AsString().Nullable();
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

