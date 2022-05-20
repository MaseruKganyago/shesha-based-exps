using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Admissions.Services.Admissions;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Tests

{
    public class AdmissionManagementTestBase : SheshaNhTestBase
    {
        protected readonly IUnitOfWorkManager _uowManager;
        private readonly IMapper _ObjectMapper;
        protected IRepository<CdmPatient, Guid> _patientRepository;
        protected IRepository<WardAdmission, Guid> _wardAdmissionRepository;
        protected IRepository<HisWard, Guid> _wardRepository;
        protected IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepository;
        private readonly IAdmissionsAppService _admissionsService;

        public AdmissionManagementTestBase()
        {
            _uowManager = Resolve<IUnitOfWorkManager>();
            _ObjectMapper = Resolve<IMapper>();
            _patientRepository = Resolve<IRepository<CdmPatient, Guid>>();
            _wardAdmissionRepository = Resolve<IRepository<WardAdmission, Guid>>();
            _wardRepository = Resolve<IRepository<HisWard, Guid>>();
            _hospitalAdmissionRepository = Resolve<IRepository<HospitalAdmission, Guid>>();
            _admissionsService = Resolve<IAdmissionsAppService>();
        }

        protected void CleanUpTestData_Ward(Guid wardId)
        {
            using var session = OpenSession();
            var query = session
                .CreateSQLQuery("DELETE FROM Core_Facilities WHERE Id = '" + wardId.ToString() + "'");
            query.ExecuteUpdate();

            session.Flush();
        } 
        protected void CleanUpTestData_HospitalAdmission(Guid hospitalAdmissionId)
        {
            using var session = OpenSession();
            var query = session
                .CreateSQLQuery("DELETE FROM Fhir_Encounters WHERE Id = '" + hospitalAdmissionId.ToString() + "'");
            query.ExecuteUpdate();

            session.Flush();
        } 
        protected void CleanUpTestData_WardAdmission(Guid wardAdmissionId)
        {
            using var session = OpenSession();
            var query = session
                .CreateSQLQuery("DELETE FROM Fhir_Encounters WHERE Id = '" + wardAdmissionId.ToString() + "'");
            query.ExecuteUpdate();

            session.Flush();
        } 
        protected void CleanUpTestData_Patient(Guid patientId)
        {
            using var session = OpenSession();
            var query = session.CreateSQLQuery("DELETE FROM Core_Persons WHERE Id = '" + patientId.ToString() + "'");
            query.ExecuteUpdate();

            session.Flush();
        }
        public async Task<HospitalAdmission> CreateTestData_NewHospitalAdmission()
        {
            var hospitalAdmission = new HospitalAdmission();
            using (var uow = _uowManager.Begin())
            {
                hospitalAdmission.HospitalAdmissionNumber = "123";
                hospitalAdmission = await _hospitalAdmissionRepository.InsertAsync(hospitalAdmission);

                uow.Complete();
            }
            return hospitalAdmission;
        }
        public async Task<HisWard> CreateTestData_NewWard(int wardNumber)
        {
            var hisWard = new HisWard();
            using (var uow = _uowManager.Begin())
            {
                hisWard = new HisWard()
                {
                    Name = $"Test ward {wardNumber}"
                };
                hisWard = await _wardRepository.InsertAsync(hisWard);

                uow.Complete();
            }
            return hisWard;
        }
        public async Task<WardAdmission> AdmitPatient_To_Ward(AdmissionInput input)
        {
            var wardAdmission = new WardAdmission();
            using (var uow = _uowManager.Begin())
            {
                var hospitalAdmission = await CreateTestData_NewHospitalAdmission();
                var newWardAdmission = _ObjectMapper.Map<WardAdmission>(input);
                var codes = new List<IcdTenCode>();
                wardAdmission = await _admissionsService.AdmitPatientAsync(newWardAdmission, hospitalAdmission, codes);
                uow.Complete();
            }
            return wardAdmission;
        }
        protected async Task<CdmPatient> CreateTestData_NewPatient(string name)
        {
            CdmPatient patient;

            using (var uow = _uowManager.Begin())
            {
                patient = new CdmPatient()
                {
                    FirstName = name,
                    LastName = name
                };
                patient = await _patientRepository.InsertAsync(patient);

                uow.Complete();
            }

            return patient;
        }
    }
}
