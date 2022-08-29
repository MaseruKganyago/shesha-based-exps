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
    [Migration(20220829142700)]
    public class M20220829142700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Table("Fhir_PatientContact");    
            
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

