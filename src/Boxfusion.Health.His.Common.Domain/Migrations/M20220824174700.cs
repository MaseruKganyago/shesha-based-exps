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
    [Migration(20220824174700)]
    public class M20220824174700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.ForeignKey("FK_Fhir_Coverages_ClassId_Fhir_Classes_Id").OnTable("Fhir_Coverages");
            Delete.Index("IX_Fhir_Coverages_ClassId").OnTable("Fhir_Coverages");
            Delete.Column("ClassId").FromTable("Fhir_Coverages");

            Alter.Table("Fhir_Coverages")
                .AddColumn("Class").AsString().Nullable();
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
