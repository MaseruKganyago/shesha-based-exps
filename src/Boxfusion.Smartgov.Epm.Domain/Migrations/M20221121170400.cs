
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	/// <summary>
	/// 
	/// </summary>
	[Migration(20221121170400)]
	public class M20221121170400 : Migration
	{
		/// <summary>
		/// 
		/// </summary>
		public override void Up()
		{
			#region Deleting ForeignKey Parent and AuditCompleteById from Epm_ComponentProgressReports
			Delete.ForeignKey("FK_Epm_ComponentProgressReports_Parent_Epm_ComponentProgressReports_Id").OnTable("Epm_ComponentProgressReports");
			Delete.Index("IX_Epm_ComponentProgressReports_Parent").OnTable("Epm_ComponentProgressReports");
			Delete.Column("Parent").FromTable("Epm_ComponentProgressReports");

			Delete.ForeignKey("FK_Epm_ComponentProgressReports_AuditCompleteById_Core_Persons_Id").OnTable("Epm_ComponentProgressReports");
			Delete.Index("IX_Epm_ComponentProgressReports_AuditCompleteById").OnTable("Epm_ComponentProgressReports");
			Delete.Column("AuditCompleteById").FromTable("Epm_ComponentProgressReports");
			#endregion

			Alter.Table("Epm_ComponentProgressReports")
				.AddForeignKeyColumn("ParentId", "Epm_ComponentProgressReports").Nullable()
				.AddForeignKeyColumn("AuditCompletedById", "Epm_ComponentProgressReports").Nullable();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
