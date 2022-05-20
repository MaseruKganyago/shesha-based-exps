﻿using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Tests;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using Shesha.AutoMapper.Dto;
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
        public AdmissionsFlow_Test(): base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_admit_patient_to_ward()
        {
            //Get the created test Patient
            var patient = await CreateTestData_NewPatient("Bruce");
            //Creating the test data
            var admissionInput = new AdmissionInput()
            {
                Subject = new EntityWithDisplayNameDto<Guid?>()
                {
                    Id = patient.Id
                }
            };
            var wardAdmission = new WardAdmission();

            try
            {
                using var uow = _uowManager.Begin();
                wardAdmission = await AdmitPatient_To_Ward(admissionInput);
                 

                // The Admission status should be admitted
                wardAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);

                //Test if it created a hospital admission.

                await uow.CompleteAsync();
            }
            finally
            {
                // Clean-up Generated data
                CleanUpTestData_Patient(patient.Id);
                CleanUpTestData_Ward(wardAdmission.Ward.Id);
                CleanUpTestData_HospitalAdmission(wardAdmission.Ward.OwnerOrganisation.Id);
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_transfer_patient_from_one_ward_to_another()
        {

        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_reject_transfered_patient_from_one_ward_to_another()
        {

        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_accept_or_reject_transfered_patient_from_one_ward_to_another()
        {
            var acceptOrRejectTransfersInput = new AcceptOrRejectTransfersInput();
          
            try
            {
                using var uow = _uowManager.Begin();

                await _admissionsService.AcceptOrRejectTransfers(acceptOrRejectTransfersInput);
                await uow.CompleteAsync();
            }
            finally
            {
                // Clean-up Generated data
               
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_separate_transfered_patient_from_one_ward_to_another()
        {

        }
    }
}
