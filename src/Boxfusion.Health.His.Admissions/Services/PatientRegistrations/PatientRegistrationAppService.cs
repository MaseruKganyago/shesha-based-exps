using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.Domain;
using Shesha.DynamicEntities.Dtos;
using Shesha.Enterprise.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.PatientRegistrations
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/His/[controller]")]
	public class PatientRegistrationAppService: SheshaAppServiceBase
	{
		private readonly IRepository<HisPatient, Guid> _patientRepository;
		private readonly IRepository<HisHealthFacility, Guid> _healthFacilityRepository;

		/// <summary>
		/// 
		/// </summary>
		public PatientRegistrationAppService(IRepository<HisPatient, Guid> patientRepository, IRepository<HisHealthFacility, Guid> healthFacilityRepository)
		{
			_patientRepository = patientRepository;
			_healthFacilityRepository = healthFacilityRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost, Route("[action]")]
		public async Task<DynamicDto<HisPatient, Guid>> RegisterPatient(RegisterPatientDto input)
		{
			var homeAddress = await CreatePatientAddress(input.ResidentialAddress, input.SecondResidentialAddress);

			Address workAddress = null;
			if (input.IsEmployed)
				workAddress = await CreatePatientAddress(input.WorkAddress, input.SecondWorkAddress);

			var patientEntity = await SaveOrUpdateEntityAsync<HisPatient>(nullabeId(input.Id), async item =>
			{
				ObjectMapper.Map<RegisterPatientDto, HisPatient>(input, item);
				item.Address = homeAddress;
				item.WorkAddress = workAddress;
			});

			var facilityId = RequestContextHelper.FacilityId;
			HisHealthFacility facility = null;
			if (RequestContextHelper.HasFacilityId)
				facility = await _healthFacilityRepository.GetAsync(facilityId);

			await SaveOrUpdateEntityAsync<HospitalAdmission>(null, async item =>
			{
				item.RegistrationType = input.RegistrationType;
				item.Subject = patientEntity;
				item.HospitalAdmissionStatus = RefListHospitalAdmissionStatuses.draft;
				item.HospitalAdmissionNumber = GetAdmissionNumber();
				item.ServiceProvider = facility;
			});

			return await MapToDynamicDtoAsync<HisPatient, Guid>(patientEntity);
		}

		private async Task<Address> CreatePatientAddress(string address, string secondAddress)
		{
			return await SaveOrUpdateEntityAsync<Address>(null, async item =>
			{
				item.AddressLine1 = address;
				item.AddressLine2 = secondAddress;
				item.AddressType = (int?)RefListAddressType.physical;
			});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string GetAdmissionNumber()
		{
			var date = DateTime.Now.ToString("yymmdd");
			var sequenceManager = new SequenceManager();
			var seqNumber = sequenceManager.GetNextSequenceNo("BoxHealth.Houghton.HospitalAdmission", date);

			return $"{date}/{seqNumber:0000}";
		}

		private Guid? nullabeId(Guid id)
		{
			if (id == Guid.Empty) return null;

			return id;
		}
	}
}
