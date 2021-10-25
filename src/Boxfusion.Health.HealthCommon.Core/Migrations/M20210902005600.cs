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
    [Migration(20210902005600)]
    public class M20210902005600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Delete AssignerId Column
            Delete.Column("ProvisionalCondition").FromTable("Fhir_ServiceRequests");

            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.AmbulanceServiceRequest
            Alter.Table("Fhir_ServiceRequests")
                .AddColumn("ProvisionalConditionLkp").AsInt64().Nullable();

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

