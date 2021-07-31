using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210725162200)]
    public class M20210725162200 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.CdmCommunication
            Alter.Table("Fhir_Communications")
                .AddForeignKeyColumn("ServiceRequestId", "Fhir_ServiceRequests")
                .AddColumn("StartTime").AsDateTime().Nullable()
                .AddColumn("EndTime").AsDateTime().Nullable();

        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

