using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferToPractitionerServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferToPractitionerHelper : IReferToPractitionerHelper, ITransientDependency
    {
        private readonly IServiceRequestCrudHelper<ReferToPractitionerServiceRequest, ReferToPractitionerServiceRequestResponse> _serviceRequestCrudHelper;
        private readonly IDocumentHelper _serviceRequestDocumentHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequestCrudHelper"></param>
        /// <param name="serviceRequestDocumentHelper"></param>
        /// <param name="mapper"></param>
        public ReferToPractitionerHelper(
            IServiceRequestCrudHelper<ReferToPractitionerServiceRequest, ReferToPractitionerServiceRequestResponse> serviceRequestCrudHelper,
            IDocumentHelper serviceRequestDocumentHelper,
            IMapper mapper)
        {
            _serviceRequestCrudHelper = serviceRequestCrudHelper;
            _serviceRequestDocumentHelper = serviceRequestDocumentHelper;
            _mapper = mapper;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReferToPractitionerServiceRequestResponse>> GetAllAsync()
        {
            var ReferToPractitionerServiceRequests = await _serviceRequestCrudHelper.GetAllAsync();
            return ReferToPractitionerServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReferToPractitionerServiceRequestResponse> GetAsync(Guid id)
        {
            var ReferToPractitionerServiceRequest = await _serviceRequestCrudHelper.GetAsync(id);
            return ReferToPractitionerServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<ReferToPractitionerServiceRequestResponse>> GetByPatientAsync(Guid patientId)
        {
            var ReferToPractitionerServiceRequest = await _serviceRequestCrudHelper.GetByPatientAsync(patientId);
            return ReferToPractitionerServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<ReferToPractitionerServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId)
        {
            var ReferToPractitionerServiceRequest = await _serviceRequestCrudHelper.GetByPratitionerAsync(practitionerId);
            return ReferToPractitionerServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<ReferToPractitionerServiceRequestResponse> CreateAsync(ReferToPractitionerServiceRequestInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var ReferToPractitionerServiceRequest = _mapper.Map<ReferToPractitionerServiceRequest>(input);
            var insertedReferToPractitionerServiceRequest = await _serviceRequestCrudHelper.CreateAsync(input, ReferToPractitionerServiceRequest);

            return insertedReferToPractitionerServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<ReferToPractitionerServiceRequestResponse> UpdateAsync(ReferToPractitionerServiceRequestInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var ReferToPractitionerServiceRequest = _mapper.Map<ReferToPractitionerServiceRequest>(input);
            var updatedReferToPractitionerServiceRequest = await _serviceRequestCrudHelper.UpdateAsync(input, ReferToPractitionerServiceRequest);

            return updatedReferToPractitionerServiceRequest;
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

