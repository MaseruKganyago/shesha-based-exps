using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220905141200)]
    public class M20220905141200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			Execute.Sql(@"

                DECLARE @Id1 UNIQUEIDENTIFIER;
                DECLARE @Id2 UNIQUEIDENTIFIER;
                SELECT @Id1 = Id FROM [dbo].[Frwk_ReferenceLists] where [Name] = 'PracticeSettingCodeValueSets';
                SELECT @Id2 = Id FROM [dbo].[Frwk_ReferenceLists] where [Name] = 'Speciality';

                DELETE FROM Frwk_ReferenceListItems WHERE ReferenceListId=@Id1;
               
                DELETE FROM Frwk_ReferenceLists WHERE Id =@Id1;

                DELETE FROM Frwk_ReferenceListItems WHERE ReferenceListId=@Id2;

                DELETE FROM Frwk_ReferenceLists WHERE Id =@Id2;
            ");

			this.Shesha().ReferenceListCreate("Fhir", "PracticeSettingCodeValueSets")
				.SetDescription("PracticeSettingCodeValueSets Reference List")
				.AddItem(1, "Gynaecology", 1, "Gynaecology")
				.AddItem(2, "Maternity", 2, "Maternity")
				.AddItem(4, "Medicine", 3, "Medicine")
				.AddItem(8, "Orthopaedic", 4, "Orthopaedic")
				.AddItem(16, "Paediatric", 5, "Paediatric")
				.AddItem(32, "Psychiatry", 6, "Psychiatry")
				.AddItem(64, "Surgery", 7, "Surgery");

			this.Shesha().ReferenceListCreate("Fhir", "Speciality")
				.SetDescription("Speciality Reference List")
				.AddItem(1, "Gynaecology", 1, "Gynaecology")
				.AddItem(2, "Maternity", 2, "Maternity")
				.AddItem(4, "Medicine", 3, "Medicine")
				.AddItem(8, "Orthopaedic", 4, "Orthopaedic")
				.AddItem(16, "Paediatric", 5, "Paediatric")
				.AddItem(32, "Psychiatry", 6, "Psychiatry")
				.AddItem(64, "Surgery", 7, "Surgery");
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

