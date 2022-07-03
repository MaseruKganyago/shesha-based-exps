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

namespace Boxfusion.Health.His.Admissions.Tests
{
	public class AdmissionsTestBase: SheshaNhTestBase
	{
        protected IRepository<HisHealthFacility, Guid> _facilityRepository;
        protected IRepository<HisPatient, Guid> _patientRepository;
        protected IRepository<HisWard, Guid> _wardRepository;
        protected IRepository<Diagnosis, Guid> _diagnosisRepository;
        protected IRepository<HisConditionIcdTenCode, Guid> _conditionIcdTenCodeRepo;
        protected IUnitOfWorkManager _uowManager;
        protected ISessionProvider _sessionProvider;

        public AdmissionsTestBase()
		{
            _facilityRepository = Resolve<IRepository<HisHealthFacility, Guid>>();
            _patientRepository = Resolve<IRepository<HisPatient, Guid>>();
            _wardRepository = Resolve<IRepository<HisWard, Guid>>();
            _diagnosisRepository = Resolve<IRepository<Diagnosis, Guid>>();
            _conditionIcdTenCodeRepo = Resolve<IRepository<HisConditionIcdTenCode, Guid>>();
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

        private HisWard CreateTestData_Ward(string name, HisHealthFacility hospital)
        {
            var ward = _wardRepository.FirstOrDefault(a => a.Name == name);
            if (ward is null)
            {
                var newWard = new HisWard()
                {
                    Name = name,
                    OwnerOrganisation = hospital,
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
            return await _conditionIcdTenCodeRepo.GetAllListAsync(a => a.Condition.Id == condition.Id);
        }

        protected void CleanUpTestData_Patient(Guid patientId)
        {
            using var session = OpenSession();
            var query = session.CreateSQLQuery("DELETE FROM Core_Persons WHERE Id = '" + patientId.ToString() + "'");
            query.ExecuteUpdate();

            session.Flush();
        }

        protected void CleanUpTestData_PatientAdmission(WardAdmission admission, Diagnosis diagnosis)
        {
            using var session = OpenSession();
            var query = session.CreateSQLQuery($"Update Fhir_Conditions set FhirEncounterId = null where FhirEncounterId = '{admission.Id}'" +
                $"DELETE FROM Fhir_Encounters WHERE Id = '{admission.Id}'");
            query.ExecuteUpdate();

            query = session.CreateSQLQuery($"Update Fhir_Conditions set HospitalisationEncounterId = null where HospitalisationEncounterId = '{admission.PartOf.Id}'" +
                $"DELETE FROM Fhir_Encounters WHERE Id = '{admission.PartOf.Id}'");
            query.ExecuteUpdate();

            query = session.CreateSQLQuery($"DELETE FROM Fhir_Diagnoses WHERE Id = '{diagnosis.Id}'");
            query.ExecuteUpdate();

            query = session.CreateSQLQuery($"DELETE FROM Fhir_ConditionIcdTenCodes WHERE ConditionId = '{diagnosis.Condition.Id}'");
            query.ExecuteUpdate();

            query = session.CreateSQLQuery($"DELETE FROM Fhir_Conditions WHERE Id = '{diagnosis.Condition.Id}'");
            query.ExecuteUpdate();

            session.Flush();
        }
    }
}
