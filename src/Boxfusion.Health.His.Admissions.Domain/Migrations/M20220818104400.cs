using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220818104400)]
    public class M20220818104400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"Create or ALTER   view [dbo].[vw_Report_AllAdmittedPatientsView]  AS  

                    with cte as (
                    select SubjectId, His_ClassificationLkp,His_OtherCategoryLkp,His_WardId
                      FROM [dbo].[Fhir_Encounters]
                      where Frwk_Discriminator = 'His.HospitalAdmission'
                    ) 
                    select Fhir_IdentificationTypeLkp [Id_Type] 
                    ,IdentityNumber [Id_No]
                    ,DateOfBirth [DOB]
                    ,GenderLkp  [Gender]
                    ,enc.StartDateTime [Admission_Date]
                    ,His_HospitalPatientNumber [Hospital_Patient_Number]
                    ,enc.His_WardAdmissionNumber [Admission_Number]
                    ,FirstName [Patient_Name]
                    ,LastName [Patient_Surname]
                    ,enc.His_AdmissionTypeLkp  [Admission_TypeLkp]
                    ,His_PatientProvinceLkp [Patient_ProvinceLkp]
                    ,[patientCte].His_ClassificationLkp [Classification]
                    ,[ward].Fhir_SpecialityLkp [SpecialityLkp]
                    ,Fhir_NationalityLkp [Nationality]
                    ,[patientCte].His_OtherCategoryLkp  [Other_Categories]
                    ,enc.His_AdmissionStatusLkp [Admission_StatusLkp]
                    ,iif(enc.His_AdmissionStatusLkp = 1, DATEDIFF(day,enc.StartDateTime, getdate()),'') [InPatientDays]
                    --,Fhir_DeceasedBoolean
                    ,ward.Name [Ward] 
                    ,enc.His_WardId WardId
                    ,Fhir_NumberOfBeds [Usable_Beds] 
                     ,enc.Frwk_Discriminator 
                     ,enc.EndDateTime [DischargeDate]
                     ,enc.His_SeparationTypeLkp [SeparationTypeLkp]
                     ,enc.His_SeparationDate [SeparationDate]
                     ,hosp.Name Hospital
                    FROM [dbo].[Fhir_Encounters] enc
                      left join [dbo].[Core_Persons] [Patient] on enc.SubjectId = Patient.Id and  Patient.IsDeleted=0
                      and Patient.Frwk_Discriminator = 'His.HisPatient'
                      left join cte [patientCte] on enc.SubjectId = patientCte.SubjectId 
                      left join Core_Facilities [ward] on enc.His_WardId = ward.Id
                      left join Core_Organisations [hosp] on [hosp].Id = ward.OwnerOrganisationId
                    where 
                       enc.Frwk_Discriminator = 'His.WardAdmission'
GO");
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
