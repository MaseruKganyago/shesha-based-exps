using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Domain.Domain.Accounts;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.BillingClassifications;
using Boxfusion.Health.His.Common.Coverages;
using Boxfusion.Health.His.Common.Domain.Domain.BillingClassifications.Enum;
using Boxfusion.Health.His.Common.Practitioners;
using Boxfusion.Health.His.Domain.Helpers;
using FluentMigrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shesha.Authorization.Users;
using Shesha.AutoMapper.Dto;
using Shesha.DynamicEntities.Dtos;
using Shesha.Enterprise.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class AccountPaymentAppService : HisAppServiceBase
    {
        private readonly IRepository<HospitalAdmission, Guid> _hospitaAdmissionRepo;
        private readonly IRepository<BillingClassification, Guid> _billingClassificationRepo;
        private readonly IRepository<CashCoverage, Guid> _cashCoverageRepo;
        private readonly AccountManager _accountManager;

        /// <summary>
        /// 
        /// </summary>
        public AccountPaymentAppService(
            IRepository<HospitalAdmission, Guid> hospitaAdmissionRepo,
            IRepository<BillingClassification, Guid> billingClassificationRepo,
            IRepository<CashCoverage, Guid> cashCoverageRepo,
            AccountManager accountManager
            )
        {
            _hospitaAdmissionRepo = hospitaAdmissionRepo;
            _billingClassificationRepo = billingClassificationRepo;
            _cashCoverageRepo = cashCoverageRepo;
            _accountManager = accountManager;
        }

        /// <summary>
        /// Creates a new account for every visit. Also create Self Coverage. Link the Coverages to the newly created account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("RegisterPatient/SetPayment")]
        [AbpAuthorize()]
        public async Task<Guid> SetPaymentAsync(SetPaymentInput input)
        {
            if (!RequestContextHelper.HasFacilityId)
            {
                throw new ArgumentNullException("facilityId header should be provided", "facilityId");
            }
            Validation.ValidateIdWithException(input?.BillingClassificationId, "BillingClassificationId");
            Validation.ValidateIdWithException(input?.HospitalAdmissionId, "HospitalAdmissionId");
            var hospitalAdmission = await _hospitaAdmissionRepo.GetAsync(input.HospitalAdmissionId);
            var billingClassification = await _billingClassificationRepo.GetAsync(input.BillingClassificationId);
            BankAccount bankAccount = null;

            if ((billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid))
            {
                Validation.ValidateIdWithException(input?.SelectedMedicalAidCoverageId, "SelectedMedicalAidCoverageId");
                if (input.CashPayerType != (int)CashPayerType.Self && input.CashPayerType != (int)CashPayerType.SomeoneElse)
                {
                    throw new ArgumentException("Should select either Self or SomeoneElse", "CashPayerType");
                }
            }

            if ((billingClassification?.ClassificationType.Value == (long)ClassificationType.Cash
                    || billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid) && input.CashPayerType == (int)CashPayerType.Self)
            {
                Validation.ValidateNullableType(input?.BankAccount, "BankAccount");

                if (hospitalAdmission?.Subject == null)
                {
                    throw new NullReferenceException("Patient reference in hospital admission cannot be empty");
                }

                var existingSelfCashCoverage = await _cashCoverageRepo.FirstOrDefaultAsync(x => x.PayorPerson == hospitalAdmission.Subject && x.Beneficiary == hospitalAdmission.Subject);
                if(existingSelfCashCoverage != null && (input?.BankAccount?.Id == null || input?.BankAccount?.Id == Guid.Empty))
                {
                    throw new ArgumentNullException("When self cash coverage exist, the bank account Id cannot be empty", "BankAccountId");
                }

                if (existingSelfCashCoverage == null && !(input?.BankAccount?.Id == null || input?.BankAccount?.Id == Guid.Empty))
                {
                    throw new ArgumentNullException("When self cash coverage does not exist, the bank account Id should not be empty", "BankAccountId");
                }

                //Map bank account details
                var mapper = IocManager.Resolve<IMapper>();
                bankAccount = mapper.Map<BankAccount>(input?.BankAccount);
                bankAccount.OwnerPerson = hospitalAdmission.Subject; //Set bank account owner to the current patient
            }

            if ((billingClassification?.ClassificationType.Value == (long)ClassificationType.Cash
                    || billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid) && input.CashPayerType == (int)CashPayerType.SomeoneElse)
            {
                Validation.ValidateIdWithException(input?.Selected3rdPartyCoverageId, "Selected3rdPartyCoverageId");
            }



            //Step 1 Update HospitalAdmission.BillingClassification with selected BillingClassification from form
            var updatedHospitalAdmission = await _accountManager.UpdateHospitalAdmissionBillingClassification(hospitalAdmission, billingClassification);
            


            //Step 2 Create Account
            var facilityId = RequestContextHelper.FacilityId; //access facilityId from the the header
            var newAccount = await _accountManager.CreateAccount(facilityId, updatedHospitalAdmission, billingClassification);

            //Step 3 Create missing Coverages and links:
            await _accountManager.CreateCoverage(updatedHospitalAdmission.Subject, billingClassification, newAccount,
                bankAccount, input.CashPayerType, input?.SelectedMedicalAidCoverageId, input?.Selected3rdPartyCoverageId);

            return newAccount.Id;
        }
    }
}
