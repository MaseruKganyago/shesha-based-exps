using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Migrations
{
    [Migration(20220811162300)]
    public class M20220811162300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            this.Shesha().ReferenceListCreate("Fhir", "PracticeSettingCodeValueSets")
                .SetDescription("Updated Specility Reference")
                .SetNoSelectionValue(1)
                .AddItem(1, "Gynaecology", 0, "Gynaecology")
                .AddItem(2, "Maternity", 0, "Maternity")
                .AddItem(4, "Medicine", 0, "Medicine")
                .AddItem(8, "Orthopaedic", 0, "Orthopaedic")
                .AddItem(16, "Paediatric", 0, "Paediatric")
                .AddItem(32, "Psychiatry", 0, "Psychiatry")
                .AddItem(64, "Surgery", 0, "Surgery");
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
