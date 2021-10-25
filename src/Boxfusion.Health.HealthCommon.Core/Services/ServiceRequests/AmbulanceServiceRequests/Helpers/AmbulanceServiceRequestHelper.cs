using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers;
using NHibernate;
using NHibernate.Linq;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.AmbulanceServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class AmbulanceServiceRequestHelper : IAmbulanceServiceRequestHelper, ITransientDependency
    {
        private readonly IServiceRequestCrudHelper<AmbulanceServiceRequest, AmbulanceServiceRequestResponse> _serviceRequestCrudHelper;
        private readonly IRepository<FhirAddress, Guid> _fhirAddressRepository;
        private readonly IDocumentHelper _serviceRequestDocumentHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequestCrudHelper"></param>
        /// <param name="fhirAddressRepository"></param>
        /// <param name="serviceRequestDocumentHelper"></param>
        /// <param name="mapper"></param>
        public AmbulanceServiceRequestHelper(
            IServiceRequestCrudHelper<AmbulanceServiceRequest,AmbulanceServiceRequestResponse> serviceRequestCrudHelper,
            IRepository<FhirAddress, Guid> fhirAddressRepository,
            IDocumentHelper serviceRequestDocumentHelper, 
            IMapper mapper)
        {
            _serviceRequestCrudHelper = serviceRequestCrudHelper;
            _fhirAddressRepository = fhirAddressRepository;
            _serviceRequestDocumentHelper = serviceRequestDocumentHelper;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmbulanceServiceRequestResponse>> GetAllAsync()
        {
            var ambulanceServiceRequestResponses = await _serviceRequestCrudHelper.GetAllAsync();
            return ambulanceServiceRequestResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AmbulanceServiceRequestResponse> GetAsync(Guid id)
        {
            var ambulanceServiceRequestResponses = await _serviceRequestCrudHelper.GetAsync(id);
            ambulanceServiceRequestResponses.PickUpAddress = _mapper.Map<CdmAddressResponse>(await _fhirAddressRepository.GetAll().Where(x => x.OwnerId.Trim() == ambulanceServiceRequestResponses.Id.ToString()).OrderByDescending(x => x.CreationTime).FirstOrDefaultAsync());
           
            return ambulanceServiceRequestResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<AmbulanceServiceRequestResponse>> GetByPatientAsync(Guid patientId)
        {
            var ambulanceServiceRequestResponses = await _serviceRequestCrudHelper.GetByPatientAsync(patientId);
            return ambulanceServiceRequestResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<AmbulanceServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId)
        {
            var ambulanceServiceRequestResponses = await _serviceRequestCrudHelper.GetByPratitionerAsync(practitionerId);
            return ambulanceServiceRequestResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<AmbulanceServiceRequestResponse> CreateAsync(AmbulanceServiceRequestInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var ambulanceServiceRequest = _mapper.Map<AmbulanceServiceRequest>(input);
            var insertedAmbulanceServiceRequestResponse = await _serviceRequestCrudHelper.CreateAsync(input, ambulanceServiceRequest);

            //Add address
            FhirAddress address = null;
            if (input?.PickUpAddress != null)
            {
                var fhirAddress = _mapper.Map<FhirAddress>(input.PickUpAddress);
                fhirAddress.OwnerId = ambulanceServiceRequest.Id.ToString();
                fhirAddress.OwnerType = ambulanceServiceRequest.GetTypeShortAlias();
                address = await _fhirAddressRepository.InsertAsync(fhirAddress);
            }

            insertedAmbulanceServiceRequestResponse.PickUpAddress = address != null ? _mapper.Map<CdmAddressResponse>(address) : null;

            return insertedAmbulanceServiceRequestResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<AmbulanceServiceRequestResponse> UpdateAsync(AmbulanceServiceRequestInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var ambulanceServiceRequest = _mapper.Map<AmbulanceServiceRequest>(input);
            var updatedAmbulanceServiceRequestResponse = await _serviceRequestCrudHelper.UpdateAsync(input, ambulanceServiceRequest);

            //Update address
            if (input?.PickUpAddress != null && input?.PickUpAddress?.Id == null)
                throw new UserFriendlyException("Address Id needs to be provided in order to update it");

            var dbAmbulanceServiceRequestAddress = await _fhirAddressRepository.GetAsync(input.PickUpAddress.Id.Value);
            _mapper.Map(input.PickUpAddress, dbAmbulanceServiceRequestAddress);
            dbAmbulanceServiceRequestAddress = await _fhirAddressRepository.UpdateAsync(dbAmbulanceServiceRequestAddress);

            updatedAmbulanceServiceRequestResponse.PickUpAddress = dbAmbulanceServiceRequestAddress != null ? _mapper.Map<CdmAddressResponse>(dbAmbulanceServiceRequestAddress) : null;

            return updatedAmbulanceServiceRequestResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _serviceRequestCrudHelper.DeleteAsync(id);
        }
    }
}
