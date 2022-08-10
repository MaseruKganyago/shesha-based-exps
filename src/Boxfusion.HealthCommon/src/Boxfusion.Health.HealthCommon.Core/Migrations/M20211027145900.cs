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
    [Migration(20211027145900)]
    public class M20211027145900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_AppointmentResponses")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString(30).Nullable()
                .WithForeignKeyColumn("AppointmentId", "Fhir_Appointments")
                .WithColumn("StartDate").AsDateTime().Nullable()
                .WithColumn("EndDate").AsDateTime().Nullable()
                .WithColumn("ParticipantTypeLkp").AsInt64().Nullable()
                .WithColumn("ActorOwnerId").AsString(30).Nullable()
                .WithColumn("ActorOwnerType").AsString(150).Nullable()
                .WithColumn("ParticipantStatusLkp").AsInt64().Nullable()
                .WithColumn("Comment").AsString(400).Nullable();
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
