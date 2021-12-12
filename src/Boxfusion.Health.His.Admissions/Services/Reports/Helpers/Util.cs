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
        public static string DailyReportSqlQuery = @"select
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
												,DATEDIFF(day, enc.StartDateTime, getdate()) AS PatientDays
												from
												Fhir_Encounters enc
												left join Core_Persons per on per.Id = enc.SubjectId 
												left join Core_Facilities fac on fac.Id = enc.His_WardId
												left join Fhir_Encounters hosEnc on hosEnc.Id = enc.PartOfId
												where enc.His_WardId = :wardId and convert(date, enc.StartDateTime) <= convert(date, :filterDate)
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
												,DATEDIFF(day, enc.StartDateTime, getdate()) AS PatientDays
												from
												Fhir_Encounters enc
												left join Core_Persons per on per.Id = enc.SubjectId 
												left join Core_Facilities fac on fac.Id = enc.His_WardId
												left join Fhir_Encounters hosEnc on hosEnc.Id = enc.PartOfId
												where enc.His_WardId = :wardId and convert(date, enc.StartDateTime) = convert(date, :filterDate)
												and (enc.His_AdmissionStatusLkp = 2 and enc.His_AdmissionStatusLkp = 4) and enc.IsDeleted = 0";

		/// <summary>
		/// 
		/// </summary>
		public static string MonthReportSqlQuery = @"select
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
													,DATEDIFF(day, enc.StartDateTime, getdate()) AS PatientDays
													from
													Fhir_Encounters enc
													left join Core_Persons per on per.Id = enc.SubjectId 
													left join Core_Facilities fac on fac.Id = enc.His_WardId
													left join Fhir_Encounters hosEnc on hosEnc.Id = enc.PartOfId
													where enc.His_WardId = :wardId and month(enc.StartDateTime) = month(:filterDate)
													and enc.IsDeleted = 0";
		#endregion
	}
}
