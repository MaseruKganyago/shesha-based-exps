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
    [Migration(20220907130100)]
    public class M20220907130100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
CREATE or ALTER       View [dbo].[vw_His_FlattenedHospitalAdmissions]
AS
select
hospAdm.Id,
patient.Fhir_IdentificationTypeLkp as IdentificationTypeLkp,
patient.IdentityNumber,
patient.DateOfBirth,
patient.FirstName,
patient.LastName,
patient.MobileNumber1,
patient.Fhir_NationalityLkp as NationalityLkp,
patient.GenderLkp,
patient.Fhir_PatientMasterIndexNumber as PatientMasterIndexNumber,
patient.Id as PatientId,
hospAdm.His_HospitalAdmissionNumber as HospitalAdmissionNumber,
hospAdm.StartDateTime,
--hospAdm.His_AdmissionTypeLkp,
hospAdm.EndDateTime,
hospAdm.His_ClassificationLkp as ClassificationLkp,
hospAdm.ClassLkp,
hospAdm.His_AdmissionStatusLkp as HospitalAdmissionStatusLkp,
ward.Id WardAdmissionId,
ward.Name as WardName,
wardAdm.His_AdmissionStatusLkp as WardAdmissionStatusLkp,
wardAdm.StartDateTime as WardAdmissionDate,
billClass.Name as BillingClassificationName,
billClass.Id as BillingClassificationId,
(select Count(*) from entpr_Accounts acc where acc.Fhir_EncounterId = hospAdm.Id) as NumberOfAccounts,
(select MAX(InvoiceDate) from entpr_Invoices where entpr_Invoices.Fhir_SubjectId = patient.Id) as LastInvoiceDate,
iif(hospAdm.His_AdmissionStatusLkp != 1, DATEDIFF(day, hospAdm.StartDateTime, hospAdm.EndDateTime), DATEDIFF(day, hospAdm.StartDateTime, DateAdd(hour, 2, GETUTCDATE()))) as LOS
from Fhir_Encounters hospAdm
	join Core_Persons patient on hospAdm.SubjectId = patient.Id and patient.Frwk_Discriminator = 'His.HisPatient'
	left join His_BillingClassifications billClass on billClass.Id = hospAdm.His_BillingClassificationId
	left join Fhir_Encounters wardAdm on wardAdm.SubjectId = patient.Id 
		and wardAdm.Frwk_Discriminator = 'His.WardAdmission'
		and wardAdm.StartDateTime = (select MAX(StartDateTime) from Fhir_Encounters where PartOfId = hospAdm.Id and wardAdm.Frwk_Discriminator = 'His.WardAdmission')

	left join Core_Facilities ward on ward.Id = wardAdm.His_WardId
where hospAdm.Frwk_Discriminator = 'His.HospitalAdmission'
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
