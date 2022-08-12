using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using Shesha.FluentMigrator;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220128214300)]
    public class M20220128214300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_CdmAppointments_Patient_Core_Persons_Id").OnTable("Fhir_CdmAppointments");
            Delete.ForeignKey("FK_Fhir_CdmAppointments_Practitioner_Core_Persons_Id").OnTable("Fhir_CdmAppointments");

            //Delete Index
            Delete.Index("IX_Fhir_CdmAppointments_Patient").OnTable("Fhir_CdmAppointments");
            Delete.Index("IX_Fhir_CdmAppointments_Practitioner").OnTable("Fhir_CdmAppointments");

            //Delete AssignerId Column
            Delete.Column("Patient").FromTable("Fhir_CdmAppointments");
            Delete.Column("Practitioner").FromTable("Fhir_CdmAppointments");

            Alter.Table("Fhir_CdmAppointments")
                .AddForeignKeyColumn("PatientId", "Core_Persons")
                .AddForeignKeyColumn("PractitionerId", "Core_Persons");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }


        private class RoleInfo
        {
            public string Name { get; set; }
            public string Namespace { get; set; }
            public string Description { get; set; }
        }

        private class RoleInfos : List<RoleInfo>
        {
            public void Add(string name, string @namespace, string description)
            {
                Add(new RoleInfo
                {
                    Name = name,
                    Namespace = @namespace,
                    Description = description,
                });
            }
        }

    }
}

