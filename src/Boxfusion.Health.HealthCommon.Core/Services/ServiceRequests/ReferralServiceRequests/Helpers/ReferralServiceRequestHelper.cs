using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferralServiceRequestHelper : IReferralServiceRequestHelper, ITransientDependency
    {
        private readonly IServiceRequestCrudHelper<ReferralServiceRequest, ReferralServiceRequestResponse> _serviceRequestCrudHelper;
        private readonly IDocumentHelper _serviceRequestDocumentHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequestCrudHelper"></param>
        /// <param name="serviceRequestDocumentHelper"></param>
        /// <param name="mapper"></param>
        public ReferralServiceRequestHelper(
            IServiceRequestCrudHelper<ReferralServiceRequest, ReferralServiceRequestResponse> serviceRequestCrudHelper, 
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
        public async Task<List<ReferralServiceRequestResponse>> GetAllAsync()
        {
            var referralServiceRequests = await _serviceRequestCrudHelper.GetAllAsync();
            return referralServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReferralServiceRequestResponse> GetAsync(Guid id)
        {
            var referralServiceRequest = await _serviceRequestCrudHelper.GetAsync(id);
            return referralServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<ReferralServiceRequestResponse>> GetByPatientAsync(Guid patientId)
        {
            var referralServiceRequests = await _serviceRequestCrudHelper.GetByPatientAsync(patientId);
            return referralServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<ReferralServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId)
        {
            var referralServiceRequests = await _serviceRequestCrudHelper.GetByPratitionerAsync(practitionerId);
            return referralServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<ReferralServiceRequestResponse> CreateAsync(ReferralServiceRequestInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var referralServiceRequest = _mapper.Map<ReferralServiceRequest>(input);
            var insertedReferralServiceRequest = await _serviceRequestCrudHelper.CreateAsync(input, referralServiceRequest);
            var referralServiceRequesResponse = _mapper.Map<ReferralServiceRequest>(insertedReferralServiceRequest);

            //generate ReferToFacilityDocument
            insertedReferralServiceRequest = await _serviceRequestDocumentHelper.CreateReferToFacilityDocument(practitioner, referralServiceRequesResponse);

            return insertedReferralServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<ReferralServiceRequestResponse> UpdateAsync(ReferralServiceRequestUpdate input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var referralServiceRequest = _mapper.Map<ReferralServiceRequest>(input);
            var updatedReferralServiceRequest = await _serviceRequestCrudHelper.UpdateAsync(input, referralServiceRequest);
            var referralServiceRequesResponse = _mapper.Map<ReferralServiceRequest>(updatedReferralServiceRequest);

            //delete original ReferToFacilityDocument then create new one with the updated information
            updatedReferralServiceRequest = await _serviceRequestDocumentHelper.UpdateReferToFacilityDocument(input, practitioner, referralServiceRequesResponse);

            return updatedReferralServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id, Guid fileId)
        {
            await _serviceRequestCrudHelper.DeleteAsync(id);

            if (fileId == null || fileId is Guid guid && guid == Guid.Empty)
            {
                await _serviceRequestDocumentHelper.DeleteOriginalFile(fileId);
            }
        }
    }
}
