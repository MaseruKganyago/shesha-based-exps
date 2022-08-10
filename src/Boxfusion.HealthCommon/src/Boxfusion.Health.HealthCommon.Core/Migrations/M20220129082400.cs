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
    [Migration(20220129082400)]
    public class M20220129082400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Appointments")
                .AddColumn("Frwk_Discriminator").AsString(150);

            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_CdmAppointments_PatientId_Core_Persons_Id").OnTable("Fhir_CdmAppointments");
            Delete.ForeignKey("FK_Fhir_CdmAppointments_PractitionerId_Core_Persons_Id").OnTable("Fhir_CdmAppointments");

            //Delete Index
            Delete.Index("IX_Fhir_CdmAppointments_PatientId").OnTable("Fhir_CdmAppointments");
            Delete.Index("IX_Fhir_CdmAppointments_PractitionerId").OnTable("Fhir_CdmAppointments");

            //Delete AssignerId Column
            Delete.Column("PatientId").FromTable("Fhir_CdmAppointments");
            Delete.Column("PractitionerId").FromTable("Fhir_CdmAppointments");

            Delete.Table("Fhir_CdmAppointments");

            Alter.Table("Fhir_Appointments")
                .AddForeignKeyColumn("PatientId", "Core_Persons")
                .AddForeignKeyColumn("PractitionerId", "Core_Persons")
                .AddColumn("ArrivalTime").AsDateTime().Nullable()
                .AddColumn("RefNumber").AsString(100).Nullable()
                .AddColumn("ContactName").AsString(150).Nullable()
                .AddColumn("ContactCellphone").AsString(30).Nullable()
                .AddColumn("IssuedTicketNumber").AsString(30).Nullable()
                .AddColumn("QueuePosition").AsDouble().Nullable()
                .AddColumn("QueuePriority").AsInt32().Nullable()
                .AddColumn("DropOutTime").AsDateTime().Nullable()
                .AddColumn("FirstTimeCalled").AsDateTime().Nullable()
                .AddColumn("LastTimeCalled").AsDateTime().Nullable()
                .AddColumn("NumTimesCalled").AsInt32().Nullable()
                .AddColumn("FulfilledTime").AsDateTime().Nullable()
                .AddColumn("WaitingTimeTicks").AsInt64().Nullable()
                .AddColumn("AlternateContactName").AsString(100).Nullable()
                .AddColumn("AlternateContactCellphone").AsString(30).Nullable();
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

