using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Domain.Domain.Accounts;
using Boxfusion.Health.His.Admissions.Tests;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.BillingClassifications;
using Boxfusion.Health.His.Common.Domain.Domain.Accounts.Enum;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
///using NUnit.Framework;
using Shesha.Domain;
using Shesha.Enterprise.BankAccounts;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Admissions.Domain.Tests.Accounts
{
    //[SetUpFixture]
    public class AccountManager_Test : AdmissionsTestBase
    {
        private readonly AccountManager _accountManager;
        private readonly IRepository<HisHealthFacility, Guid> _hisHealthFacilityRepo;
        private const string EntityDoesnotExist = "There is no such an entity. Entity type:";
        //private HospitalAdmission hospitalAdmission;
        //private BillingClassification billingClassification;
        //private Guid facilityId;

        public AccountManager_Test()
        {
            _accountManager = Resolve<AccountManager>();
            _facilityRepository = Resolve<IRepository<HisHealthFacility, Guid>>();
        }

        //[SetUp]
        //public async Task RunBeforeAnyTests()
        //{
        //    //Arrange
        //    #region Arrange: Get Hospital Admission and Billing Classification and facilityId
        //    facilityId = Guid.Parse("9809088E-EE28-4DF7-A8CF-074F130F9B72");
        //    hospitalAdmission = await GetTestData_HospitalAdmissionAsync(Guid.Parse("BCBDE18A-225F-42A4-AF33-79DF79FBD4D0"));
        //    billingClassification = await GetTestData_BillingClassificationAsync(Guid.Parse("041754b8-230c-4434-adc2-76a4c9f9f849"));
        //    #endregion
        //}

        [Fact]
        public async Task Should_be_able_to_update_a_hospital_admission()
        {
            using (var uow = _uowManager.Begin())
            {
                //Arrange
                var hospitalAdmission = await GetTestData_HospitalAdmissionAsync(Guid.Parse("BCBDE18A-225F-42A4-AF33-79DF79FBD4D0"));
                var billingClassification = await GetTestData_BillingClassificationAsync(Guid.Parse("041754b8-230c-4434-adc2-76a4c9f9f849"));

                //Act
                var updatedHospitalAdmission = await _accountManager.UpdateHospitalAdmissionBillingClassification(hospitalAdmission, billingClassification);
                
                //Assert
                updatedHospitalAdmission.BillingClassification.ShouldBe(billingClassification);
                
                await uow.CompleteAsync();
            }
        }

        [Fact]
        public async Task Should_be_able_to_create_a_visit_account()
        {
            using (var uow = _uowManager.Begin())
            {
                //Arrange
                var facilityId = Guid.Parse("9809088E-EE28-4DF7-A8CF-074F130F9B72");
                var hospitalAdmission = await GetTestData_HospitalAdmissionAsync(Guid.Parse("BCBDE18A-225F-42A4-AF33-79DF79FBD4D0"));
                var billingClassification = await GetTestData_BillingClassificationAsync(Guid.Parse("041754b8-230c-4434-adc2-76a4c9f9f849"));
                var healthFacility = await GetTestData_HisHealthFacilityAsync(Guid.Parse("9809088E-EE28-4DF7-A8CF-074F130F9B72"));
                var name = $"({hospitalAdmission.Subject.FullName} - {UtilityHelper.GetRefListItemText("His", "BillingClassificationType", billingClassification.ClassificationType.Value)} ({billingClassification?.DefaultPayor?.Name}))";

                //Act
                var newAccount = await _accountManager.CreateAccount(facilityId, hospitalAdmission, billingClassification);

                //Assert
                newAccount.AccountStatus.ShouldBe((long)AccountStatus.Active);
                newAccount.AccountType.ShouldBe((long)AccountType.Patient);
                newAccount.Name.ShouldBe(name);
                newAccount.Subject.ShouldBe(hospitalAdmission.Subject);
                //newAccount.ServiceStartDate.ShouldBe(name) = DateTime.Now,
                newAccount.Owner.ShouldBe(healthFacility);
                newAccount.Encounter.ShouldBe(hospitalAdmission);
                
                await uow.CompleteAsync();
            }
        }

        [Fact]
        public async Task Should_be_able_to_throw_exception_if_facility_Id_not_pass_when_creating_account()
        {
            using (var uow = _uowManager.Begin())
            {
                //Arrange
                var facilityId = Guid.Parse("9809088E-EE28-4DF7-A8CF-074F130F9B72");
                var hospitalAdmission = await GetTestData_HospitalAdmissionAsync(Guid.Parse("BCBDE18A-225F-42A4-AF33-79DF79FBD4D0"));
                var billingClassification = await GetTestData_BillingClassificationAsync(Guid.Parse("041754b8-230c-4434-adc2-76a4c9f9f849"));
                var healthFacility = await GetTestData_HisHealthFacilityAsync(Guid.Parse("9809088E-EE28-4DF7-A8CF-074F130F9B72"));
                var name = $"({hospitalAdmission.Subject.FullName} - {UtilityHelper.GetRefListItemText("His", "BillingClassificationType", billingClassification.ClassificationType.Value)} ({billingClassification?.DefaultPayor?.Name}))";

                //Act and Assert
                await Assert.ThrowsAsync<EntityNotFoundException> (async () => await _accountManager.CreateAccount(Guid.Empty, hospitalAdmission, billingClassification));
            }
        }

        [Fact]
        public async Task Should_be_able_to_create_coverage_and_linkages()
        {
            using (var uow = _uowManager.Begin())
            {
                try
                {
                    //Arrange
                    var bankAccount = new BankAccount()
                    {
                        Id = Guid.NewGuid(),
                        Bank = RefListBank.ABSA,
                        AccountType = RefListBankAccountType.CurrentAccount,
                        AccountNumber = "123456789",
                        BranchCode = "051001"
                    };

                    var facilityId = Guid.Parse("9809088E-EE28-4DF7-A8CF-074F130F9B72");
                    var hospitalAdmission = await GetTestData_HospitalAdmissionAsync(Guid.Parse("BCBDE18A-225F-42A4-AF33-79DF79FBD4D0"));
                    var billingClassification = await GetTestData_BillingClassificationAsync(Guid.Parse("041754b8-230c-4434-adc2-76a4c9f9f849"));
                    var newAccount = await _accountManager.CreateAccount(facilityId, hospitalAdmission, billingClassification);


                    //Act
                    await _accountManager.CreateCoverage(hospitalAdmission.Subject, billingClassification, newAccount,
                        bankAccount, 1, null, null);

                    //Assert
                    Assert.True(true);
                }
                catch
                {
                    //Assert
                    Assert.True(false);
                }

            }
         }
    }
}
