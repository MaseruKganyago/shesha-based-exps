using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Organisations.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Organisations.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganisationCrudHelper<T, TResult> : IOrganisationCrudHelper<T, TResult>, ITransientDependency where T : FhirOrganisation where TResult : class
    {
        private readonly IRepository<T, Guid> _repository;
        private readonly IRepository<CdmAddress, Guid> _addressRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="addressRepository"></param>
        /// <param name="mapper"></param>
        public OrganisationCrudHelper(
            IRepository<T, Guid> repository, 
            IRepository<CdmAddress, Guid> addressRepository, 
            IMapper mapper)
        {
            _repository = repository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TResult>> GetAllAsync()
        {
            return _mapper.Map<List<TResult>>(await _repository.GetAllListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TResult> GetAsync(Guid id)
        {
            return _mapper.Map<TResult>(await _repository.GetAsync(id));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressInput"></param>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<TResult> CreateAsync(CdmAddressInput addressInput, T entity, Func<Task> action = null)
        {
            var organisation = await _repository.InsertAsync(entity);
            CdmAddressResponse cdmAddressResponse = null;

            if (addressInput != null)
            {
                var cmdAddress = _mapper.Map<CdmAddress>(addressInput);
                _mapper.Map(organisation, cmdAddress);
                var insertedAddress = await _addressRepository.InsertAsync(cmdAddress);
                cdmAddressResponse = _mapper.Map<CdmAddressResponse>(insertedAddress);
            }

            var organisationResponse = _mapper.Map<TResult>(organisation);
            UtilityHelper.TrySetProperty(organisationResponse, "PrimaryAddress", cdmAddressResponse);

            //Additional logic from sub classes
            if (action != null) await action.Invoke();

            return organisationResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<TResult> UpdateAsync(OrganisationInput input, Func<Task> action = null)
        {
            var dbOrganisation = await _repository.GetAsync(input.Id);
            _mapper.Map(input, dbOrganisation);
            var organisation = await _repository.UpdateAsync(dbOrganisation);
            CdmAddressResponse cdmAddressResponse = null;

            if (input?.PrimaryAddress?.Id != null)
            {
                var dbCdmAddress = await _addressRepository.GetAsync(input.PrimaryAddress.Id.Value);
                _mapper.Map(input.PrimaryAddress, dbCdmAddress);
                _mapper.Map(organisation, dbCdmAddress);
                var insertedAddress = await _addressRepository.UpdateAsync(dbCdmAddress);
                cdmAddressResponse = _mapper.Map<CdmAddressResponse>(insertedAddress);
            }

            var organisationResponse = _mapper.Map<TResult>(organisation);
            UtilityHelper.TrySetProperty(organisationResponse, "Address", cdmAddressResponse);

            //Additional logic from sub classes
            if (action != null) await action.Invoke();

            return organisationResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
