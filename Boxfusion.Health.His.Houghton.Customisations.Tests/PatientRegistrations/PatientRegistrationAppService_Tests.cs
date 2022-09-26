using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.His.Admissions.Domain.Domain.RefLists;
using Boxfusion.Health.His.Admissions.PatientRegistrations;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Hougton.Tests;
using Shesha.Domain.Enums;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boxfusion.Health.His.Admissions.Application.Tests.PatientRegistrations
{
	public class PatientRegistrationAppService_Tests: HisAdmissionsApplicationTestBase
	{
		private readonly PatientRegistrationAppService _patientRegistrationAppService;
		private readonly IRepository<HisPatient, Guid> _patientRegistrationsRepository;
		private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepository;

		public PatientRegistrationAppService_Tests(): base()
		{
			_patientRegistrationAppService = Resolve<PatientRegistrationAppService>();
			_patientRegistrationsRepository = Resolve<IRepository<HisPatient, Guid>>();
			_hospitalAdmissionRepository = Resolve<IRepository<HospitalAdmission, Guid>>();
		}

		[Fact]
		public async Task Should_Register_Patien_Demographics_and_Create_HospitalAdmission_as_Draft()
		{
			HisPatient patient = null;
			#region Prepare patient registration data
			var input = new RegisterPatientDto ()
			{
				RegistrationType = 1,
				PatientType = (long?)RefListPatientType.paediatric,
				IdentificationType = (long?)RefListIdentificationTypes.SAID,
				IdentityNumber = "0123456789987",
				LastName = "Spector",
				FirstName = "Harvey",
				MiddleName = "Gabriel",
				DateOfBirth = DateTime.Today,
				Gender = (long?)RefListGender.Male,
				Ethnicity = 1,
				CommunicationLanguage = new List<long>() { 1 },
				MaritalStatus = (long?)RefListMaritalStatus.A,
				CellNumber = "012345679",
				AlternativeNumber = "9876543210",
				PatientProvince = (long?)RefListProvinces.WesternCape,
				ResidentialAddress = "UnitTest: Address",
				SecondResidentialAddress = "UnitTest: 2nd Address",
				EmailAddress = "unitTest@email.com",
				Nationality = (long?)RefListCountries.Djibouti,
				Religion = (long?)RefListReligion.Islam,
				NumberOfDependents = 1,
				EducationLevel = (long?)RefListEducationLevel.Tertiarty,
				IsEmployed = true,
				Occupation = "Software",
				WorkAddress = "UnitTest: WorkAddress",
				SecondWorkAddress = "UnitTest: 2nd WorkAddress"
			};
			#endregion

			//Act: Register patient
			using var uow = _uowManager.Begin();
			var patientDto = await _patientRegistrationAppService.RegisterPatient(input);
			await uow.CompleteAsync();

			#region Assert: Verify is patient is registered and has draft hospitalAdmission
			//Check if patient exists
			patient = await _patientRegistrationsRepository.GetAsync(patientDto.Id);
			patient.ShouldNotBeNull();

			//Check if patient has a draft hospitalAdmission
			var admission = await _hospitalAdmissionRepository.FirstOrDefaultAsync(a => a.Subject.Id == patient.Id);
			admission.ShouldNotBeNull();
			admission.HospitalAdmissionStatus.ShouldBe(RefListHospitalAdmissionStatuses.draft);
			#endregion
		}
	}
}
