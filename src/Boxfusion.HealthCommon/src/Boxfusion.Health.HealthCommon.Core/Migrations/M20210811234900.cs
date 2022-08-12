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
    [Migration(20210811234900)]
    public class M20210811234900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cmd.CdmServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                 //.AddColumn("ScheduleTypeLkp").AsInt64().Nullable()
                 //.AddForeignKeyColumn("ServiceQueueId", "Fhir_ServiceRequests")
                 .AddColumn("ServiceQueuePosition").AsDecimal().Nullable();
                 //.AddColumn("ServiceQueuePriorityLkp").AsInt64().Nullable()
                 //.AddForeignKeyColumn("BookingSlotId", "Fhir_Slots");
                 //.AddColumn("ConsultServiceRequestStatusLkp").AsInt64().Nullable();
                 //.AddColumn("TimeJoinedQue").AsDateTime().Nullable()
                 //.AddColumn("TimeCancelled").AsDateTime().Nullable()
                 //.AddForeignKeyColumn("EncounterInitiatedId", "Fhir_Encounters");
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

