using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.His.Common.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Tests
{
	public class HisCommonDomainTestBase: SheshaNhTestBase
	{
		private readonly IRepository<HisPatient, Guid> _patientRepository;
		private readonly IUnitOfWorkManager _uowManager;

		public HisCommonDomainTestBase()
		{
			_patientRepository = Resolve<IRepository<HisPatient, Guid>>();
			_uowManager = Resolve<IUnitOfWorkManager>();
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
		protected void CleanUpTestData_Patient(Guid patientId)
		{
			using var session = OpenSession();
			var query = session.CreateSQLQuery("DELETE FROM Core_Persons WHERE Id = '" + patientId.ToString() + "'");
			query.ExecuteUpdate();

			session.Flush();
		}

	}

}
