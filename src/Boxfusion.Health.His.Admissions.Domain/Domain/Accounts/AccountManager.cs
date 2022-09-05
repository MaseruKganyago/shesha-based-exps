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
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.BillingClassifications;
using Boxfusion.Health.His.Common.Coverages;
using Boxfusion.Health.His.Common.Domain.Domain.Accounts.Enum;
using Boxfusion.Health.His.Common.Domain.Domain.BillingClassifications;
using Boxfusion.Health.His.Common.Domain.Domain.BillingClassifications.Enum;
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
        private readonly IRepository<BillingClassification, Guid> _billingClassificationRepo;
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
        /// <param name="billingClassificationRepo"></param>
        /// <param name="accountRepo"></param>
        /// <param name="hospitaAdmissionRepo"></param>
        /// <param name="hisHealthFacilityRepo"></param>
        /// <param name="cashCoverageRepo"></param>
        /// <param name="coverageRepo"></param>
        /// <param name="accountCoverageRepo"></param>
        /// <param name="bankAccountRepo"></param>
        public AccountManager(
                    IRepository<BillingClassification, Guid> billingClassificationRepo,
                    IRepository<HisAccount, Guid> accountRepo,
                    IRepository<HospitalAdmission, Guid> hospitaAdmissionRepo,
                    IRepository<HisHealthFacility, Guid> hisHealthFacilityRepo,
                    IRepository<CashCoverage, Guid> cashCoverageRepo,
                    IRepository<Coverage, Guid> coverageRepo,
                    IRepository<AccountCoverage, Guid> accountCoverageRepo,
                    IRepository<BankAccount, Guid> bankAccountRepo)
        {
            _billingClassificationRepo = billingClassificationRepo;
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
        /// <param name="hospitalAdmissionId"></param>
        /// <param name="billClassificationId"></param>
        /// <param name="selectedMedicalAidId"></param>
        /// <param name="bankAccount"></param>
        /// <param name="cashPayerType"></param>
        /// <param name="selected3rdPartyCoverageId"></param>
        /// <returns></returns>
        public async Task<HisAccount> SetPayment(Guid hospitalAdmissionId, Guid billClassificationId,
            Guid? selectedMedicalAidId, BankAccount bankAccount, int cashPayerType, Guid? selected3rdPartyCoverageId)
        {
            var hospitalAdmission = await _hospitaAdmissionRepo.GetAsync(hospitalAdmissionId);
            var billingClassification = await _billingClassificationRepo.GetAsync(billClassificationId);

            //Step 1 Update HospitalAdmission.BillingClassification from form
            var updatedHospitalAdmission = await UpdateHospitalAdmissionBillingClassification(hospitalAdmission, billingClassification);
            //Step 2 Create Account
            var account = await CreateAccount(updatedHospitalAdmission.Subject, billingClassification);
            //Step 3 Create missing Coverages and links:
            await CreateCoverage(updatedHospitalAdmission.Subject, billingClassification, account, 
                bankAccount, cashPayerType, selectedMedicalAidId, selected3rdPartyCoverageId);

            return account;
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
        /// <param name="patient"></param>
        /// <param name="billClassification"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<HisAccount> CreateAccount(Patient patient, BillingClassification billClassification)
        {
            if (!RequestContextHelper.HasFacilityId) throw new ArgumentNullException("facilityId header should be provided", "facilityId");

            var facilityId = RequestContextHelper.FacilityId;
            var healthFacility = await _hisHealthFacilityRepo.GetAsync(facilityId);

            //Define the account name 
            //TODO: Fix when DefaultPayor.Name is empty
            var name = $"({patient.FullName} - {billClassification.ClassificationType.Value} ({billClassification?.DefaultPayor?.Name ?? string.Empty}))";

            //Save the account
            return await _accountRepo.InsertAsync(new HisAccount()
            {
                AccountStatus = (long)AccountStatus.active,
                AccountType = (long)AccountType.patient,
                Name = name,
                Subject = patient,
                ServiceStartDate = DateTime.Now,
                Owner = healthFacility
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
        /// <param name="selectedMedicalAidId"></param>
        /// <param name="selected3rdPartyCoverageId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task CreateCoverage(Patient patient, BillingClassification billingClassification, HisAccount account,
            BankAccount bankAccount, int cashPayerType, Guid? selectedMedicalAidId, Guid? selected3rdPartyCoverageId)
        {
            Coverage medicalAidCoverage = null;
            Coverage existingSomeoneCoverage = null;

            //Get medical covergae using the selected medical aid Id
            if (!(selectedMedicalAidId is Guid guidMedicalAidId && guidMedicalAidId == Guid.Empty))
                medicalAidCoverage = await _coverageRepo.FirstOrDefaultAsync(x => x.PayorOrganisation.Id == selectedMedicalAidId);
            //Get existing self coverage
            var existingSelfCashCoverage = await _cashCoverageRepo.FirstOrDefaultAsync(x => x.PayorPerson == patient);
            //Get existing someone else coverage
            if (!(selected3rdPartyCoverageId is Guid guid3rdPartyCoverageId && guid3rdPartyCoverageId == Guid.Empty))
                existingSomeoneCoverage = await _coverageRepo.GetAsync(selected3rdPartyCoverageId.Value);

            //Create account coverage link medical aid
            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.medicalAid)
            {
                var insertedOrUpdatedBankAccount = await InsertUpdateBankAccount(bankAccount);

                CashCoverage insertedOrUpdatedSelfCoverage = null;
                await CreateAccountCoverage(account, medicalAidCoverage);
                if (cashPayerType == (int)CashPayerType.self)
                {
                    insertedOrUpdatedSelfCoverage = await InsertUpdateSelfCoverage(existingSelfCashCoverage, cashPayerType, patient, bankAccount);
                    await CreateAccountCoverage(account, insertedOrUpdatedSelfCoverage);
                }
                else if (cashPayerType == (int)CashPayerType.someoneElse)
                {
                    await CreateAccountCoverage(account, medicalAidCoverage);
                    await CreateAccountCoverage(account, existingSomeoneCoverage);
                }
            }

            //Create coverage and account coverage link for RAF or IOD
            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.roadAccidentFund || billingClassification?.ClassificationType.Value == (long)ClassificationType.iod)
            {
                var coverage = await _coverageRepo.FirstOrDefaultAsync(x => x.PayorOrganisation == billingClassification.DefaultPayor && x.Beneficiary == patient);
                if (coverage is not null)
                    throw new UserFriendlyException("Organisation coverage does not exist.");

                //TODO: Identify which variables to populate
                var dbCoverage = await _coverageRepo.InsertAsync(new Coverage
                {
                    Beneficiary = patient,
                    PayorOrganisation = billingClassification.DefaultPayor,
                });

                await CreateAccountCoverage(account, coverage ?? dbCoverage);
            }
        }

        private async Task<CashCoverage> InsertUpdateSelfCoverage(CashCoverage existingSelfCashCoverage, int cashPayerType,
            Patient patient, BankAccount bankAccount)
        {
            var insertUpdateBankAccount = await InsertUpdateBankAccount(bankAccount);
            if (existingSelfCashCoverage is null)
            {
                //TODO: Identify which variables to populate
                return await _cashCoverageRepo.InsertAsync(new CashCoverage
                {
                    Beneficiary = patient,
                    PayorPerson = patient,
                    BankAccount = insertUpdateBankAccount,
                });
            }
            else
            {
                existingSelfCashCoverage.BankAccount = bankAccount;
                return await _cashCoverageRepo.UpdateAsync(existingSelfCashCoverage);
            }
        }

        private async Task<BankAccount> InsertUpdateBankAccount(BankAccount bankAccount)
        {
            if (bankAccount is null)
                return null;

            //Updating bank details
            if (bankAccount?.Id is Guid guid && guid == Guid.Empty)
                return await _bankAccountRepo.InsertAsync(bankAccount);
            else
            {
                var dbBankAccount = await _bankAccountRepo.GetAsync(bankAccount.Id);
                dbBankAccount.Bank = bankAccount.Bank;
                dbBankAccount.AccountType = bankAccount.AccountType;
                dbBankAccount.AccountNumber = bankAccount.AccountNumber;
                dbBankAccount.BranchCode = bankAccount.BranchCode;
                return await _bankAccountRepo.UpdateAsync(dbBankAccount);
            }
        }

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

