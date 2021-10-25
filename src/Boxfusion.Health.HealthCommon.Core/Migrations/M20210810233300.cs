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
    [Migration(20210810233300)]
    public class M20210810233300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_ServiceRequests_PatientId_Core_Persons_Id").OnTable("Fhir_ServiceRequests");

            //Delete Index
            Delete.Index("IX_Fhir_ServiceRequests_PatientId").OnTable("Fhir_ServiceRequests");

            //Delete PatientId Column
            Delete.Column("PatientId").FromTable("Fhir_ServiceRequests");

            //Rename.Column("Priority").OnTable("Fhir_ServiceRequests").To("PriorityLkp");
            Rename.Column("OderDetailLkp").OnTable("Fhir_ServiceRequests").To("OrderDetailLkp");
            Rename.Column("QuantityRationDenominator").OnTable("Fhir_ServiceRequests").To("QuantityRatioDenominator");
            Rename.Column("RequestedOwnerId").OnTable("Fhir_ServiceRequests").To("RequestOwnerId");
            Rename.Column("RequestedOwnerType").OnTable("Fhir_ServiceRequests").To("RequestOwnerType");
            Rename.Column("PerformerOwnderId").OnTable("Fhir_ServiceRequests").To("PerformerOwnerId");


            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.ServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddForeignKeyColumn("SubjectId", "Core_Persons")
                .AddForeignKeyColumn("LocationReferenceId", "Core_Facilities");
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

