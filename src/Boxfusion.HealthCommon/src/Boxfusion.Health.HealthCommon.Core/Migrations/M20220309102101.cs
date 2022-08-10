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
    [Migration(20220309102101)]
    public class M20220309102101 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Slots").AddColumn("OverflowCapacity").AsInt32().Nullable();

            Execute.Sql(@"
				ALTER TABLE Fhir_Slots DROP COLUMN IF EXISTS CapacityTypeLkp
                GO
        ");
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

