using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Tests;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using Shesha.AutoMapper.Dto;
using Shesha.DynamicEntities.Dtos;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Admissions.Domain.Tests.Admissions
{
    public class AdmissionsFlow_Test : AdmissionManagementTestBase
    {
        public AdmissionsFlow_Test() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_admit_patient_to_ward()
        {
            var wardAdmission = new WardAdmission();
            try
            {
                using var uow = _uowManager.Begin();

                wardAdmission = await AdmitPatient_To_Ward();

                // The Admission status should be admitted
                wardAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);

                //Test if it created a hospital admission.

                await uow.CompleteAsync();
            }
            finally
            {
                // Clean-up Generated data
                //CleanUpTestData_Patient((Guid)wardAdmission.Subject.Id);
                //CleanUpTestData_Ward(wardAdmission.Ward.Id);
                //CleanUpTestData_HospitalAdmission(wardAdmission.Ward.OwnerOrganisation.Id);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Fact]
        //public async Task Should_transfer_patient_from_one_ward_to_another()
        //{
        //    var wardAdmission = new WardAdmission();
        //    var admissionInput = await BuildadmissionInput();

        //    try
        //    {
        //        using var uow = _uowManager.Begin();

        //        // The Admission status should be admitted
        //        //wardAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);

        //        //Test if it created a hospital admission.

        //        await uow.CompleteAsync();
        //    }
        //    finally
        //    {
        //        // Clean-up Generated data
        //        CleanUpTestData_Patient((Guid)admissionInput.Subject.Id);
        //        CleanUpTestData_Ward(wardAdmission.Ward.Id);
        //        CleanUpTestData_HospitalAdmission(wardAdmission.Ward.OwnerOrganisation.Id);

        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Fact]
        //public async Task Should_accept_or_reject_transfered_patient_from_one_ward_to_another()
        //{
        //    try
        //    {
        //        using var uow = _uowManager.Begin();
        //        var acceptOrRejectTransfersInput = new AcceptOrRejectTransfersInput()
        //        {
        //            AcceptanceDecision = RefListAcceptanceDecision.Accept,
        //            //WardAdmissionId = 
        //        };
        //        var accept = await _admissionsService.AcceptOrRejectTransfers(acceptOrRejectTransfersInput);

        //        acceptOrRejectTransfersInput.AcceptanceDecision = RefListAcceptanceDecision.Reject;
        //        acceptOrRejectTransfersInput.TransferRejectionReason = RefListTransferRejectionReasons.other;
        //        acceptOrRejectTransfersInput.TransferRejectionReasonComment = "Comment";

        //        var reject = await _admissionsService.AcceptOrRejectTransfers(acceptOrRejectTransfersInput);

        //        await uow.CompleteAsync();
        //    }
        //    finally
        //    {
        //        // Clean-up Generated data

        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Fact]
        //public async Task Should_separate_transfered_patient_from_one_ward_to_another()
        //{
        //    try
        //    {
        //        using var uow = _uowManager.Begin();

        //        var separationDto = new SeparationDto()
        //        {

        //        };
        //        var separatedPatient = await _admissionsService.SeparatePatientAsync(separationDto);


        //        await uow.CompleteAsync();
        //    }
        //    finally { }
        //}
    }
}
