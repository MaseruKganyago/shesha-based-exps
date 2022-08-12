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
    [Migration(20210929074000)]
    public class M20210929074000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Contents")
                .AddForeignKeyColumn("AttachmentId", "Frwk_StoredFiles");
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

