using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    
    [Migration(20220811151200)]
    public class M20220811151200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Column("Fhir_DistrictLkp").FromTable("Core_Organisations");
            Delete.Column("Fhir_TypeLkp").FromTable("Core_Organisations");
            Delete.Column("Fhir_FacilityTypeLkp").FromTable("Core_Organisations");

            if (Schema.Table("Core_Organisations").Column("Hough_FacilityPracticeNumber").Exists())
            {
                Delete.Column("Hough_FacilityPracticeNumber").FromTable("Core_Organisations");
            }

            if (Schema.Table("Core_Organisations").Constraint("FK_Core_Organisations_Hough_DistrictId_Core_Areas_Id").Exists())
            {
                //Delete Foreign Key
                Delete.ForeignKey("FK_Core_Organisations_Hough_DistrictId_Core_Areas_Id").OnTable("Core_Organisations");
            }

            if (Schema.Table("Core_Organisations").Index("IX_Core_Organisations_Hough_DistrictId").Exists())
            {
                //Delete Index
                Delete.Index("IX_Core_Organisations_Hough_DistrictId").OnTable("Core_Organisations");
            }

            if (Schema.Table("Core_Organisations").Column("Hough_DistrictId").Exists())
            {
                //Delete Hough_DistrictId Column
                Delete.Column("Hough_DistrictId").FromTable("Core_Organisations");
            }

            Alter.Table("Core_Organisations")
                .AddColumn("Fhir_FacilityPracticeNumber").AsString().Nullable()
                .AddForeignKeyColumn("Fhir_DistrictId", "Core_Areas");
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
