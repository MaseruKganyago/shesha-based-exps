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
	[Migration(20220818111100)]
	public class M20220818111100 : Migration
	{
		/// <summary>
		/// 
		/// </summary>
		public override void Up()
		{
			Execute.Sql(@"Create or ALTER   VIEW [dbo].[vw_His_FlattenedFacilityPatients]
	            AS
	            SELECT 
                   p.Id
                   ,[TitleLkp]
	              --, dbo.Frwk_GetRefListItem('Shesha.Core', 'PersonTitles', p.[TitleLkp]) Title
                  ,[IdentityNumber]
                  ,[His_PatientMasterIndexNumber] [PatientMasterIndexNumber]
	              ,dbo.[fn_His_GetFacilityPatientIdentifier](p.Id, hf.Id) FacilityPatientIdentifier
                  ,[Fhir_PassportNumber] [PassportNumber]
                  ,[Fhir_PermitNumber] [PermitNumber]
                  ,[Fhir_DispensaryNumber] [DispensaryNumber]
                  ,[Fhir_IdentificationTypeLkp] [IdentificationTypeLkp]
	              --, dbo.Frwk_GetRefListItem('His', 'IdentificationTypes', p.[His_IdentificationTypeLkp]) [IdentificationType]	
                  ,[Initials]
                  ,[FirstName]
                  ,[LastName]
                  ,[MobileNumber1]
                  ,[MobileNumber2]
                  --,[MobileNumberConfirmed]
                  ,[CustomShortName]
                  ,[DateOfBirth]
                  ,[EmailAddress1]
                  ,[EmailAddress2]
                  --,[EmailAddressConfirmed]
                  --,[FaxNumber]
                  ,[GenderLkp]
	              --, dbo.Frwk_GetRefListItem('Shesha.Core', 'Gender', p.[GenderLkp]) Gender
                  ,[HomeNumber]
                  ,[PreferredContactMethodLkp]
	              --, dbo.Frwk_GetRefListItem('Shesha.Core', 'PreferredContactMethod', p.[PreferredContactMethodLkp]) PatientPreferredContactMethod
                  ,[RequireChangePassword]
                  --,[TypeOfAccountLkp]
                  --,[UserName]
                  --,[DetailsValidated]
                  --,[PostalAddressId]
                  --,[ResidentialAddressId]
                  ,[UserId]
                  ,[FullName]
                  ,[FullName2]
                  ,[Fhir_CommunicationLanguageLkp] [CommunicationLanguageLkp]
	              --, dbo.Frwk_GetRefListItem('Shesha.Core', 'CommonLanguage', p.[Fhir_CommunicationLanguageLkp]) CommunicationLanguage
                  ,[Fhir_NationalityLkp] [NationalityLkp]
	              --, dbo.Frwk_GetRefListItem('Cdm', 'Countries', p.[Fhir_NationalityLkp]) [Nationality]
                  ,[Fhir_EthnicityLkp] [EthnicityLkp]
	              --, dbo.Frwk_GetRefListItem('Cdm', 'PersonEthnicity', p.[Fhir_EthnicityLkp]) [Ethnicity]
                  ,[Fhir_OtherIdentityNumber] [OtherIdentityNumber]
                  ,[Fhir_MaritalStatusLkp] [MaritalStatusLkp]
	              --, dbo.Frwk_GetRefListItem('Fhir', 'MaritalStatus', p.[Fhir_MaritalStatusLkp]) [MaritalStatus]	
                  ,[Fhir_GeneralPractitioner] [GeneralPractitioner]
                  ,[Fhir_IsDisabled] [IsDisabled]
                  ,[Fhir_IsEmployed] [IsEmployed]
                  ,[Fhir_HasMedicalAid] [HasMedicalAid]
                  ,[Fhir_MedicalAidName] [MedicalAidName]
                  ,[Fhir_MedicalAidNumber] [MedicalAidNumber]
                  ,[His_PatientProvinceLkp] [PatientProvinceLkp]
	              , dbo.Frwk_GetRefListItem('His', 'Provinces', p.[His_PatientProvinceLkp]) [PatientProvince]	
	              ,hf.Id FacilityId
	              ,hf.Name FacilityName
	              ,hf.Frwk_Discriminator FacilityDiscriminator
                  ,p.[CreationTime]
                  ,p.[CreatorUserId]
                  ,p.[LastModificationTime]
                  ,p.[LastModifierUserId]

	            FROM Core_Persons p 
		            LEFT JOIN Core_Organisations hf ON p.Id IS NOT NULL
	            WHERE 
		            p.Frwk_Discriminator = 'His.HisPatient'
		            AND hf.Frwk_Discriminator IN ('His.HisHealthFacility', 'His.HisHealthFacility', 'His.HisHospital' /*Should no longer be relevant after entity has been renamed*/, 'Fhir.Hospital' /*Delete - for testing purposes only*/)
		            AND p.IsDeleted = 0
		            AND hf.IsDeleted = 0
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
