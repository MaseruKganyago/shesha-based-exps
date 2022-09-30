using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Coverages
{
    public static class Util
    {
		/// <summary>
		/// 
		/// </summary>
        public static string GetFlattenedCoverage = @"SELECT TOP 1
	                        cov.Id
	                        ,per.Id OwnerPersonId
	                        ,per.FullName OwnerPersonFullName
	                        ,org.Id OwnerOrganisationId
	                        ,org.[Name] OwnerOrganisationName
	                        ,bc.AccountName
	                        ,bc.BankLkp Bank
	                        ,bc.BranchName
	                        ,bc.BranchCode
	                        ,bc.AccountTypeLkp AccountType
	                        ,bc.AccountNumber
	                        ,bc.StatusLkp [Status]
	                        ,bc.CurrentBalance
	                        ,cur.Code CurrencyCode
	                        ,cur.FullName CurrencyFullName
	                        ,cur.Symbol CurrencySymbol
                        FROM Fhir_Coverages cov
                        LEFT JOIN entpr_BankAccounts bc ON bc.Id = cov.His_BankAccountId
                        LEFT JOIN Core_Persons per ON per.Id = bc.OwnerPersonId
                        LEFT JOIN Core_Organisations org ON org.Id = bc.OwnerOrganisationId
                        LEFT JOIN entpr_Currencies cur ON cur.Id = bc.CurrencyId
                        WHERE cov.BeneficiaryId = :patientId
                        AND cov.IsDeleted = 0
						ORDER BY cov.CreationTime DESC;";
    }
}
