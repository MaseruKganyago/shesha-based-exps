using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Accounts;
using Boxfusion.Health.His.Admissions.Domain.Domain.Accounts;
using Boxfusion.Health.His.Admissions.Tests;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Accounts;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.BillingClassifications;
using Boxfusion.Health.His.Common.Domain.Domain.Accounts.Enum;
using Boxfusion.Health.His.Common.Domain.Domain.BillingClassifications.Enum;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
//using NUnit.Framework;
using Shesha.AutoMapper.Dto;
///using NUnit.Framework;
using Shesha.Domain;
using Shesha.Enterprise.Accounts;
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
    public class AccountManager_Test : AdmissionsTestBase
    {
        private readonly AccountManager _accountManager;
        private const string EntityDoesnotExist = "There is no such an entity. Entity type:";

        public AccountManager_Test()
        {
            _accountManager = Resolve<AccountManager>();
        }

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
                var serviceStartDate = DateTime.Now;
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
                //newAccount.ServiceStartDate.ShouldBe(serviceStartDate);
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

        //[Fact]
        //public async Task Should_be_able_to_create_coverage_and_linkages()
        //{
        //    using (var uow = _uowManager.Begin())
        //    {
        //        try
        //        {
        //            //Arrange
        //            var bankAccount = new BankAccount()
        //            {
        //                Id = Guid.NewGuid(),
        //                Bank = RefListBank.ABSA,
        //                AccountType = RefListBankAccountType.CurrentAccount,
        //                AccountNumber = "123456789",
        //                BranchCode = "051001"
        //            };

        //            var facilityId = Guid.Parse("9809088E-EE28-4DF7-A8CF-074F130F9B72");
        //            var hospitalAdmission = await GetTestData_HospitalAdmissionAsync(Guid.Parse("BCBDE18A-225F-42A4-AF33-79DF79FBD4D0"));
        //            var billingClassification = await GetTestData_BillingClassificationAsync(Guid.Parse("041754b8-230c-4434-adc2-76a4c9f9f849"));
        //            var newAccount = await _accountManager.CreateAccount(facilityId, hospitalAdmission, billingClassification);


        //            //Act
        //            await _accountManager.CreateCoverage(hospitalAdmission.Subject, billingClassification, newAccount,
        //                bankAccount, 1, null, null);

        //            //Assert
        //            Assert.True(true);
        //        }
        //        catch
        //        {
        //            //Assert
        //            Assert.True(false);
        //        }

        //    }
        // }

       

        //public static IEnumerable<TestCaseData> CountEqualsZeroAndHouseGrossIsGreaterTestCases
        //{   
        //    get
        //    {
        //        var input = new SetPaymentInput()
        //        {
        //            BillingClassificationId = Guid.Parse("AB0626EC-15E6-42CC-8099-01D5C37A6CC9"),
        //            SelectedMedicalAidCoverageId = Guid.Parse("09FF141D-A2A3-4DA0-B223-17B945D04FC4"),
        //            HospitalAdmissionId = Guid.Parse("432A2FC2-9A27-46BF-B397-00AEF30559DD"),
        //            CashPayerType = 2,
        //            BankAccount = new BankAccountInput
        //            {
        //                Bank = new ReferenceListItemValueDto() { ItemValue = 1 },
        //                AccountType = new ReferenceListItemValueDto() { ItemValue = 1 },
        //                AccountNumber = "62123243363",
        //            },
        //            Selected3rdPartyCoverageId = Guid.Parse("3950FE32-2B83-47E7-9EC0-1E93644656EF"),
        //        };
        //        yield return new TestCaseData(input);
        //        yield return new TestCaseData(new SetPaymentInput(), report.Merchants[4268435971532164].LineItem["EBTPerItem"], 4268435971532164, "EBTPerItem").SetName("ReportMerchantsLineItem");
        //        yield return new TestCaseData(report, report.Merchants[5461324658456716].AggregateTotals, 5461324658456716, "WirelessPerItem").SetName("ReportMerchantsAggregateTotals");
        //        yield return new TestCaseData(report, report.AggregateTotals, null, "AggregateTotals").SetName("ReportAggregateTotals");
        //        yield return new TestCaseData(report, report.AggregateTotals.LineItem["WirelessPerItem"], null, "WirelessPerItem").SetName("ReportAggregateTotalsLineItem");
        //    }
        //}

        //[Fact]
        //public async Task<Guid> Should_be_able_to_setpayment(SetPaymentInput input)
        //{
        //    //CreateCoverage(Patient patient, BillingClassification billingClassification, HisAccount account,
        //    //BankAccount bankAccount, int cashPayerType, Guid ? selectedMedicalAidCoverageId, Guid ? selected3rdPartyCoverageId);

        //    input = new SetPaymentInput()
        //    {
        //        BillingClassificationId = Guid.Parse("AB0626EC-15E6-42CC-8099-01D5C37A6CC9"),
        //        SelectedMedicalAidCoverageId = Guid.Parse("09FF141D-A2A3-4DA0-B223-17B945D04FC4"),
        //        HospitalAdmissionId = Guid.Parse("432A2FC2-9A27-46BF-B397-00AEF30559DD"),
        //        CashPayerType = 2,
        //        BankAccount = new BankAccountInput
        //        {
        //            Bank = new ReferenceListItemValueDto() { ItemValue = 1},
        //            AccountType = new ReferenceListItemValueDto() { ItemValue = 1 },
        //            AccountNumber = "62123243363",
        //        },
        //        Selected3rdPartyCoverageId = Guid.Parse("3950FE32-2B83-47E7-9EC0-1E93644656EF"),
        //    };
        //}
    }

    public static class SetPaymentTestCases
    {
        public static List<SetPaymentInput> GetAllSetPaymentTestCasesHappyScenarios
        {
            get
            {
                return new List<SetPaymentInput>() {
                    new SetPaymentInput()
                                {
                                    BillingClassificationId = Guid.Parse("AB0626EC-15E6-42CC-8099-01D5C37A6CC9"),
                                    SelectedMedicalAidCoverageId = Guid.Parse("09FF141D-A2A3-4DA0-B223-17B945D04FC4"),
                                    HospitalAdmissionId = Guid.Parse("3F8DAD73-A2CE-4C32-9D7F-065C29619A3A"),
                                    CashPayerType = 2,
                                    BankAccount = new BankAccountInput
                                    {
                                        Bank = new ReferenceListItemValueDto() { ItemValue = 1},
                                        AccountType = new ReferenceListItemValueDto() { ItemValue = 1 },
                                        AccountNumber = "62123243363",
                                    },
                                    Selected3rdPartyCoverageId = Guid.Parse("3950FE32-2B83-47E7-9EC0-1E93644656EF"),
                                },
                    new SetPaymentInput()
                                {
                                    BillingClassificationId = Guid.Parse("AB0626EC-15E6-42CC-8099-01D5C37A6CC9"),
                                    SelectedMedicalAidCoverageId = null,
                                    HospitalAdmissionId = Guid.Parse("3F8DAD73-A2CE-4C32-9D7F-065C29619A3A"),
                                    CashPayerType = 0,
                                    BankAccount = null,
                                    Selected3rdPartyCoverageId = null,
                                },
                    new SetPaymentInput()
                                {
                                    BillingClassificationId = Guid.Parse("AB0626EC-15E6-42CC-8099-01D5C37A6CC9"),
                                    SelectedMedicalAidCoverageId = Guid.Parse("09FF141D-A2A3-4DA0-B223-17B945D04FC4"),
                                    HospitalAdmissionId = Guid.Parse("3F8DAD73-A2CE-4C32-9D7F-065C29619A3A"),
                                    CashPayerType = 1,
                                    BankAccount = new BankAccountInput
                                    {
                                        Bank = new ReferenceListItemValueDto() { ItemValue = 1},
                                        AccountType = new ReferenceListItemValueDto() { ItemValue = 1 },
                                        AccountNumber = "62123243363",
                                    },
                                    Selected3rdPartyCoverageId = Guid.Parse("3950FE32-2B83-47E7-9EC0-1E93644656EF"),
                                },
            };


            }

        }
    }
}
