using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220824143500)]
    public class M20220824143500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            this.Shesha().ReferenceListUpdate("Shesha", "NoteType")
                .AddItem(1, "Admission", 1, "Admission")
                .AddItem(2, "Discharge", 2, "Discharge");
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
