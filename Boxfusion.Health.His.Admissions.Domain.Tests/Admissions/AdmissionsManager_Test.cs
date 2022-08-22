using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Boxfusion.Health.His.Admissions.Tests;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Domain.Domain.Admissions;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Admissions.Domain.Tests.Admissions
{
    public class AdmissionsManager_Test: AdmissionsTestBase
	{
		private readonly AdmissionsManager _admissionsManager;
		private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepository;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;

		public AdmissionsManager_Test(): base()
		{
			CreateTestData_HealthFacility_And_Ward("UnitTest Hospital", "UnitTest Ward");
			_admissionsManager = Resolve<AdmissionsManager>();
			_hospitalAdmissionRepository = Resolve<IRepository<HospitalAdmission, Guid>>();
			_wardAdmissionRepository = Resolve<IRepository<WardAdmission, Guid>>();
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

				//Act
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
				assignments.Count.ShouldBe(2); //Checks for two since test-data always use two random codes
				#endregion
			}
			finally
			{
				await CleanUpTestData_PatientAdmission(admission, diagnosis);
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
				var updatedHospitalAdmission = await _hospitalAdmissionRepository.GetAsync(updatedAdmission.PartOf.Id);
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
				await CleanUpTestData_PatientAdmission(updatedAdmission, diagnosis);
				CleanUpTestData_Patient(patient.Id);
			}
		}

		[Fact]
		public async Task Should_be_able_to_separate_patient_and_make_internal_transfer()
		{
			HisPatient patient = null;
			WardAdmission separatedAdmission = null;
			WardAdmission transferedAdmission = null;
			Diagnosis diagnosis = null;
			Diagnosis transfererdAdmissionDiagnosis = null;
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

				var nextWard = CreateTestData_Ward("UnitTest Ward B", hospital);
				TransferPatientValues(admission, hospital, nextWard);

				diagnosis = await GetTestData_AdmissionDiagnosis(admission, RefListEncounterDiagnosisRoles.AD);
				#endregion

				//Act
				using var uow = _uowManager.Begin();
				separatedAdmission = await _admissionsManager.SeparatePatientAsync(admission, hospitalAdmission, codes);
				await uow.CompleteAsync();

				#region Assert: Verify if patient is separated and admitted in new ward
				//Check if patient is separated from previous ward
				separatedAdmission.Subject.Id.ShouldBe(patient.Id);
				separatedAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.separated);

				var transferedList = await _wardAdmissionRepository.GetAllListAsync(a => a.InternalTransferOriginalWard.Id
																	== separatedAdmission.Id);
				transferedAdmission = transferedList.FirstOrDefault();

				//Check that admitted to the next ward
				transferedAdmission.Ward.Id.ShouldBe(nextWard.Id);

				//Check that newAdmission is inTransit
				transferedAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.inTransit);

				//Check that newAdmission is still in the current hospitalAdmission
				transferedAdmission.PartOf.Id.ShouldBe(hospitalAdmission.Id);

				//Check if diagnosis was made for new internalTransfer admission
				transfererdAdmissionDiagnosis = await GetTestData_AdmissionDiagnosis(transferedAdmission, RefListEncounterDiagnosisRoles.AD);
				transfererdAdmissionDiagnosis.ShouldNotBe(null);

				//Check if ConditionIcdTenCode assigments was made
				var assignments = await GetTestData_IcdTenCodesAssignments(transfererdAdmissionDiagnosis.Condition);
				assignments.Count.ShouldBe(2); //Checks for two since test-data always use two random codes
				#endregion
			}
			finally
			{
				await CleanUpTestData_PatientAdmission(transferedAdmission, transfererdAdmissionDiagnosis, false);
				await CleanUpTestData_PatientAdmission(separatedAdmission, diagnosis);
				CleanUpTestData_Patient(patient.Id);
			}
		}

		[Fact]
		public async Task Should_be_able_to_accept_internalTransfer_and_admit_patient_to_new_ward()
		{
			HisPatient patient = null;
			WardAdmission separatedAdmission = null;
			WardAdmission acceptOrRejectedAdmission = null;
			Diagnosis diagnosis = null;
			try
			{
				#region Arrange: Prepare data for running Accept or Reject tranfer test
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

				var nextWard = CreateTestData_Ward("UnitTest Ward B", hospital);
				TransferPatientValues(admission, hospital, nextWard);

				diagnosis = await GetTestData_AdmissionDiagnosis(admission, RefListEncounterDiagnosisRoles.AD);

				using var uow = _uowManager.Begin();
				separatedAdmission = await _admissionsManager.SeparatePatientAsync(admission, hospitalAdmission, codes);
				await uow.CompleteAsync();

				var transferedList = await _wardAdmissionRepository.GetAllListAsync(a => a.InternalTransferOriginalWard.Id
																	== separatedAdmission.Id);
				var transferedAdmission = transferedList.FirstOrDefault();
				#endregion

				#region Act: Accept or Reject transfer
				//acceptOrRejectedAdmission = await _admissionsManager.AcceptOrRejectTransfers(RefListAcceptanceDecision.Accept, transferedAdmission);

				acceptOrRejectedAdmission = await _admissionsManager.AcceptOrRejectTransfers(RefListAcceptanceDecision.Reject,
																	transferedAdmission, RefListTransferRejectionReasons.noAvailability, "UnitTest: Reason");
				#endregion

				#region Assert: Verify if admission was Accepected or Rejected
				//-----On accepected------
				//Veirify that transferedAdmission is admitted
				//acceptOrRejectedAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);

				////Verify that transferedAdmission admissionType is internalTransfer
				//acceptOrRejectedAdmission.AdmissionType.ShouldBe(RefListAdmissionTypes.internalTransferIn);

				//-----On Rejected------
				//Veirify that transferedAdmission is rejected
				acceptOrRejectedAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.rejected);

				//Verify original wardAdmission is re-admitted
				var originalWard = await _wardAdmissionRepository.GetAsync(separatedAdmission.Id);
				originalWard.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);
				#endregion
			}
			finally
			{
				var transfererdAdmissionDiagnosis = await GetTestData_AdmissionDiagnosis(acceptOrRejectedAdmission, RefListEncounterDiagnosisRoles.AD);
				await CleanUpTestData_PatientAdmission(acceptOrRejectedAdmission, transfererdAdmissionDiagnosis, false);
				await CleanUpTestData_PatientAdmission(separatedAdmission, diagnosis);
				CleanUpTestData_Patient(patient.Id);
			}
		}

		[Fact]
		public async Task Should_be_able_to_undo_a_separation_and_re_admit_patient_in_ward()
		{
			HisPatient patient = null;
			WardAdmission separatedAdmission = null;
			Diagnosis diagnosis = null;
			try
			{
				#region Arrange: Prepare data for running Accept or Reject tranfer test
				var hospital = await GetTestData_HealthFacility("UnitTest Hospital");
				var ward = await GetTestData_Ward("UnitTest Ward");

				patient = await CreateTestData_NewPatient("John Smith" + ":Test3");
				var practitioner = await GetCurrentLoggedInPerson();

				var codes = await GetTestData_CodesList();

				//Admission in ward
				var admission = await CreateTestData_NewAdmission(hospital.Id, ward.Id);
				admission.ShouldNotBeNull();
				admission.Performer = practitioner;
				admission.Subject = patient;

				//Admission in hospital
				var hospitalAdmission = (HospitalAdmission)admission.PartOf;

				//Separation values
				admission.SeparationType = RefListSeparationTypes.dischargeNormal;
				admission.SeparationDate = DateTime.UtcNow.AddHours(2);
				admission.SeparationComment = "UnitTest separation";

				diagnosis = await GetTestData_AdmissionDiagnosis(admission, RefListEncounterDiagnosisRoles.AD);
				#endregion

				//Act
				using var uow = _uowManager.Begin();
				separatedAdmission = await _admissionsManager.SeparatePatientAsync(admission, hospitalAdmission, codes);

				var reAdmission = await _admissionsManager.UndoSeparation(separatedAdmission.Id, practitioner);
				await uow.CompleteAsync();

				// Assert: Verify if patient is re-admitted
				reAdmission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);
			}
			finally
			{
				await CleanUpTestData_PatientAdmission(separatedAdmission, diagnosis);
				CleanUpTestData_Patient(patient.Id);
			}
		}

		private void TransferPatientValues(WardAdmission admission, HisHealthFacility hospital, HisWard nextWard)
		{
			admission.SeparationType = RefListSeparationTypes.internalTransfer;
			admission.SeparationDestinationWard = nextWard;
			admission.SeparationDate = DateTime.UtcNow.AddHours(2);
			admission.SeparationComment = "UnitTest transfer";
			admission.ServiceProvider = hospital;
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
