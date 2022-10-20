﻿using Abp.Extensions;
using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220908162200)]
    public class M20220908162200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_HealthCareServices")
               .AddForeignKeyColumn("CoverageAreaId", "Core_Areas").Nullable();
              



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
