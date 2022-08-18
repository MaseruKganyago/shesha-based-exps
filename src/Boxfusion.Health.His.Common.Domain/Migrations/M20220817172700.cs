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
	[Migration(20220817172700)]
	public class M20220817172700 : Migration
	{
		/// <summary>
		/// 
		/// </summary>
		public override void Up()
		{
			//Boxfusion.Health.His.Common.Domain.BillingClassification
			Create.Table("His_BillingClassifications")
				.WithFullAuditColumns()
				.WithIdAsGuid()
				.WithColumn("Name").AsString().Nullable()
				.WithColumn("Description").AsString().Nullable()
				.WithColumn("ClassificationTypeLkp").AsInt64().Nullable()
				.WithColumn("DiscountPercent").AsDecimal().Nullable()
				.WithForeignKeyColumn("DefaultPayorId", "Core_Organisations").Nullable();

			this.Shesha().ReferenceListCreate("His", "BillingClassificationType")
				.AddItem(1, "Medical Aid", 1, "Medical Aid")
				.AddItem(2, "Cash", 2, "Cash")
				.AddItem(3, "Road Accident Fund", 3, "Road Accident Fund")
				.AddItem(4, "IOD", 4, "IOD");

			Alter.Table("entpr_PriceLists")
				.AddColumn("His_ClassificationTypeLkp").AsInt64().Nullable();

			#region Change BedType ForeignKey in Bed
			Delete.ForeignKey("FK_Core_Facilities_His_BedTypeId_His_BedTypes_Id").OnTable("Core_Facilities");
			Delete.Index("IX_Core_Facilities_His_BedTypeId").OnTable("Core_Facilities");
			Delete.Column("His_BedTypeId").FromTable("Core_Facilities");

			Alter.Table("Core_Facilities")
				.AddForeignKeyColumn("His_BedTypeId", "entpr_Products");
			#endregion

			Delete.Table("His_BedTypes");

			//Boxfusion.Health.His.Common.Domain.HisProcedure
			Alter.Table("Fhir_Procedures")
				.AddForeignKeyColumn("His_ProcedureServiceId", "entpr_Products");

			//Boxfusion.Health.His.Common.Consumable
			Create.Table("His_Consumables")
				.WithFullAuditColumns()
				.WithIdAsGuid()
				.WithForeignKeyColumn("ProcedureId", "Fhir_Procedures")
				.WithColumn("Quantity").AsInt64().Nullable()
				.WithForeignKeyColumn("ConsumableProductId", "entpr_Products");
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
