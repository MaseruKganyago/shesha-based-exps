using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using Abp.UI;
using Aspose.Pdf.Annotations;
using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.BillingClassifications;
using Boxfusion.Health.His.Common.Coverages;
using Boxfusion.Health.His.Common.Domain.Domain.Accounts.Enum;
using Boxfusion.Health.His.Common.Domain.Domain.BillingClassifications;
using Boxfusion.Health.His.Common.Domain.Domain.BillingClassifications.Enum;
using Boxfusion.Health.His.Common.Domain.Domain.Coverages.Enum;
using Boxfusion.Health.His.Common.Patients;
using DocumentFormat.OpenXml.Wordprocessing;
using NHibernate.Engine;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Enterprise.Accounts;
using Shesha.Enterprise.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountManager : DomainService
    {
        private readonly IRepository<HisAccount, Guid> _accountRepo;
        private readonly IRepository<HospitalAdmission, Guid> _hospitaAdmissionRepo;
        private readonly IRepository<HisHealthFacility, Guid> _hisHealthFacilityRepo;
        private readonly IRepository<CashCoverage, Guid> _cashCoverageRepo;
        private readonly IRepository<Coverage, Guid> _coverageRepo;
        private readonly IRepository<AccountCoverage, Guid> _accountCoverageRepo;
        private readonly IRepository<BankAccount, Guid> _bankAccountRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountRepo"></param>
        /// <param name="hospitaAdmissionRepo"></param>
        /// <param name="hisHealthFacilityRepo"></param>
        /// <param name="cashCoverageRepo"></param>
        /// <param name="coverageRepo"></param>
        /// <param name="accountCoverageRepo"></param>
        /// <param name="bankAccountRepo"></param>
        public AccountManager(
                    IRepository<HisAccount, Guid> accountRepo,
                    IRepository<HospitalAdmission, Guid> hospitaAdmissionRepo,
                    IRepository<HisHealthFacility, Guid> hisHealthFacilityRepo,
                    IRepository<CashCoverage, Guid> cashCoverageRepo,
                    IRepository<Coverage, Guid> coverageRepo,
                    IRepository<AccountCoverage, Guid> accountCoverageRepo,
                    IRepository<BankAccount, Guid> bankAccountRepo)
        {
            _accountRepo = accountRepo;
            _hospitaAdmissionRepo = hospitaAdmissionRepo;
            _hisHealthFacilityRepo = hisHealthFacilityRepo;
            _cashCoverageRepo = cashCoverageRepo;
            _coverageRepo = coverageRepo;
            _accountCoverageRepo = accountCoverageRepo;
            _bankAccountRepo = bankAccountRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalAdmission"></param>
        /// <param name="billClassification"></param>
        /// <returns></returns>
        public async Task<HospitalAdmission> UpdateHospitalAdmissionBillingClassification(HospitalAdmission hospitalAdmission, BillingClassification billClassification)
        {
            hospitalAdmission.BillingClassification = billClassification;
            var updatedHospitalAdmission = await _hospitaAdmissionRepo.UpdateAsync(hospitalAdmission);

            return updatedHospitalAdmission;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="hospitalAdmission"></param>
        /// <param name="billClassification"></param>
        /// <returns></returns>
        public async Task<HisAccount> CreateAccount(Guid facilityId, HospitalAdmission hospitalAdmission, BillingClassification billClassification)
        {
            var healthFacility = await _hisHealthFacilityRepo.GetAsync(facilityId);
            //Define the account name 
            var name = $"({hospitalAdmission.Subject.FullName} - {UtilityHelper.GetRefListItemText("His", "BillingClassificationType", billClassification.ClassificationType.Value) } ({billClassification?.DefaultPayor?.Name }))";

            //Save the account
            return await _accountRepo.InsertAsync(new HisAccount()
            {
                AccountStatus = (long)AccountStatus.Active,
                AccountType = (long)AccountType.Patient,
                Name = name,
                Subject = hospitalAdmission.Subject,
                ServiceStartDate = DateTime.Now,
                Owner = healthFacility,
                Encounter = hospitalAdmission
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="billingClassification"></param>
        /// <param name="account"></param>
        /// <param name="bankAccount"></param>
        /// <param name="cashPayerType"></param>
        /// <param name="selectedMedicalAidCoverageId"></param>
        /// <param name="selected3rdPartyCoverageId"></param>
        /// <returns></returns>
        public async Task CreateCoverage(Patient patient, BillingClassification billingClassification, HisAccount account,
            BankAccount bankAccount, int cashPayerType, Guid? selectedMedicalAidCoverageId, Guid? selected3rdPartyCoverageId)
        {
            //Create account coverage link medical aid
            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid)
            {
                await CreateAccountCoverageLink(account, selectedMedicalAidCoverageId);
            }

            // Need to ensure cash coverage is available and added to the account
            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.Cash
                || billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid)
            {
                if (cashPayerType == (int)CashPayerType.Self)
                {
                    await CreateSelfCoverageAndAccountCoverageLink(patient, account, bankAccount);
                }
                else if (cashPayerType == (int)CashPayerType.SomeoneElse)
                {
                    await CreateAccountCoverageLink(account, selected3rdPartyCoverageId);
                }
            }

            //Create coverage and account coverage link for RAF or IOD
            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.CoveredBySingleOrganisation)
            {
                await CreateOrganisationCoverageAndAccountCoverageLink(patient, billingClassification, account);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="billingClassification"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private async Task CreateOrganisationCoverageAndAccountCoverageLink(Patient patient, BillingClassification billingClassification, HisAccount account)
        {
            var coverage = await _coverageRepo.FirstOrDefaultAsync(x => x.PayorOrganisation == billingClassification.DefaultPayor && x.Beneficiary == patient);

            Coverage dbCoverage = null;
            if (coverage is null)
            {
                dbCoverage = await _coverageRepo.InsertAsync(new Coverage
                {
                    Status = (long)CoverageStatus.Active,
                    Beneficiary = patient,
                    PayorOrganisation = billingClassification.DefaultPayor,
                    Type = billingClassification.DefaultCoverageType
                });
            }

            await CreateAccountCoverage(account, coverage ?? dbCoverage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task CreateAccountCoverageLink(HisAccount account, Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new ArgumentNullException("The id cannot be empty", "id");
            }

            Coverage coverage = null;
            //Get medical or existingSomeoneCoverage coverage using the selected medical aid coverage Id
            if (!(id == null || id == Guid.Empty))
            {
                coverage = await _coverageRepo.GetAsync(id.Value);
            }
            await CreateAccountCoverage(account, coverage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="account"></param>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        private async Task CreateSelfCoverageAndAccountCoverageLink(Patient patient, HisAccount account, BankAccount bankAccount)
        {
            //Get existing self coverage
            var existingSelfCashCoverage = await _cashCoverageRepo.FirstOrDefaultAsync(x => x.PayorPerson == patient && x.Beneficiary == patient);
            var insertedOrUpdatedSelfCoverage = await InsertUpdateSelfCoverage(existingSelfCashCoverage, patient, bankAccount);

            await CreateAccountCoverage(account, insertedOrUpdatedSelfCoverage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="existingSelfCashCoverage"></param>
        /// <param name="patient"></param>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        private async Task<CashCoverage> InsertUpdateSelfCoverage(CashCoverage existingSelfCashCoverage,
            Patient patient, BankAccount bankAccount)
        {
            if (existingSelfCashCoverage is null)
            {
                var newBankAccount = await InsertBankAccount(bankAccount);
                return await _cashCoverageRepo.InsertAsync(new CashCoverage
                {
                    Status = (long)CoverageStatus.Active,
                    Type = (long)CoverageType.CashSelf,
                    Beneficiary = patient,
                    PayorPerson = patient,
                    BankAccount = newBankAccount,
                });
            }
            else
            {
                var updatedBankAccount = await UpdateBankAccount(bankAccount);
                existingSelfCashCoverage.BankAccount = updatedBankAccount;
                return await _cashCoverageRepo.UpdateAsync(existingSelfCashCoverage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        private async Task<BankAccount> InsertBankAccount(BankAccount bankAccount)
        {
            return await _bankAccountRepo.InsertAsync(bankAccount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        private async Task<BankAccount> UpdateBankAccount(BankAccount bankAccount)
        {
            var dbBankAccount = await _bankAccountRepo.GetAsync(bankAccount.Id);
            dbBankAccount.Bank = bankAccount.Bank;
            dbBankAccount.AccountType = bankAccount.AccountType;
            dbBankAccount.AccountNumber = bankAccount.AccountNumber;
            dbBankAccount.BranchCode = bankAccount.BranchCode;

            return await _bankAccountRepo.UpdateAsync(dbBankAccount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="coverage"></param>
        /// <returns></returns>
        private async Task CreateAccountCoverage(HisAccount account, Coverage coverage)
        {
            var accountCoverage = await _accountCoverageRepo.InsertAsync(new AccountCoverage
            {
                Account = account,
                Coverage = coverage,
            });
        }      
    }
}

