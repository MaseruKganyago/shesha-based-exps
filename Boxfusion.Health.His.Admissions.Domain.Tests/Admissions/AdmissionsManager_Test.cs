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

		public AdmissionsManager_Test(): base()
		{
			CreateTestData_HealthFacility_And_Ward("UnitTest Hospital", "UnitTest Ward");
			_admissionsManager = Resolve<AdmissionsManager>();
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

				using var uow = _uowManager.Begin();
				admission = await _admissionsManager.AdmitPatientAsync(wardAdmission, hospitalAdmission, codes);
				await uow.CompleteAsync();

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
			}
			finally
			{
				CleanUpTestData_PatientAdmission(admission, diagnosis);
				CleanUpTestData_Patient(patient.Id);
			}
		}
	}
}
