using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    
    [Migration(20220926123300)]
    public class M20220926123300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Reference list items for AccountType
            this.Shesha().ReferenceListCreate("Fhir", "CoverageStatus")
                .SetDescription("The status of the coverage instance")
                .SetNoSelectionValue(1)
                .AddItem(1, "active", 0, "Active")
                .AddItem(2, "cancelled", 0, "Cancelled")
                .AddItem(3, "draft", 0, "Draft")
                .AddItem(4, "entered-in-error", 0, "Entered-in-error");

            //Reference list items for AccountStatus
            this.Shesha().ReferenceListCreate("Fhir", "CoverageType")
                .SetDescription("The type of coverage: social program, medical plan, accident coverage (workers compensation, auto), group health or payment by an individual or organization")
                .SetNoSelectionValue(1)
                .AddItem(1, "pay", 0, "Pay");
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
