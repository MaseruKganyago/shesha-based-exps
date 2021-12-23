using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Helpers
{
	/// <summary>
	/// 
	/// </summary>
   public static class Util
    {
        #region Report sql
		/// <summary>
		/// SQL 
		/// </summary>
        public static string DailyReportSqlQuery = @"WITH CTE AS(	
select
												 enc.Id
												,per.His_IdentificationTypeLkp IdentificationType
												,per.IdentityNumber
												,per.DateOfBirth
												,per.GenderLkp Gender
												,enc.StartDateTime AdmissionDate
												,per.His_HospitalPatientNumber HospitalPatientNumber
												,enc.His_WardAdmissionNumber WardAdmissionNumber
												,per.FirstName
												,per.LastName
												,enc.His_AdmissionTypeLkp AdmissionType
												,fac.Fhir_SpecialityLkp Speciality
												,per.His_PatientProvinceLkp PatientProvince
												,hosEnc.His_ClassificationLkp [Classification]
												,per.Fhir_NationalityLkp Nationality
												,hosEnc.His_OtherCategoryLkp OtherCategory
												,enc.His_AdmissionStatusLkp AdmissionStatus
												,enc.His_SeparationDate SeparationDate
												,DATEDIFF(day, enc.StartDateTime, dateadd(HOUR, 2, getdate())) AS PatientDays
												,RN = ROW_NUMBER()OVER(PARTITION BY enc.Id ORDER BY enc.Id)
												from
												Fhir_Encounters enc
												left join Core_Persons per on per.Id = enc.SubjectId 
												left join Core_Facilities fac on fac.Id = enc.His_WardId
												left join Fhir_Encounters hosEnc on hosEnc.Id = enc.PartOfId
												where enc.His_WardId = :wardId and convert(date, enc.StartDateTime) <= convert(date, :filterDate) and convert(date, :filterDate) <= dateadd(HOUR, 2, getdate())
												and (enc.His_AdmissionStatusLkp != 2 and enc.His_AdmissionStatusLkp != 4)
												UNION ALL
												select
												 enc.Id
												,per.His_IdentificationTypeLkp IdentificationType
												,per.IdentityNumber
												,per.DateOfBirth
												,per.GenderLkp Gender
												,enc.StartDateTime AdmissionDate
												,per.His_HospitalPatientNumber HospitalPatientNumber
												,enc.His_WardAdmissionNumber WardAdmissionNumber
												,per.FirstName
												,per.LastName
												,enc.His_AdmissionTypeLkp AdmissionType
												,fac.Fhir_SpecialityLkp Speciality
												,per.His_PatientProvinceLkp PatientProvince
												,hosEnc.His_ClassificationLkp [Classification]
												,per.Fhir_NationalityLkp Nationality
												,hosEnc.His_OtherCategoryLkp OtherCategory
												,enc.His_AdmissionStatusLkp AdmissionStatus
												,enc.His_SeparationDate SeparationDate
												,DATEDIFF(day, enc.StartDateTime, dateadd(HOUR, 2, getdate())) AS PatientDays
												,RN = ROW_NUMBER()OVER(PARTITION BY enc.Id ORDER BY enc.Id)
												from
												Fhir_Encounters enc
												left join Core_Persons per on per.Id = enc.SubjectId 
												left join Core_Facilities fac on fac.Id = enc.His_WardId
												left join Fhir_Encounters hosEnc on hosEnc.Id = enc.PartOfId
												where enc.His_WardId = :wardId and convert(date, enc.StartDateTime) <= convert(date, :filterDate) and convert(date, :filterDate) <= dateadd(HOUR, 2, getdate())
												and (enc.His_AdmissionStatusLkp = 2) and enc.IsDeleted = 0
)
select * from CTE where RN = 1";

		/// <summary>
		/// 
		/// </summary>
		public static string MonthReportSqlQuery = @"WITH CTE AS(	
select
													enc.Id
													,per.His_IdentificationTypeLkp IdentificationType
													,per.IdentityNumber
													,per.DateOfBirth
													,per.GenderLkp Gender
													,enc.StartDateTime AdmissionDate
													,per.His_HospitalPatientNumber HospitalPatientNumber
													,enc.His_WardAdmissionNumber WardAdmissionNumber
													,per.FirstName
													,per.LastName
													,enc.His_AdmissionTypeLkp AdmissionType
													,fac.Fhir_SpecialityLkp Speciality
													,per.His_PatientProvinceLkp PatientProvince
													,hosEnc.His_ClassificationLkp [Classification]
													,per.Fhir_NationalityLkp Nationality
													,hosEnc.His_OtherCategoryLkp OtherCategory
													,enc.His_AdmissionStatusLkp AdmissionStatus
													,enc.His_SeparationDate SeparationDate
													,DATEDIFF(day, enc.StartDateTime, getdate()) AS PatientDays
												    ,RN = ROW_NUMBER()OVER(PARTITION BY enc.Id ORDER BY enc.Id)
													from
													Fhir_Encounters enc
													left join Core_Persons per on per.Id = enc.SubjectId 
													left join Core_Facilities fac on fac.Id = enc.His_WardId
													left join Fhir_Encounters hosEnc on hosEnc.Id = enc.PartOfId
													where enc.His_WardId = :wardId and month(enc.StartDateTime) = month(:filterDate)
													and enc.IsDeleted = 0
)
select * from CTE where RN = 1";

		/// <summary>
		/// 
		/// </summary>
		public static string Dashboards = @"WITH CTE AS (SELECT 
												ward.Id
												,[Name]
												,[Description]
												,Fhir_NumberOfBeds BedInWard
												,(SELECT COUNT(*)  FROM Fhir_Encounters enc WHERE enc.His_WardId = ward.Id AND enc.IsDeleted = 0 AND enc.StartDateTime <= GETDATE() AND enc.His_AdmissionStatusLkp = 1) AS TotalAdmittedPatients
												FROM Core_Facilities ward 
												WHERE OwnerOrganisationId = CASE WHEN :hospitalId IS NULL THEN OwnerOrganisationId ELSE :hospitalId END
												)
												SELECT Id, [Name], [Description], BedInWard, TotalAdmittedPatients, (BedInWard - TotalAdmittedPatients) TotalBedAvailability from CTE";
		#endregion
	}
}
