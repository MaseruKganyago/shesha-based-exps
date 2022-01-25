using Abp.Dependency;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Services.FacilityPatients.Helpers
{
    public class HisFacilityPatientsCrudHelper : IHisFacilityPatientsCrudHelper, ITransientDependency
    {
        private readonly IPatientCrudHelper<FacilityPatient, FacilityPatientsResponse> _patientCrudHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientCrudHelper"></param>
        /// <param name="mapper"></param>
        public HisFacilityPatientsCrudHelper(
            IPatientCrudHelper<FacilityPatient, FacilityPatientsResponse> patientCrudHelper,
            IMapper mapper)
        {
            _patientCrudHelper = patientCrudHelper;
            _mapper = mapper;
        }

        public async Task<FacilityPatientsResponse> CreateAsync(FacilityPatientsInput input)
        {
            var facilityPatient = _mapper.Map<FacilityPatient>(input);
            return await _patientCrudHelper.CreateAsync(input, facilityPatient);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FacilityPatientsResponse> GetAsync(Guid id)
        {
            return await _patientCrudHelper.GetAsync(id);
        }
    }
}
