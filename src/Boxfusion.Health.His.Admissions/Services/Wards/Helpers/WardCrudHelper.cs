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
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Wards.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class WardCrudHelper : IWardCrudHelper, ITransientDependency
    {
        private readonly ILocationCrudHelper<Ward, WardResponse> _wardCrudHelper;
        private readonly IRepository<CdmAddress, Guid> _addressRepository;
        private readonly IRepository<Ward, Guid> _repository;
        private readonly IRepository<WardRoleAppointedPerson, Guid> _wardRoleAppointedPersonRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardCrudHelper"></param>
        /// <param name="addressRepository"></param>
        /// <param name="mapper"></param>
        public WardCrudHelper(
            ILocationCrudHelper<Ward, WardResponse> wardCrudHelper,
            IRepository<Ward, Guid> repository,
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
        public async Task<List<WardResponse>> GetAllAsync()
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

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="personId"></param>
        ///// <returns></returns>
        //public async Task<List<AutocompleteItemDto>> GetWardByPersonAutoCompleteAsync(Guid personId)
        //{
        //    return _mapper.Map<List<AutocompleteItemDto>>(await _wardRoleAppointedPersonRepository.GetAll().Where(x => x.Person.Id == personId).Select(x => x.Ward).Distinct().ToListAsync());
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="term"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<WardResponse>> GetWardByHospitalAsync(Guid id)
        {
            var wardResponses = await _wardCrudHelper.GetLocationByOrganisationAsync(id);
            return wardResponses;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        public async Task<bool> IsPersonAssignedToHospital(Guid wardId, Person currentPerson)
        {
            var OwnerOrganisation = await _repository.GetAsync(wardId);

            var hospitalAppoitmentService = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();
            var hospital = await hospitalAppoitmentService.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Hospital).FirstOrDefaultAsync();

            if(OwnerOrganisation.OwnerOrganisation.Id == hospital.Id)
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

            var hospital = await _wardRoleAppointedPersonRepository.GetAll().Where(r => r.Person == currentPerson).Select(r => r.Ward).FirstOrDefaultAsync();

            if (OwnerOrganisation.Id == hospital.Id)
            {
                return true;
            }

            return false;
        }
    }
}
