using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.ConditionIcdTenCodes;
using Boxfusion.Health.His.Common.Diagnoses;
using Boxfusion.Health.His.Common.Domain.Domain.Room;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Boxfusion.Health.His.Common.Tests.Models;
using NHibernate.Transform;
using Shesha.Domain;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Tests
{
	public class HisCommonDomainTestBase: SheshaNhTestBase
	{
		protected IRepository<HisHealthFacility, Guid> _facilityRepository;
		protected IRepository<HisPatient, Guid> _patientRepository;
		protected IRepository<HisWard, Guid> _wardRepository;
		protected IRepository<Bed, Guid> _bedRepository;
		protected IRepository<Room, Guid> _roomRepository;
		protected IRepository<BedType, Guid> _bedTypeRepository;
		protected IUnitOfWorkManager _uowManager;
		//protected ISessionProvider _sessionProvider;

		public HisCommonDomainTestBase()
		{
			_facilityRepository = Resolve<IRepository<HisHealthFacility, Guid>>();
			_patientRepository = Resolve<IRepository<HisPatient, Guid>>();
			_wardRepository = Resolve<IRepository<HisWard, Guid>>();
			_bedRepository = Resolve<IRepository<Bed, Guid>>();
			_roomRepository = Resolve<IRepository<Room, Guid>>();
			_bedTypeRepository = Resolve<IRepository<BedType, Guid>>();
			_uowManager = Resolve<IUnitOfWorkManager>();
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

		protected async Task<WardAdmission> CreateTestData_NewAdmission(Guid facilityId, Guid wardId)
		{
			try
			{
				var admission = new WardAdmission();
				using (var uow = _uowManager.Begin())
				{
					using var session = OpenSession();

					var result = (await session.CreateSQLQuery($"exec Sp_His_AddAdmissionTestData @ServiceProviderId = :facilityId, @WardId = :wardId")
											.SetParameter("facilityId", facilityId)
											.SetParameter("wardId", wardId)
											.SetResultTransformer(Transformers.AliasToBean<AdmissionDataQueryModel>())
											.ListAsync<AdmissionDataQueryModel>()).FirstOrDefault();

					MapToAdmissionEntity(admission, result);

					session.Flush();
					await uow.CompleteAsync();
				}

				return admission;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		protected async Task<WardAdmission> CreateTestData_AddRoomBedToWardAdmission(Guid admissionId, Guid roomId, Guid bedId)
		{
			try
			{
				var admission = new WardAdmission();
				using (var uow = _uowManager.Begin())
				{
					using var session = OpenSession();

					var result = (await session.CreateSQLQuery($"exec sp_His_AddRoomAndBedToWardAdmission @admissionId = :admissionId, @roomId = :roomId, @bedId = :bedId")
											.SetParameter("admissionId", admissionId)
											.SetParameter("roomId", roomId)
											.SetParameter("bedId", bedId)
											.SetResultTransformer(Transformers.AliasToBean<AdmissionsWithBedRoomQuerymodel>())
											.ListAsync<AdmissionsWithBedRoomQuerymodel>()).FirstOrDefault();

					MapToAdmissionEntity(admission, result);
					MapRoomBedToAdmissionEntity(admission, result);

					session.Flush();
					await uow.CompleteAsync();
				}

				return admission;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private static void MapRoomBedToAdmissionEntity(WardAdmission admission, AdmissionsWithBedRoomQuerymodel result)
		{
			admission.Room = new Room
			{
				Id = result.RoomId
			};
			admission.Bed = new Bed
			{
				Id = result.BedId
			};
		}

		private static void MapToAdmissionEntity(WardAdmission admission, AdmissionDataQueryModel result)
		{
			admission.Id = result.Id;
			admission.WardAdmissionNumber = result.WardAdmissionNumber;
			admission.WardAdmissionStatus = (RefListWardAdmissionStatuses?)result.WardAdmissionStatus;
			admission.AdmissionType = (RefListAdmissionTypes?)result.AdmissionType;
			admission.PartOf = new HospitalAdmission
			{
				Id = result.PartOfId
			};
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
	}
}
