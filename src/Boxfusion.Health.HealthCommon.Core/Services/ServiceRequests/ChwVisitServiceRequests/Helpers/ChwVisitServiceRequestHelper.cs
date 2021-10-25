using Abp.Dependency;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ChwVisitServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ChwVisitServiceRequestHelper : IChwVisitServiceRequestHelper, ITransientDependency
    {
        private readonly IServiceRequestCrudHelper<ChwVisitServiceRequest, ChwVisitServiceRequestsResponse> _serviceRequestCrudHelper;
        private readonly IDocumentHelper _serviceRequestDocumentHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequestCrudHelper"></param>
        /// <param name="serviceRequestDocumentHelper"></param>
        /// <param name="mapper"></param>
        public ChwVisitServiceRequestHelper(
            IServiceRequestCrudHelper<ChwVisitServiceRequest, ChwVisitServiceRequestsResponse> serviceRequestCrudHelper,
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
        public async Task<List<ChwVisitServiceRequestsResponse>> GetAllAsync()
        {
            var ChwVisitServiceRequests = await _serviceRequestCrudHelper.GetAllAsync();
            return ChwVisitServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ChwVisitServiceRequestsResponse> GetAsync(Guid id)
        {
            var ChwVisitServiceRequest = await _serviceRequestCrudHelper.GetAsync(id);
            return ChwVisitServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<ChwVisitServiceRequestsResponse>> GetByPatientAsync(Guid patientId)
        {
            var ChwVisitServiceRequests = await _serviceRequestCrudHelper.GetByPatientAsync(patientId);
            return ChwVisitServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<ChwVisitServiceRequestsResponse>> GetByPratitionerAsync(Guid practitionerId)
        {
            var ChwVisitServiceRequests = await _serviceRequestCrudHelper.GetByPratitionerAsync(practitionerId);
            return ChwVisitServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<ChwVisitServiceRequestsResponse> CreateAsync(ChwVisitServiceRequestsInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var chwVisitServiceRequest = _mapper.Map<ChwVisitServiceRequest>(input);
            //chwVisitServiceRequest.RequestOwnerId = practitioner.Id.ToString();
            //chwVisitServiceRequest.RequestOwnerType = practitioner.GetTypeShortAlias();
            var insertedChwVisitServiceRequest = await _serviceRequestCrudHelper.CreateAsync(input, chwVisitServiceRequest);

            return insertedChwVisitServiceRequest;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<ChwVisitServiceRequestsResponse> UpdateAsync(ChwVisitServiceRequestsInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var chwVisitServiceRequest = _mapper.Map<ChwVisitServiceRequest>(input);
            //chwVisitServiceRequest.RequestOwnerId = practitioner.Id.ToString();
            //chwVisitServiceRequest.RequestOwnerType = practitioner.GetTypeShortAlias();
            var updatedChwVisitServiceRequest = await _serviceRequestCrudHelper.UpdateAsync(input, chwVisitServiceRequest);

            return updatedChwVisitServiceRequest;
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
