using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    
    [Migration(20220830131000)]
    public class M20220830131000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Reference list items for AccountType
            this.Shesha().ReferenceListCreate("Fhir", "AccountType")
                .SetDescription("Financial Account Type")
                .SetNoSelectionValue(1)
                .AddItem(1, "patient", 0, "Patient")
                .AddItem(2, "expense", 0, "Expense")
                .AddItem(3, "depreciation", 0, "Depreciation");

            //Reference list items for AccountStatus
            this.Shesha().ReferenceListCreate("Fhir", "AccountStatus")
                .SetDescription("Financial Account Status")
                .SetNoSelectionValue(1)
                .AddItem(1, "active", 0, "Active")
                .AddItem(2, "inactive", 0, "Inactive")
                .AddItem(3, "entered-in-error", 0, "Entered in error")
                .AddItem(3, "on-hold", 0, "On hold")
                .AddItem(3, "unknown", 0, "Unknown")
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
