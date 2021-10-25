using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Services.Locations.Helpers;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Locations.Wards.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class WardCrudHelper : IWardCrudHelper, ITransientDependency
    {
        private readonly ILocationCrudHelper<Ward, WardResponse> _wardCrudHelper;
        private readonly IRepository<CdmAddress, Guid> _addressRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardCrudHelper"></param>
        /// <param name="addressRepository"></param>
        /// <param name="mapper"></param>
        public WardCrudHelper(
            ILocationCrudHelper<Ward, WardResponse> wardCrudHelper,
            IRepository<CdmAddress, Guid> addressRepository,
            IMapper mapper)
        {
            _wardCrudHelper = wardCrudHelper;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<WardResponse>> GetAllAsync()
        {
            var WardResponses = await _wardCrudHelper.GetAllAsync();
            return WardResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WardResponse> GetAsync(Guid id)
        {
            var WardResponse = await _wardCrudHelper.GetAsync(id);
            WardResponse.Address = _mapper.Map<CdmAddressResponse>(await _addressRepository.GetAll().Where(x => x.OwnerId.Trim() == WardResponse.Id.ToString()).OrderByDescending(x => x.CreationTime).FirstOrDefaultAsync());

            return WardResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<WardResponse> CreateAsync(WardInput input)
        {
            var location = _mapper.Map<Ward>(input);
            var WardResponse = await _wardCrudHelper.CreateAsync(input?.Address, location);

            return WardResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<WardResponse> UpdateAsync(WardInput input)
        {
            var WardResponse = await _wardCrudHelper.UpdateAsync(input);
            return WardResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _wardCrudHelper.DeleteAsync(id);
        }
    }
}
