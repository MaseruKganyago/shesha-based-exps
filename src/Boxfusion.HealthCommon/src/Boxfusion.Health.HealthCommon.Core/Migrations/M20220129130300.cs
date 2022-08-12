using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220129130300)]
    public class M20220129130300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column(" StatusLkp").OnTable("Fhir_Appointments").To("StatusLkp");
            Rename.Column(" CancelationReasonLkp").OnTable("Fhir_Appointments").To("CancelationReasonLkp");
            Rename.Column(" ServiceCategoryLkp").OnTable("Fhir_Appointments").To("ServiceCategoryLkp");
            Rename.Column(" ServiceTypeLkp").OnTable("Fhir_Appointments").To("ServiceTypeLkp");
            Rename.Column(" SpecialityLkp").OnTable("Fhir_Appointments").To("SpecialityLkp");
            Rename.Column(" AppointmentTypeLkp").OnTable("Fhir_Appointments").To("AppointmentTypeLkp");
            Rename.Column(" ReasonCodeLkp").OnTable("Fhir_Appointments").To("ReasonCodeLkp");
            Rename.Column(" Description").OnTable("Fhir_Appointments").To("Description");
            Rename.Column(" SupportingInformationOwnerId").OnTable("Fhir_Appointments").To("SupportingInformationOwnerId");
            Rename.Column(" SupportingInformationOwnerType").OnTable("Fhir_Appointments").To("SupportingInformationOwnerType");
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
