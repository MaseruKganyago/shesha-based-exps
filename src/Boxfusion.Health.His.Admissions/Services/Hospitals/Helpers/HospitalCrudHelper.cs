using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Organisations.Helper;
using Boxfusion.Health.His.Domain.Domain;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Hospitals.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class HospitalCrudHelper : IHospitalCrudHelper, ITransientDependency
    {
        private readonly IOrganisationCrudHelper<HisHospital, HospitalResponse> _HospitalCrudHelper;
        private readonly IRepository<CdmAddress, Guid> _addressRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HospitalCrudHelper"></param>
        /// <param name="addressRepository"></param>
        /// <param name="mapper"></param>
        public HospitalCrudHelper(
            IOrganisationCrudHelper<HisHospital, HospitalResponse> HospitalCrudHelper,
            IRepository<CdmAddress, Guid> addressRepository,
            IMapper mapper)
        {
            _HospitalCrudHelper = HospitalCrudHelper;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HospitalResponse>> GetAllAsync()
        {
            var HospitalResponses = await _HospitalCrudHelper.GetAllAsync();
            return HospitalResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HospitalResponse> GetAsync(Guid id)
        {
            var HospitalResponse = await _HospitalCrudHelper.GetAsync(id);
            var hospital = await _addressRepository.GetAll().Where(x => x.OwnerId.Trim() == HospitalResponse.Id.ToString()).OrderByDescending(x => x.CreationTime).FirstOrDefaultAsync();
            HospitalResponse.PrimaryAddress = _mapper.Map<CdmAddressResponse>(hospital);

            return HospitalResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HospitalResponse> CreateAsync(HospitalInput input)
        {
            var organisation = _mapper.Map<HisHospital>(input);
            var HospitalResponse = await _HospitalCrudHelper.CreateAsync(input?.PrimaryAddress, organisation);

            return HospitalResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HospitalResponse> UpdateAsync(HospitalInput input)
        {
            var HospitalResponse = await _HospitalCrudHelper.UpdateAsync(input);
            return HospitalResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _HospitalCrudHelper.DeleteAsync(id);
        }
    }
}
