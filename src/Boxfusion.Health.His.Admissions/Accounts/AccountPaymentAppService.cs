using Abp.Authorization;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Domain.Domain.Accounts;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Accounts;
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
        private readonly AccountManager _accountManager;

        /// <summary>
        /// 
        /// </summary>
        public AccountPaymentAppService(
            AccountManager accountManager
            )
        {
            _accountManager = accountManager;
        }

        /// <summary>
        /// Creates a new Appointment to book the first available Slot for the specified schedule and requestedTime.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("RegisterPatient/SetPayment")]
        [AbpAuthorize()]
        public async Task<DynamicDto<HisAccount, Guid>> SetPaymentAsync(SetPaymentInput input)
        {
            Validation.ValidateIdWithException(input?.BillingClassificationId, "BillingClassificationId");
            Validation.ValidateIdWithException(input?.HospitalAdmissionId, "HospitalAdmissionId");


            var mapper = IocManager.Resolve<IMapper>();
            var bankAccount = mapper.Map<BankAccount>(input?.SelfCoverage);

            var newAccount = await _accountManager.SetPayment(
                input.HospitalAdmissionId, 
                input.BillingClassificationId,
                input.SelectedMedicalAidId, 
                bankAccount, 
                input.CashPayerType,
            input.Selected3rdPartyCoverageId);

            return await this.MapToDynamicDtoAsync<HisAccount, Guid>(newAccount);
        }
    }
}
