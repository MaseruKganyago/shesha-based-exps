using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.Domain.Domain.Room;
using Boxfusion.Health.His.Common.Patients;
using NHibernate.Transform;
using Shesha.Domain;
using Shesha.NHibernate;

namespace Boxfusion.Health.His.Hougton.Tests
{
    public class HougtonTestBase: SheshaNhTestBase
	{
        protected IRepository<HisHealthFacility, Guid> _facilityRepository;
        protected IRepository<HisPatient, Guid> _patientRepository;
        protected IRepository<HisWard, Guid> _wardRepository;
        protected IRepository<Diagnosis, Guid> _diagnosisRepository;
        protected IRepository<Bed, Guid> _bedRepository;
        protected IRepository<Room, Guid> _roomRepository;
        protected IRepository<Condition, Guid> _conditionRepository;
        protected IUnitOfWorkManager _uowManager;
        protected ISessionProvider _sessionProvider;

        public HougtonTestBase()
		{
            _facilityRepository = Resolve<IRepository<HisHealthFacility, Guid>>();
            _patientRepository = Resolve<IRepository<HisPatient, Guid>>();
            _wardRepository = Resolve<IRepository<HisWard, Guid>>();
            _diagnosisRepository = Resolve<IRepository<Diagnosis, Guid>>();
            _conditionRepository = Resolve<IRepository<Condition, Guid>>();
            _uowManager = Resolve<IUnitOfWorkManager>();
            _sessionProvider = Resolve<ISessionProvider>();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="wardName"></param>
		protected void CreateTestData_HealthFacility_And_Ward(string name, string wardName, string roomName, string bedName)
        {
            LoginAsHost("admin");

            // Checking if test data has previously been added
            var hostpital = _facilityRepository.FirstOrDefault(e => e.Name == name);
            if (hostpital is null)
            {
                using (var uow = _uowManager.Begin())
                {
                    var newHospital = new HisHealthFacility()
                    {
                        Name = name,
                    };
                    newHospital = _facilityRepository.Insert(newHospital);

                    var ward = CreateTestData_Ward(wardName, newHospital);
                    var room = CreateTestData_Room(roomName, ward);
                    CreateTestData_Bed(bedName, room);
					uow.Complete();
                }
            }
        }

        protected HisWard CreateTestData_Ward(string name, HisHealthFacility hospital)
        {
            var ward = _wardRepository.FirstOrDefault(a => a.Name == name);
            if (ward is null)
            {
                var newWard = new HisWard()
                {
                    Name = name,
                    OwnerOrganisation = hospital,
                    NumberOfBeds = 50
                };
                ward = _wardRepository.Insert(newWard);
            }

            return ward;
        }

        protected Room CreateTestData_Room(string name, HisWard ward)
        {
            var room = _roomRepository.FirstOrDefault(a => a.Name == name);
            if (room is null)
            {
                var newRoom = new Room()
                {
                    Name = name,
                    Ward = ward
                };
                room = _roomRepository.Insert(newRoom);
            }

            return room;
        }

        protected Bed CreateTestData_Bed(string name, Room room)
        {
            var bed = _bedRepository.FirstOrDefault(a => a.Name == name);
            if (bed is null)
            {
                var newBed = new Bed()
                {
                    Name = name,
                    Room = room
                };
                bed = _bedRepository.Insert(newBed);
            }

            return bed;
        }

		protected async Task<HisPatient> CreateTestData_NewPatient(string name)
		{
			HisPatient patient;

			using (var uow = _uowManager.Begin())
			{
				patient = new HisPatient()
				{
					FirstName = name,
					LastName = name
				};
				patient = await _patientRepository.InsertAsync(patient);

				uow.Complete();
			}

			return patient;
		}

        protected async Task<List<Condition>> CreateTestData_Conditions(HisPatient patient)
        {
            var codes = await GetTestData_CodesList();

            var tasks = new List<Task<Condition>>();
            codes.ForEach(code => tasks.Add(_conditionRepository.InsertAsync(new Condition() { Code = code, Subject = patient })));

            return (await Task.WhenAll(tasks)).ToList();
		}

		protected async Task<HisHealthFacility> GetTestData_HealthFacility(string name)
        {
            return await _facilityRepository.FirstOrDefaultAsync(e => e.Name == name);
        }

        protected async Task<HisWard> GetTestData_Ward(string name)
        {
            return await _wardRepository.FirstOrDefaultAsync(a => a.Name == name);
        }

        protected async Task<Room> GetTestData_Room(string name)
        {
            return await _roomRepository.FirstOrDefaultAsync(a => a.Name == name);
        }

        protected async Task<Bed> GetTestData_Bed(string name)
        {
            return await _bedRepository.FirstOrDefaultAsync(a => a.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Two random IcdTencodes as a List</returns>
        protected async Task<List<IcdTenCode>> GetTestData_CodesList()
        {
            using var session = OpenSession();
            var result = new List<IcdTenCode>();

            result = (await session.CreateSQLQuery(@"SELECT top(2) * FROM Fhir_IcdTenCodes order by NEWID()")
                                                .SetResultTransformer(Transformers.AliasToBean<IcdTenCode>())
                                                .ListAsync<IcdTenCode>()).ToList();
            session.Flush();

            return result;
        }

        protected async Task<Person> GetCurrentLoggedInPerson()
        {
            //LoginAsHost("admin");

            var personRepository = Resolve<IRepository<Person, Guid>>();
            Person person = null;

            using var uow = _uowManager.Begin();
            person = await personRepository.FirstOrDefaultAsync(p => p.User.Id == AbpSession.GetUserId());
            await uow.CompleteAsync();
            return person;
        }

        protected async Task<List<Diagnosis>> GetTestData_AdmissionDiagnosis(WardAdmission admission,
                                                                       RefListEncounterDiagnosisRoles encounterDiagnosisRoles)
        {
            return await _diagnosisRepository.GetAllListAsync(a => a.OwnerId == admission.Id.ToString()
                                                                  && a.Use == (int?)encounterDiagnosisRoles);
        }

        protected void CleanUpTestData_Patient(Guid patientId)
        {
            using var session = OpenSession();
            var query = session.CreateSQLQuery("DELETE FROM Core_Persons WHERE Id = '" + patientId.ToString() + "'");
            query.ExecuteUpdate();

            session.Flush();
        }

        protected async Task CleanUpTestData_PatientAdmission(WardAdmission admission, List<Diagnosis> diagnosisList, bool includePartOf = true)
        {
            using var session = OpenSession();
            var query = session.CreateSQLQuery($"Update Fhir_Conditions set FhirEncounterId = null where FhirEncounterId = '{admission.Id}'" +
                $"DELETE FROM Fhir_Encounters WHERE Id = '{admission.Id}'");
            query.ExecuteUpdate();

            if (includePartOf)
            {
                query = session.CreateSQLQuery($"Update Fhir_Conditions set HospitalisationEncounterId = null where HospitalisationEncounterId = '{admission.PartOf.Id}'" +
                $"DELETE FROM Fhir_Encounters WHERE Id = '{admission.PartOf.Id}'");
                query.ExecuteUpdate();
            }

            if (diagnosisList.Count > 1)
            {
                diagnosisList.ForEach(diagnosis =>
                {
                    DeleteDiagnosisCombo(diagnosis);
                });
            }

            session.Flush();
        }

		private void DeleteDiagnosisCombo(Diagnosis diagnosis)
		{
			using var session = OpenSession();
			var query = session.CreateSQLQuery($"DELETE FROM Fhir_Diagnoses WHERE Id = '{diagnosis.Id}'");
			query.ExecuteUpdate();

			query = session.CreateSQLQuery($"DELETE FROM Fhir_Conditions WHERE Id = '{diagnosis.Condition.Id}'");
			query.ExecuteUpdate();

			session.Flush();
		}
	}
}
