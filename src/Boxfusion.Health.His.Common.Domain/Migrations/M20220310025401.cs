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
    [Migration(20220310025401)]
    public class M20220310025401 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            Execute.Sql(@"
            -- =============================================
            -- Author:		Ian Houvet
            -- Create date: 2022-03-10
            -- Description:	Inserts or Updates a facility specific patient identifier
            -- =============================================
            CREATE OR ALTER PROCEDURE Sp_His_UpsertFacilityPatientIdentifier
	            @patientId uniqueidentifier,
	            @facilityId uniqueidentifier,
	            @facilityPatientIdentifier nvarchar(50),
	            @currentUserId bigint
            AS
            BEGIN
	            -- SET NOCOUNT ON added to prevent extra result sets from
	            -- interfering with SELECT statements.
	            SET NOCOUNT ON;

                DECLARE @ExistingId uniqueidentifier

	            SELECT @ExistingId = Id 
						            FROM Fhir_Identifiers 
						            WHERE 
							            OwnerId = @patientId 
							            AND AssignerId = @facilityId 
							            AND TypeLkp = 5 /* Facility Patient Identifier*/

	            IF @ExistingId IS NULL
                BEGIN
		            -- Patient Facility identifier record does not exist yet, so will create it
		            INSERT INTO Fhir_Identifiers (Id, AssignerId, OwnerId, OwnerType, TypeLkp, Value, UseLkp, CreatorUserId, CreationTime) 
		            VALUES (NEWID(), @facilityId, @patientId, 'His.HisPatient', 5, @facilityPatientIdentifier, 1, @currentUserId, GETDATE())
                END
                ELSE
                BEGIN
		            -- Patient Facility identifier record already exists so will update it
                    UPDATE Fhir_Identifiers 
		            SET  
			            [Value] = @facilityPatientIdentifier,
			            LastModificationTime = GETDATE(),
			            LastModifierUserId = @currentUserId
		            WHERE Id = @ExistingId
                END
	
            END
            GO            ");
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
