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
        private readonly AccountManager _accountManager;

        /// <summary>
        /// 
        /// </summary>
        public AccountPaymentAppService(
            IRepository<HospitalAdmission, Guid> hospitaAdmissionRepo,
            IRepository<BillingClassification, Guid> billingClassificationRepo,
            AccountManager accountManager
            )
        {
            _hospitaAdmissionRepo = hospitaAdmissionRepo;
            _billingClassificationRepo = billingClassificationRepo;
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

            if ((billingClassification?.ClassificationType.Value == (long)ClassificationType.Cash
                    || billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid) && input.CashPayerType == (int)CashPayerType.Self)
            {
                Validation.ValidateNullableType(input?.BankAccount, "BankAccount");
            }

            if ((billingClassification?.ClassificationType.Value == (long)ClassificationType.Cash
                    || billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid) && input.CashPayerType == (int)CashPayerType.SomeoneElse)
            {
                Validation.ValidateIdWithException(input?.Selected3rdPartyCoverageId, "Selected3rdPartyCoverageId");
            }

            if ((billingClassification?.ClassificationType.Value == (long)ClassificationType.MedicalAid))
            {
                Validation.ValidateIdWithException(input?.SelectedMedicalAidCoverageId, "SelectedMedicalAidCoverageId");
            }

            //Map bank account details
            var mapper = IocManager.Resolve<IMapper>();
            var bankAccount = mapper.Map<BankAccount>(input?.BankAccount);

            //Step 1 Update HospitalAdmission.BillingClassification with selected BillingClassification from form
            var updatedHospitalAdmission = await _accountManager.UpdateHospitalAdmissionBillingClassification(hospitalAdmission, billingClassification);
            
            //Set bank account owner to the current patient
            if(updatedHospitalAdmission?.Subject == null)
            {
                throw new NullReferenceException("Patient reference in hospital admission cannot be empty");
            }

            bankAccount.OwnerPerson = updatedHospitalAdmission.Subject;

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
