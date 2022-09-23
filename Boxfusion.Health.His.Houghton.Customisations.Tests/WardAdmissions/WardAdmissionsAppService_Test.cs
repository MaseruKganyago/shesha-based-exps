using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Boxfusion.Health.His.Admissions.WardAdmissions;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Hougton.Tests;
using GraphQL;
using Shesha.AutoMapper.Dto;
using Shesha.DynamicEntities.Dtos;
using Shesha.Enterprise.Sequences;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Admissions.Application.Tests.WardAdmissions
{
	public class WardAdmissionsAppService_Test: HisAdmissionsApplicationTestBase
	{
		private readonly WardAdmissionsAppService _wardAdmissionsAppService;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
		private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepositiory;

		public WardAdmissionsAppService_Test(): base()
		{
			CreateTestData_HealthFacility_And_Ward_With_RoomBed("UnitTest Hospital", "UnitTest Ward", "UnitTest Room", "UnitTest Bed");
			_wardAdmissionsAppService = Resolve<WardAdmissionsAppService>();
			_hospitalAdmissionRepositiory = Resolve<IRepository<HospitalAdmission, Guid>>();
			_wardAdmissionRepositiory = Resolve<IRepository<WardAdmission, Guid>>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Should_AdmitPatient_inWard_and_CreateDiagnosis_and_Notes()
		{
			HisPatient patient = null;
			WardAdmission admission = null;
			List<Diagnosis> diagnosis = null;
			try
			{
				#region Prepare data for running test
				var hospital = await GetTestData_HealthFacility("UnitTest Hospital");
				var ward = await GetTestData_Ward("UnitTest Ward");
				var room = await GetTestData_Room("UnitTest Room");
				var bed = await GetTestData_Bed("UnitTest Bed");

				patient = await CreateTestData_NewPatient("John Smith" + ":Test1");
				var practitioner = await GetCurrentLoggedInPerson();

				var conditions = await CreateTestData_Conditions(patient);
				var partOf = await _hospitalAdmissionRepositiory.InsertAsync(new HospitalAdmission()
				{
					RegistrationType = (long?)RefListRegistrationType.InPatient,
					Subject = patient,
					HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.admitted,
					//HospitalAdmissionNumber = GetAdmissionNumber()
				});

				var admitPatientInput = new WardAdmissionsDto()
				{
					Patient = patient.Id,
					Ward = new EntityWithDisplayNameDto<Guid>(ward.Id, ward.Name),
					Room = new EntityWithDisplayNameDto<Guid>(room.Id, ward.Name),
					Bed = new EntityWithDisplayNameDto<Guid>(bed.Id, bed.Name),
					AdmissionDate = DateTime.Now,
					AdmissionType = new ReferenceListItemValueDto() { ItemValue = (long?)RefListAdmissionTypes.normalAdmission },
					Conditions = conditions.Select(a => a.Id).ToList(),
					AdmissionNotes = "UnitTest Admission Note",
					PartOf = partOf.Id
				};
				#endregion

				//Act
				using var uow = _uowManager.Begin();
				var admissionDto = await _wardAdmissionsAppService.AdmitPatientAsync(admitPatientInput);
				await uow.CompleteAsync();

				#region Assert verify patient is admitted
				admission = await _wardAdmissionRepositiory.GetAsync(admissionDto.Id);

				//Check if admitted into ward
				admission.Id.ShouldNotBe(Guid.Empty);
				admission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.admitted);

				//Check if diagnosis was made for admission
				diagnosis = await GetTestData_AdmissionDiagnosisList(admission, RefListEncounterDiagnosisRoles.AD);
				diagnosis.ShouldNotBe(null);

				//Check if ConditionIcdTenCode assigments was made
				var conditionList = diagnosis.Select(a => a.Condition).ToList();
				conditionList.ForEach(condition =>
				{
					var flag = conditions.Any(a => a.Id == condition.Id);
					flag.ShouldBe(true);
				});

				//Check if admission note was created
				var note = await GetTestData_Note(admission.Id.ToString());
				note.NoteText.ShouldBe(admitPatientInput.AdmissionNotes);
				#endregion
			}
			catch (Exception ex)
			{
				throw;
			}
			finally
			{
				await CleanUpTestData_PatientAdmission(admission);
				if (patient is not null) CleanUpTestData_Patient(patient.Id);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Should_Discharge_Patient_from_Ward_and_Hospital()
		{
			HisPatient patient = null;
			WardAdmission admission = null;
			try
			{
				#region Prepare data for test-discharge
				var hospital = await GetTestData_HealthFacility("UnitTest Hospital");
				var ward = await GetTestData_Ward("UnitTest Ward");
				patient = await CreateTestData_NewPatient("John Smith" + " :Test2");

				var admissionData = await CreateTestData_NewAdmission(hospital.Id, ward.Id);
				admissionData.ShouldNotBeNull();

				var dischargeInput = new WardDischargeDto()
				{
					Id = admissionData.Id,
					DischargeDate = DateTime.Now,
					DischargeNotes = "UnitTest Note",
					//Physician = new 
				};
				#endregion

				//Act: Discharge patient
				using var uwo = _uowManager.Begin();
				var admissionDto = await _wardAdmissionsAppService.DischargePatientAsync(dischargeInput);
				await uwo.CompleteAsync();

				#region Assert: Check if was discharged
				admission = await _wardAdmissionRepositiory.GetAsync(admissionDto.Id);
				admission.ShouldNotBeNull();

				//Verify wardAdmission was discharged
				admission.AdmissionStatus.ShouldBe(RefListAdmissionStatuses.separated);
				admission.EndDateTime?.ToString("MM/dd/yyyy HH:mm").ShouldBe(dischargeInput.DischargeDate.Value.ToString("MM/dd/yyyy HH:mm"));

				//Verify discharge note was created
				var note = await _noteRepository.FirstOrDefaultAsync(a => a.OwnerId == admission.Id.ToString());
				note.ShouldNotBeNull();
				note.NoteText.ShouldBe(dischargeInput.DischargeNotes);
				#endregion
			}
			catch (Exception ex)
			{
				if (admission is not null) await CleanUpTestData_PatientAdmission(admission);
				if (patient is not null) CleanUpTestData_Patient(patient.Id);
			}
			finally
			{
				await CleanUpTestData_PatientAdmission(admission);
				if (patient is not null) CleanUpTestData_Patient(patient.Id);
			}
		}

	}
}
