using Abp.Dependency;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.HisPatients.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class HisPatientCrudHelper : IHisPatientCrudHelper, ITransientDependency
    {
        private readonly IPatientCrudHelper<HisPatient, HisPatientResponse> _patientCrudHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientCrudHelper"></param>
        /// <param name="mapper"></param>
        public HisPatientCrudHelper(
            IPatientCrudHelper<HisPatient, HisPatientResponse> patientCrudHelper,
            IMapper mapper)
        {
            _patientCrudHelper = patientCrudHelper;
            _mapper = mapper;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HisPatientResponse>> GetAllAsync()
        {
            return await _patientCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HisPatientResponse> GetAsync(Guid id)
        {
            return await _patientCrudHelper.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        public async Task<HisPatientResponse> GetByIdNumberAsync(string identityNumber)
        {
            return await _patientCrudHelper.GetByIdNumberAsync(identityNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HisPatientResponse> CreateAsync(HisPatientInput input)
        {
            var hisPatient = _mapper.Map<HisPatient>(input);
            return await _patientCrudHelper.CreateAsync(input, hisPatient);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HisPatientResponse> UpdateAsync(HisPatientInput input)
        {
            return await _patientCrudHelper.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _patientCrudHelper.DeleteAsync(id);
        }
    }
}
