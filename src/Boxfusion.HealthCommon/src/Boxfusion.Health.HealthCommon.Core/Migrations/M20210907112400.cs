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
    [Migration(20210907112400)]
    public class M20210907112400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.ForeignKey("FK_Fhir_MedicationStatements_DosageId_Fhir_Dosages_Id").OnTable("Fhir_MedicationStatements");
            Delete.Index("IX_Fhir_MedicationStatements_DosageId").OnTable("Fhir_MedicationStatements");
            Delete.Column("DosageId").FromTable("Fhir_MedicationStatements");
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

