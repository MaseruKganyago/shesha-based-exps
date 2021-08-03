using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;
namespace Boxfusion.Health.His.Admissions.Migrations
{
    [Migration(20210731152600)]
    public class M20210731152600 : Migration
    {
        public override void Up()
        {
            Delete.Table("HisAdmis_Identifiers");
            Delete.Table("HisAdmis_Addresses");
            Delete.Table("HisAdmis_Attachments");
            Delete.Table("HisAdmis_ClassHistories");
            Delete.Table("HisAdmis_Communications");
            Delete.Table("HisAdmis_HumanNames");
            Delete.Table("HisAdmis_ContactPoints");
            Delete.Table("HisAdmis_HoursOfOperations");
            Delete.Table("HisAdmis_Positions");
            Delete.Table("HisAdmis_StatusHistories");
            Delete.Table("HisAdmis_Diagnoses");
            Delete.Table("HisAdmis_Contacts");
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}

