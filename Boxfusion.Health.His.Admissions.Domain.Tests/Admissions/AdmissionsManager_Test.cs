using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Boxfusion.Health.His.Admissions.Tests;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Admissions.Domain.Tests.Admissions
{
	public class AdmissionsManager_Test: AdmissionsTestBase
	{
		private readonly AdmissionsManager _admissionsManager;
		private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmission;

		public AdmissionsManager_Test(): base()
		{
			CreateTestData_HealthFacility_And_Ward("UnitTest Hospital", "UnitTest Ward");
			_admissionsManager = Resolve<AdmissionsManager>();
			_hospitalAdmission = Resolve<IRepository<HospitalAdmission, Guid>>();
		}

		[Fact]
		public async Task Should_be_able_to_make_new_patientient_admission_and_make_diagnosis_with_codes()
		{
			HisPatient patient = null;
			WardAdmission admission = null;
			Diagnosis diagnosis = null;
			try
			{
				#region Prepare data for running test
				var hospital = await GetTestData_HealthFacility("UnitTest Hospital");
				var ward = await GetTestData_Ward("UnitTest Ward");

				patient = await CreateTestData_NewPatient("John Smith" + ":Test1");
				var practitioner = await GetCurrentLoggedInPerson();

				var codes = await GetTestData_CodesList();

				var hospitalAdmission = new HospitalAdmission()
				{
					ServiceProvider = hospital,
					Subject = patient,
					Performer = practitioner,
					HospitalAdmissionNumber = "UnitTest: 12345",
					StartDateTime = DateTime.Now,
					HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted,
					Classification = RefListClassifications.h0 | RefListClassifications.h1 | RefListClassifications.h2 | RefListClassifications.h3
									| RefListClassifications.hg | RefListClassifications.pf | RefListClassifications.pg
									| RefListClassifications.ph | RefListClassifications.ws,
					OtherCategory = RefListOtherCategories.burnWounds | RefListOtherCategories.cancellations | RefListOtherCategories.dayPatients
									| RefListOtherCategories.gunshot | RefListOtherCategories.lodgers | RefListOtherCategories.maternalDeaths
									| RefListOtherCategories.mva | RefListOtherCategories.prisoner | RefListOtherCategories.stabWounds,
				};

				var wardAdmission = new WardAdmission()
				{
					Subject = patient,
					Performer = practitioner,
					Ward = ward,
					ServiceProvider = hospital,
					StartDateTime = DateTime.Now,
					WardAdmissionNumber = "UnitTest: 12345",
					AdmissionType = RefListAdmissionTypes.normalAdmission,
					AdmissionStatus = RefListAdmissionStatuses.admitted
				};
				#endregion

				var flag = await _admissionsManager.IsBedStillAvailable(ward.Id);
				flag.ShouldBe(true);

				using var uow = _uowManager.Begin();
				admission = await _admissionsManager.AdmitPatientAsync(wardAdmission, hospitalAdmission, codes);
				await uow.CompleteAsync();

				#region Assert verify patient is admitted
				//Check if admitted into hospital
				admission.PartOf.Id.ShouldNotBe(Guid.Empty);

				//Check if admitted into ward
				admission.Id.ShouldNotBe(Guid.Empty);
				admission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);

				//Check if diagnosis was made for admission
				diagnosis = await GetTestData_AdmissionDiagnosis(admission, RefListEncounterDiagnosisRoles.AD);
				diagnosis.ShouldNotBe(null);

				//Check if ConditionIcdTenCode assigments was made
				var assignments = await GetTestData_IcdTenCodesAssignments(diagnosis.Condition);
				assignments.Count.ShouldBe(2); //Checks for two since test-data always use random two codes
				#endregion
			}
			finally
			{
				CleanUpTestData_PatientAdmission(admission, diagnosis);
				CleanUpTestData_Patient(patient.Id);
			}
		}

		[Fact]
		public async Task Should_be_able_to_update_an_admissions_details()
		{
			HisPatient patient = null;
			WardAdmission updatedAdmission = null;
			Diagnosis diagnosis = null;
			try
			{
				#region Arrange: Prepare data for running update-test
				var hospital = await GetTestData_HealthFacility("UnitTest Hospital");
				var ward = await GetTestData_Ward("UnitTest Ward");

				patient = await CreateTestData_NewPatient("John Smith" + ":Test2");
				var practitioner = await GetCurrentLoggedInPerson();

				var codes = await GetTestData_CodesList();

				var admission = await CreateTestData_NewAdmission(hospital.Id, ward.Id);
				admission.ShouldNotBeNull();
				UpdateAdmissionValues(admission);
				admission.Performer = practitioner;
				admission.Subject = patient;

				var hospitalAdmission = (HospitalAdmission)admission.PartOf;
				hospitalAdmission.HospitalAdmissionNumber = "UnitTest: 12345Update";
				#endregion

				//Act
				using var uow = _uowManager.Begin();
				updatedAdmission = await _admissionsManager.UpdateAsync(admission, hospitalAdmission, codes);
				await uow.CompleteAsync();

				#region Assert: Verify if admission is updated
				//Check if hospitalAdmission was updated
				updatedAdmission.ShouldNotBeNull();
				var updatedHospitalAdmission = await _hospitalAdmission.GetAsync(updatedAdmission.PartOf.Id);
				updatedHospitalAdmission.HospitalAdmissionNumber.ShouldBe("UnitTest: 12345Update");

				//Check if wardAdmission was updated
				updatedAdmission.WardAdmissionNumber.ShouldBe("UnitTest: 12345Update");
				updatedAdmission.AdmissionType = RefListAdmissionTypes.internalTransferIn;

				//Check if diagnosis was made for admission
				diagnosis = await GetTestData_AdmissionDiagnosis(updatedAdmission, RefListEncounterDiagnosisRoles.AD);
				diagnosis.ShouldNotBe(null);

				//Check if ConditionIcdTenCode assigments was made
				var assignments = await GetTestData_IcdTenCodesAssignments(diagnosis.Condition);
				var updatedCodes = assignments.Select(a => a.IcdTenCode).ToList();
				updatedCodes.ForEach(code =>
				{
					var flag = codes.Any(a => a.Id == code.Id);
					flag.ShouldBe(true);
				});
				#endregion
			}
			finally
			{
				CleanUpTestData_PatientAdmission(updatedAdmission, diagnosis);
				CleanUpTestData_Patient(patient.Id);
			}
		}

		[Fact]
		public async Task Should_be_able_to_separate_patient_and_make_internal_transfer()
		{
			HisPatient patient = null;
			WardAdmission transferedAdmission = null;
			Diagnosis diagnosis = null;
			try
			{
				#region Arrange: Prepare data for running patient seperation
				var hospital = await GetTestData_HealthFacility("UnitTest Hospital");
				var ward = await GetTestData_Ward("UnitTest Ward");

				patient = await CreateTestData_NewPatient("John Smith" + ":Test3");
				var practitioner = await GetCurrentLoggedInPerson();

				var codes = await GetTestData_CodesList();

				var admission = await CreateTestData_NewAdmission(hospital.Id, ward.Id);
				admission.ShouldNotBeNull();
				admission.Performer = practitioner;
				admission.Subject = patient;

				var hospitalAdmission = (HospitalAdmission)admission.PartOf;
				hospitalAdmission.HospitalAdmissionNumber = "UnitTest: 12345Update";
				#endregion


			}
			catch (Exception)
			{
				throw;
			}
		}

		private static void UpdateAdmissionValues(WardAdmission admission)
		{
			admission.StartDateTime = DateTime.Now;
			admission.WardAdmissionNumber = "UnitTest: 12345Update";
			admission.AdmissionType = RefListAdmissionTypes.internalTransferIn;
			admission.AdmissionStatus = RefListAdmissionStatuses.admitted;
		}
	}
}
