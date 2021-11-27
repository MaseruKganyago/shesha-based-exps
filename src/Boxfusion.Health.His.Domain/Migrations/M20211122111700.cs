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
    [Migration(20211122111700)]
    public class M20211122111700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("His_InternalTransferOriginalWard").OnTable("Fhir_Encounters").To("His_InternalTransferOriginalWardId");
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
