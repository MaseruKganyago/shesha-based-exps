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
    [Migration(20220822192300)]
    public class M20220822192300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("His_PatientMasterIndexNumber").OnTable("Core_Persons").To("Fhir_PatientMasterIndexNumber");

            Alter.Table("Core_Persons")
                .AddColumn("Fhir_RegistrationType").AsInt64().Nullable();

            this.Shesha().ReferenceListCreate("Cdm", "RegistrationTypes")
                .AddItem(1, "Emergency", 1, "Emegerncy")
                .AddItem(2, "OutPatient", 2, "Out Patient")
                .AddItem(3, "InPatient", 3, "In Patient");

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
