using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Tests;
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
    public class HisAdmissionsApplicationTestBase: AdmissionsTestBase
	{
        protected IRepository<Bed, Guid> _bedRepository;
        protected IRepository<BedType, Guid> _bedTypeRepository;
        protected IRepository<Room, Guid> _roomRepository;
        protected IRepository<Condition, Guid> _conditionRepository;
        protected IRepository<Note, Guid> _noteRepository;

        public HisAdmissionsApplicationTestBase()
		{
            _conditionRepository = Resolve<IRepository<Condition, Guid>>();
            _roomRepository = Resolve<IRepository<Room, Guid>>();
            _bedRepository = Resolve<IRepository<Bed, Guid>>();
            _bedTypeRepository = Resolve<IRepository<BedType, Guid>>();
            _noteRepository = Resolve<IRepository<Note, Guid>>();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="wardName"></param>/
		protected void CreateTestData_HealthFacility_And_Ward_With_RoomBed(string name, string wardName, string roomName, string bedName)
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

        protected Room CreateTestData_Room(string name, HisWard ward)
        {
            var room = _roomRepository.FirstOrDefault(a => a.Name == name);
            if (room is null)
            {
                var newRoom = new Room()
                {
                    Name = name,
                    Ward = ward,
                    NumberOfBeds = 20
                };
                room = _roomRepository.Insert(newRoom);
            }

            return room;
        }

        protected Bed CreateTestData_Bed(string name, Room room)
        {
            var bedType = CreateTestData_BedType("test", "testCode");

            var bed = _bedRepository.FirstOrDefault(a => a.Name == name);
            if (bed is null)
            {
                var newBed = new Bed()
                {
                    Name = name,
                    Room = room,
                    BedType = bedType
                    
                };
                bed = _bedRepository.Insert(newBed);
            }

            return bed;
        }

        protected BedType CreateTestData_BedType(string name, string productCode)
        {

            
            var bedType = _bedTypeRepository.FirstOrDefault(a => a.Name == name);
            if (bedType is null)
            {
                var newBedType = new BedType()
                {
                    Name = name,
                    ProductCode = productCode
                   
                    
                    

                };
                bedType = _bedTypeRepository.Insert(newBedType);
            }

            return bedType;
        }

        protected async Task<List<Condition>> CreateTestData_Conditions(HisPatient patient)
        {
            var codes = await GetTestData_CodesList();
            var conditions = new List<Condition>();

            try
            {
                using (var uow = _uowManager.Begin())
                {
					var tasks = new List<Task<Condition>>();
					codes.ForEach(code => tasks.Add(_conditionRepository.InsertAsync(new Condition() { Code = code, Subject = patient })));

					conditions = (await Task.WhenAll(tasks)).ToList();

                    await uow.CompleteAsync();
				}
			}
            catch (Exception ex)
            {
                throw;
            }

            return conditions;
		}

        protected async Task<Note> GetTestData_Note(string ownerId)
        {
            return await _noteRepository.FirstOrDefaultAsync(a => a.OwnerId == ownerId);
		}

        protected async Task<Room> GetTestData_Room(string name)
        {
            return await _roomRepository.FirstOrDefaultAsync(a => a.Name == name);
        }

        protected async Task<Bed> GetTestData_Bed(string name)
        {
            return await _bedRepository.FirstOrDefaultAsync(a => a.Name == name);
        }

        protected async Task<List<Diagnosis>> GetTestData_AdmissionDiagnosisList(WardAdmission admission,
                                                                       RefListEncounterDiagnosisRoles encounterDiagnosisRoles)
        {
            var result = new List<Diagnosis>();
			using var uow = _uowManager.Begin();
			result =  _diagnosisRepository.GetAllIncluding(a => a.Condition).Where(a => a.OwnerId == admission.Id.ToString()
                                                                  && a.Use == (int?)encounterDiagnosisRoles).ToList();
            await uow.CompleteAsync();

            return result;
        }
	}
}
