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
using Boxfusion.Health.His.Admissions.Helpers.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using NHibernate.Linq;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class WardCrudHelper : IWardCrudHelper, ITransientDependency
    {
        private readonly ILocationCrudHelper<HisWard, HisWardResponse> _wardCrudHelper;
        private readonly IRepository<CdmAddress, Guid> _addressRepository;
        private readonly IRepository<HisWard, Guid> _repository;
        private readonly IRepository<WardRoleAppointedPerson, Guid> _wardRoleAppointedPersonRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardCrudHelper"></param>
        /// <param name="repository"></param>
        /// <param name="wardRoleAppointedPersonRepository"></param>
        /// <param name="addressRepository"></param>
        /// <param name="mapper"></param>
        public WardCrudHelper(
            ILocationCrudHelper<HisWard, HisWardResponse> wardCrudHelper,
            IRepository<HisWard, Guid> repository,
            IRepository<WardRoleAppointedPerson, Guid> wardRoleAppointedPersonRepository,
            IRepository<CdmAddress, Guid> addressRepository,
            IMapper mapper)
        {
            _wardCrudHelper = wardCrudHelper;
            _addressRepository = addressRepository;
            _repository = repository;
            _wardRoleAppointedPersonRepository = wardRoleAppointedPersonRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HisWardResponse>> GetAllAsync()
        {
            var WardResponses = await _wardCrudHelper.GetAllAsync();
            return WardResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="term"></param>
        /// <param name="organisationId"></param>
        /// <returns></returns>
        public async Task<List<AutocompleteItemDto>> GetWardByHospitalAutoCompleteAsync(string term, Guid organisationId)
        {
            term = (term ?? "").ToLower();

            return _mapper.Map<List<AutocompleteItemDto>>(await _repository.GetAll().Where(x => (x.Name ?? "").ToLower().Contains(term) && x.OwnerOrganisation.Id == organisationId).OrderBy(x => x.Name).Take(10).ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<HisWardResponse>> GetWardByHospitalAsync(Guid id)
        {
            var wardResponses = await _wardCrudHelper.GetLocationByOrganisationAsync(id);
            return wardResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HisWardResponse> GetAsync(Guid id)
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
        public async Task<HisWardResponse> CreateAsync(HisWardInput input)
        {
            var location = _mapper.Map<HisWard>(input);
            var WardResponse = await _wardCrudHelper.CreateAsync(input?.Address, location);

            return WardResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HisWardResponse> UpdateAsync(WardInput input)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        public async Task<bool> IsPersonAssignedToHospital(Guid wardId, Person currentPerson)
        {
            var OwnerOrganisation = await _repository.GetAsync(wardId);

            var hospitalAppoitmentService = StaticContext.IocManager.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
            var hospital = await hospitalAppoitmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Hospital).FirstOrDefaultAsync();

            if(OwnerOrganisation?.OwnerOrganisation?.Id == hospital.Id)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        public async Task<bool> IsPersonAssignedToWard(Guid wardId, Person currentPerson)
        {
            var OwnerOrganisation = await _repository.GetAsync(wardId);

            var hospital = await _wardRoleAppointedPersonRepository.GetAll()
                .Where(r => r.Person == currentPerson).Select(r => r.Ward).ToListAsync();

            if(hospital.Any(r => r.Id == OwnerOrganisation.Id))
            {
                return true;
            }

            return false;
        }
    }
}
