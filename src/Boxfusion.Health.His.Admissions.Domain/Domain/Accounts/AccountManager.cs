using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
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

        /// 
        /// </summary>
        /// <param name="billingClassificationRepo"></param>
        public AccountManager(
                    IRepository<BillingClassification, Guid> billingClassificationRepo,
                    IRepository<HisAccount, Guid> accountRepo,
                    IRepository<HospitalAdmission, Guid> hospitaAdmissionRepo,
                    IRepository<HisHealthFacility, Guid> hisHealthFacilityRepo,
                    IRepository<CashCoverage, Guid> cashCoverageRepo,
                    IRepository<Coverage, Guid> coverageRepo,
                    IRepository<AccountCoverage, Guid> accountCoverageRepo)
        {
            _billingClassificationRepo = billingClassificationRepo;
            _accountRepo = accountRepo;
            _hospitaAdmissionRepo = hospitaAdmissionRepo;
            _hisHealthFacilityRepo = hisHealthFacilityRepo;
            _cashCoverageRepo = cashCoverageRepo;
            _coverageRepo = coverageRepo;
            _accountCoverageRepo = accountCoverageRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalAdmissionId"></param>
        /// <param name="billClassificationId"></param>
        /// <param name="selectedMedicalAid"></param>
        /// <param name="selected3rdPartyCoverage"></param>
        /// <param name="bankAccount"></param>
        /// <param name="cashPayerType"></param>
        /// <param name="medicalAidCoverageId"></param>
        /// <param name="selected3rdPartyCoverageId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Guid> SetPayment(Guid hospitalAdmissionId, Guid billClassificationId, 
            Guid selectedMedicalAid, Guid selected3rdPartyCoverage, BankAccount bankAccount, int cashPayerType, 
            Guid medicalAidCoverageId, Guid selected3rdPartyCoverageId)
        {
            var hospitalAdmission = await _hospitaAdmissionRepo.GetAsync(hospitalAdmissionId);
            if (hospitalAdmission is null)
                throw new ArgumentException("patientId is not recognised.", "patientId");

            var billingClassification = await _billingClassificationRepo.GetAsync(billClassificationId);
            if (billingClassification is null)
                throw new ArgumentException("billClassificationId is not recognised.", "billClassificationId");

            //Step 1 Update HospitalAdmission.BillingClassification from form
            var updatedHospitalAdmission = await UpdateHospitalAdmissionBillingClassification(hospitalAdmission, billingClassification);
            //Step 2 Create Account
            var account = await CreateAccount(updatedHospitalAdmission.Subject, billingClassification);
            //Step 3 Create missing Coverages:
            var coverages = await CreateCoverage(updatedHospitalAdmission.Subject, billingClassification, bankAccount, cashPayerType);
            //Step 4 Create AccountCoverage links
            var accountCoverages = CreateAccountCoverage(billingClassification, account, updatedHospitalAdmission.Subject, cashPayerType,
                medicalAidCoverageId, selected3rdPartyCoverageId);

            return account.Id;
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
            if (!RequestContextHelper.HasFacilityId) return null;

            var facilityId = RequestContextHelper.FacilityId;
            var healthFacility = await _hisHealthFacilityRepo.GetAsync(facilityId);
            if (healthFacility is null)
                throw new ArgumentException("facilityId is not recognised.", "facilityId");

            //Define the account name 
            //TODO: Fix when DefaultPayor.Name is empty
            var name = $"({patient.FullName} - {billClassification.ClassificationType.Value} ({billClassification?.DefaultPayor?.Name ?? string.Empty}))";

            //Save the account
            return await _accountRepo.InsertAsync(new HisAccount()
            {
                AccountStatus = (long) AccountStatus.active,
                AccountType = (long) AccountType.patient,
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
        /// <param name="bankAccount"></param>
        /// <param name="cashPayerType"></param>
        /// <returns></returns>
        public async Task<Coverage> CreateCoverage(Patient patient, BillingClassification billingClassification, BankAccount bankAccount, int cashPayerType)
        {
            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.medicalAid || billingClassification?.ClassificationType.Value == (long)ClassificationType.cash)
            {
                if (cashPayerType == (int)CashPayerType.self)
                {
                    var coverage = await _cashCoverageRepo.FirstOrDefaultAsync(x => x.PayorPerson == patient);
                    if (coverage is null)
                    {
                        //TODO: Identify which variables to populate
                        return await _cashCoverageRepo.InsertAsync(new CashCoverage
                        {
                            Beneficiary = patient,
                            PayorPerson = patient,
                            BankAccount = bankAccount,
                        });
                    }
                    coverage.BankAccount = bankAccount;
                    return await _cashCoverageRepo.UpdateAsync(coverage);
                }

                return null;
            }
            else 
            {
                var coverage = await _coverageRepo.FirstOrDefaultAsync(x => x.PayorOrganisation == billingClassification.DefaultPayor && x.Beneficiary == patient);
                if (coverage is not null)
                    return coverage;

                //TODO: Identify which variables to populate
                return await _coverageRepo.InsertAsync(new Coverage
                {
                    Beneficiary = patient,
                    PayorOrganisation = billingClassification.DefaultPayor,
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="billingClassification"></param>
        /// <param name="account"></param>
        /// <param name="patient"></param>
        /// <param name="cashPayerType"></param>
        /// <param name="medicalAidCoverageId"></param>
        /// <param name="selected3rdPartyCoverageId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<AccountCoverage>> CreateAccountCoverage(BillingClassification billingClassification, HisAccount account, Patient patient,
            int cashPayerType, Guid medicalAidCoverageId, Guid selected3rdPartyCoverageId)
        {
            List<AccountCoverage> accountCoverages = new List<AccountCoverage>();

            if(billingClassification?.ClassificationType.Value == (long)ClassificationType.medicalAid)
            {
                var medicalAidCoverage = await _coverageRepo.GetAsync(medicalAidCoverageId);
                if (medicalAidCoverage is null)
                    throw new ArgumentException("medicalAidOrganisationId is not recognised.", "medicalAidOrganisationId");

                var accountMedicalAidCoverage = await _accountCoverageRepo.InsertAsync(new AccountCoverage
                {
                    Account = account,
                    Coverage = medicalAidCoverage,
                });
                accountCoverages.Add(accountMedicalAidCoverage);

                var coverage = await _cashCoverageRepo.FirstOrDefaultAsync(x => x.PayorPerson == patient) ?? await _cashCoverageRepo.GetAsync(selected3rdPartyCoverageId);
                if(coverage is not null)
                {
                    var accountCoverage = await _accountCoverageRepo.InsertAsync(new AccountCoverage
                    {
                        Account = account,
                        Coverage = coverage,
                    });
                    accountCoverages.Add(accountCoverage);
                }
            }

            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.iod || billingClassification?.ClassificationType.Value == (long)ClassificationType.roadAccidentFund)
            {
                var organisationCoverage = await _coverageRepo.FirstOrDefaultAsync(x => x.PayorOrganisation == billingClassification.DefaultPayor && x.Beneficiary == patient);
                var accountCoverage = await _accountCoverageRepo.InsertAsync(new AccountCoverage
                {
                    Account = account,
                    Coverage = organisationCoverage,
                });
                accountCoverages.Add(accountCoverage);
            }

            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.cash && cashPayerType == (int)CashPayerType.self)
            {
                var cashCoverage = await _cashCoverageRepo.FirstOrDefaultAsync(x => x.PayorPerson == patient);
                var accountCoverage = await _accountCoverageRepo.InsertAsync(new AccountCoverage
                {
                    Account = account,
                    Coverage = cashCoverage,
                });
                accountCoverages.Add(accountCoverage);
            }

            if (billingClassification?.ClassificationType.Value == (long)ClassificationType.cash && cashPayerType == (int)CashPayerType.someoneElse)
            {
                var coverage = await _cashCoverageRepo.FirstOrDefaultAsync(x => x.PayorPerson == patient) ?? await _cashCoverageRepo.GetAsync(selected3rdPartyCoverageId);
                if (coverage is null)
                    throw new ArgumentException("Selected3rdPartyCoverageId is not recognised.", "Selected3rdPartyCoverageId");

                var accountCoverage = await _accountCoverageRepo.InsertAsync(new AccountCoverage
                {
                    Account = account,
                    Coverage = coverage,
                });
                accountCoverages.Add(accountCoverage);
            }

            return accountCoverages;
        }
    }
}
