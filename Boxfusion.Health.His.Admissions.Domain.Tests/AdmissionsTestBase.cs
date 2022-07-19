using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Patients;
using NHibernate.Transform;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shesha.Domain;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Abp.Runtime.Session;
using Boxfusion.Health.His.Common.Domain.Domain.Diagnoses;
using Boxfusion.Health.His.Common.Domain.Domain.ConditionIcdTenCodes;
using Boxfusion.Health.His.Common.Enums;
using Shouldly;
using Abp.UI;
using Boxfusion.Health.His.Admissions.Domain.Tests.Admissions;

namespace Boxfusion.Health.His.Admissions.Tests
{
	public class AdmissionsTestBase: SheshaNhTestBase
	{
        protected IRepository<HisHealthFacility, Guid> _facilityRepository;
        protected IRepository<HisPatient, Guid> _patientRepository;
        protected IRepository<HisWard, Guid> _wardRepository;
        protected IRepository<Diagnosis, Guid> _diagnosisRepository;
        protected IRepository<HisConditionIcdTenCode, Guid> _conditionIcdTenCodeRepo;
        protected readonly DiagnosisManager _diagnosisManager;
        protected readonly ConditionIcdTenCodeManager _conditionIcdTenCodeManager;
        protected IUnitOfWorkManager _uowManager;
        protected ISessionProvider _sessionProvider;

        public AdmissionsTestBase()
		{
            _facilityRepository = Resolve<IRepository<HisHealthFacility, Guid>>();
            _patientRepository = Resolve<IRepository<HisPatient, Guid>>();
            _wardRepository = Resolve<IRepository<HisWard, Guid>>();
            _diagnosisRepository = Resolve<IRepository<Diagnosis, Guid>>();
            _conditionIcdTenCodeRepo = Resolve<IRepository<HisConditionIcdTenCode, Guid>>();
            _diagnosisManager = Resolve<DiagnosisManager>();
            _conditionIcdTenCodeManager = Resolve<ConditionIcdTenCodeManager>();
            _uowManager = Resolve<IUnitOfWorkManager>();
            _sessionProvider = Resolve<ISessionProvider>();
		}

        /// <summary>
        /// NOTE: This should NOT be async to ensure that Tests do not execute before completion of Data Seeding.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="wardName"></param>
		protected void CreateTestData_HealthFacility_And_Ward(string name, string wardName)
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

                    CreateTestData_Ward(wardName, newHospital);
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

        protected async Task<HisHealthFacility> GetTestData_HealthFacility(string name)
        {
            return await _facilityRepository.FirstOrDefaultAsync(e => e.Name == name);
        }

        protected async Task<HisWard> GetTestData_Ward(string name)
        {
            return await _wardRepository.FirstOrDefaultAsync(a => a.Name == name);
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

                    var result = (await session.CreateSQLQuery($"exec His_AddAdmissionTestData @ServiceProviderId = :facilityId, @WardId = :wardId")
                                            .SetParameter("facilityId", facilityId)
                                            .SetParameter("wardId", wardId)
                                            .SetResultTransformer(Transformers.AliasToBean<AdmissionDataQueryModel>())
                                            .ListAsync<AdmissionDataQueryModel>()).FirstOrDefault();

					MapToAdmissionEntity(admission, result);
                    var codes = await GetTestData_CodesList();
                    await MakeADiagnosis(admission, codes, RefListEncounterDiagnosisRoles.AD, RefListAdmissionStatuses.admitted);

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

		private static void MapToAdmissionEntity(WardAdmission admission, AdmissionDataQueryModel result)
		{
            admission.Id = result.Id;
            admission.WardAdmissionNumber = result.WardAdmissionNumber;
            admission.AdmissionStatus = (RefListAdmissionStatuses?)result.AdmissionStatus;
            admission.AdmissionType = (RefListAdmissionTypes?)result.AdmissionType;
			admission.PartOf = new HospitalAdmission
			{
				Id = result.PartOfId
			};
		}

		private async Task MakeADiagnosis(WardAdmission wardAdmissionEntity, List<IcdTenCode> codes, RefListEncounterDiagnosisRoles use, RefListAdmissionStatuses status)
        {
            var diagnosisEntity = await _diagnosisManager.AddNewDiagnosis<WardAdmission, Condition>(wardAdmissionEntity,
                                          (int)use, null,
                                          //prepares the condtion of this diagnosis
                                          async item =>
                                          {
                                              item.RecordedDate = DateTime.Now;
                                              item.Subject = wardAdmissionEntity.Subject;
                                              item.Recorder = (PersonFhirBase)wardAdmissionEntity.Performer;
                                              item.FhirEncounter = wardAdmissionEntity;
                                              item.HospitalisationEncounter = (HospitalisationEncounter)wardAdmissionEntity.PartOf;
                                          });

            await _conditionIcdTenCodeManager.AssignIcdTenCodeToCondition<HisConditionIcdTenCode>(codes, diagnosisEntity.Condition,
                                                                        //(Optional) extra values required in ConditionIcdTenCode sub-entities
                                                                        async item =>
                                                                        {
                                                                            item.AdmissionStatus = status;
                                                                        });
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

        protected async Task<Diagnosis> GetTestData_AdmissionDiagnosis(WardAdmission admission, 
                                                                       RefListEncounterDiagnosisRoles encounterDiagnosisRoles)
        {
            return await _diagnosisRepository.FirstOrDefaultAsync(a => a.OwnerId == admission.Id.ToString()
                                                                  && a.Use == (int?)encounterDiagnosisRoles);
        }

        protected async Task<List<HisConditionIcdTenCode>> GetTestData_IcdTenCodesAssignments(Condition condition)
        {
            var results = new List<HisConditionIcdTenCode>();

            using var uow = _uowManager.Begin();
            results = _conditionIcdTenCodeRepo.GetAllIncluding(a => a.IcdTenCode)
                                              .Where(a => a.Condition.Id == condition.Id).ToList();
            await uow.CompleteAsync();

            return results;
        }

        protected void CleanUpTestData_Patient(Guid patientId)
        {
            using var session = OpenSession();
            var query = session.CreateSQLQuery("DELETE FROM Core_Persons WHERE Id = '" + patientId.ToString() + "'");
            query.ExecuteUpdate();

            session.Flush();
        }

        protected async Task CleanUpTestData_PatientAdmission(WardAdmission admission, Diagnosis diagnosis, bool includePartOf = true)
        {
            var diagnosisList = await _diagnosisRepository.GetAllListAsync(a => a.OwnerId == admission.Id.ToString());

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
            else
            {
                DeleteDiagnosisCombo(diagnosis);
            }

            session.Flush();
        }

		private void DeleteDiagnosisCombo(Diagnosis diagnosis)
		{
            using var session = OpenSession();
            var query = session.CreateSQLQuery($"DELETE FROM Fhir_Diagnoses WHERE Id = '{diagnosis.Id}'");
            query.ExecuteUpdate();

            query = session.CreateSQLQuery($"DELETE FROM Fhir_ConditionIcdTenCodes WHERE ConditionId = '{diagnosis.Condition.Id}'");
            query.ExecuteUpdate();

            query = session.CreateSQLQuery($"DELETE FROM Fhir_Conditions WHERE Id = '{diagnosis.Condition.Id}'");
            query.ExecuteUpdate();

            session.Flush();
        }
	}


}
