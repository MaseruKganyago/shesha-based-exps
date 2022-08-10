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
    [Migration(20220515052801)]
    public class M20220515052801 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            this.Rename.Column("Capacity").OnTable("Fhir_Slots").To("RegularCapacity");
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

