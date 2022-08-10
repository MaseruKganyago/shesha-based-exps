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
    [Migration(20211214125100)]
    public class M20211214125100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"               
				  CREATE OR ALTER   View [dbo].[vw_HisAdmis_AdmittedPatientItems]
					AS
					SELECT wardEncounter.id, 
						patient.His_IdentificationTypeLkp AS IdentificationTypeLkp, 
						patient.identityNumber,
						patient.DateOfBirth,
						patient.GenderLkp, 
						wardEncounter.StartDateTime,
						patient.His_HospitalPatientNumber AS HospitalisationPatientNumber, 
						wardEncounter.His_WardAdmissionNumber AS WardAdmissionNumber,
						patient.FirstName,
						patient.LastName,
						wardEncounter.His_AdmissionTypeLkp AS AdmissionTypeLkp,
						ward.Fhir_SpecialityLkp AS SpecialityLkp, 
						patient.His_PatientProvinceLkp AS ProvinceLkp,
						hospitalEncounter.His_ClassificationLkp AS ClassificationLkp,
						patient.Fhir_NationalityLkp AS NationalityLkp, 
						hospitalEncounter.His_OtherCategoryLkp OtherCategoryLkp,
						wardEncounter.His_AdmissionStatusLkp AS AdmissionStatusLkp,
						iif(wardEncounter.His_AdmissionStatusLkp = 1, DATEDIFF(day,wardEncounter.StartDateTime, getdate()), DATEDIFF(day,wardEncounter.StartDateTime, wardEncounter.EndDateTime)) as days,
						ward.OwnerOrganisationId AS HospitalId
	
					FROM Fhir_Encounters wardEncounter 
						LEFT JOIN Core_Persons patient ON wardEncounter.SubjectId = patient.Id AND wardEncounter.Frwk_Discriminator = 'His.WardAdmission'
						LEFT JOIN Fhir_Encounters hospitalEncounter ON hospitalEncounter.SubjectId = patient.Id AND hospitalEncounter.Frwk_Discriminator = 'His.HospitalAdmission'
						LEFT JOIN Core_Facilities ward ON wardEncounter.His_WardId = ward.Id
					WHERE wardEncounter.Frwk_Discriminator = 'His.WardAdmission'
						AND patient.IsDeleted = 0 AND hospitalEncounter.IsDeleted = 0 AND ward.IsDeleted = 0

				GO
            ");
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

