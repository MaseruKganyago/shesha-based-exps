using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Migrations
{
    [Migration(20220812142300)]
    public class M20220812142300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            this.Shesha().ReferenceListCreate("Shesha.Core", "OrganisationUnitType")
                .SetDescription("Updated Organisation Unit Type")
                .SetNoSelectionValue(1)
                .AddItem(1, "prov", 0, "Healthcare Provider")
                .AddItem(2, "dept", 0, "Hospital Department")
                .AddItem(3, "team", 0, "Organizational team")
                .AddItem(4, "govt", 0, "Government")
                .AddItem(5, "ins", 0, "Insurance Company")
                .AddItem(6, "pay", 0, "Payer")
                .AddItem(7, "edu", 0, "Educational Institute")
                .AddItem(8, "reli", 0, "Religious Institution")
                .AddItem(9, "crs", 0, "Clinical Research Sponsor")
                .AddItem(10, "cg", 0, "Community Group")
                .AddItem(11, "bus", 0, "Non-Healthcare Business or Corporation")
                .AddItem(12, "other", 0, "Other")
                ;
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
