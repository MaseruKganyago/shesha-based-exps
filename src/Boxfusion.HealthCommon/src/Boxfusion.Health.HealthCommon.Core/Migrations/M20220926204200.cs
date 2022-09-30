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
    
    [Migration(20220926204200)]
    public class M20220926204200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Reference list items for AccountType
            this.Shesha().ReferenceListUpdate("Fhir", "CoverageType")
                .SetDescription("The type of coverage: social program, medical plan, accident coverage (workers compensation, auto), group health or payment by an individual or organization")
                .SetNoSelectionValue(1)
                .UpdateItem(1, i => i.SetItemText("CashSelf").SetDescription("Cash Self").SetOrderIndex(0)) // update item
                .AddItem(2, "CashSomeoneElse", 0, "Cash Someone Else")
                .AddItem(3, "MedicalAid", 0, "Medical Aid")
                .AddItem(4, "RoadAccidentFund", 0, "Road Accident Fund")
                .AddItem(5, "WorkmansCompensation", 0, "Workmans Compensation");

            //Reference list items for AccountType
            this.Shesha().ReferenceListUpdate("Fhir", "CoverageStatus")
                .SetDescription("The type of coverage: social program, medical plan, accident coverage (workers compensation, auto), group health or payment by an individual or organization")
                .SetNoSelectionValue(1)
                .UpdateItem(1, i => i.SetItemText("Active").SetDescription("Active").SetOrderIndex(0)) // update item
                .UpdateItem(2, i => i.SetItemText("Cancelled").SetDescription("Cancelled").SetOrderIndex(0)) // update item
                .UpdateItem(3, i => i.SetItemText("Draft").SetDescription("Draft").SetOrderIndex(0)) // update item
                .UpdateItem(4, i => i.SetItemText("Entered-in-error").SetDescription("Entered-in-error").SetOrderIndex(0)); // update item
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
