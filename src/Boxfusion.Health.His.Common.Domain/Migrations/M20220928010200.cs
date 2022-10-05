using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220928010200)]
    public class M20220928010200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            this.Shesha().ReferenceListUpdate("His", "BillingClassificationType")
                .AddItem(1, "Medical Aid", 1, "Medical Aid")
                .AddItem(2, "Cash", 2, "Cash")
                .UpdateItem(3, i => i.SetItemText("CoveredBySingleOrganisation").SetDescription("Covered By Single Organisation").SetOrderIndex(0)) // update item
                .DeleteItem(4); // delete item
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
