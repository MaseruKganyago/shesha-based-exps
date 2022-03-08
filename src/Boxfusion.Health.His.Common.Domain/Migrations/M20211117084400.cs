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
    [Migration(20211117084400)]
    public class M20211117084400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("HisAdmissionId").OnTable("Fhir_Encounters").To("His_HisAdmissionId");
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
