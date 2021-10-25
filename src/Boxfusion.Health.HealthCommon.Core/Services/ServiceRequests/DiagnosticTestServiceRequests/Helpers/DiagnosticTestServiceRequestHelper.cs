using Abp.Dependency;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.DiagnosticTestServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DiagnosticTestServiceRequestHelper : IDiagnosticTestServiceRequestHelper, ITransientDependency
    {
        private readonly IServiceRequestCrudHelper<DiagnosticTestServiceRequest, DiagnosticTestServiceRequestResponse> _serviceRequestCrudHelper;
        private readonly IDocumentHelper _serviceRequestDocumentHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequestCrudHelper"></param>
        /// <param name="serviceRequestDocumentHelper"></param>
        /// <param name="mapper"></param>
        public DiagnosticTestServiceRequestHelper(
            IServiceRequestCrudHelper<DiagnosticTestServiceRequest, DiagnosticTestServiceRequestResponse> serviceRequestCrudHelper, 
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
        public async Task<List<DiagnosticTestServiceRequestResponse>> GetAllAsync()
        {
            var diagnosticTestServiceRequests = await _serviceRequestCrudHelper.GetAllAsync();
            return diagnosticTestServiceRequests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DiagnosticTestServiceRequestResponse> GetAsync(Guid id)
        {
            var diagnosticTestServiceRequest = await _serviceRequestCrudHelper.GetAsync(id);
            return diagnosticTestServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<DiagnosticTestServiceRequestResponse>> GetByPatientAsync(Guid patientId)
        {
            var diagnosticTestServiceRequest = await _serviceRequestCrudHelper.GetByPatientAsync(patientId);
            return diagnosticTestServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<DiagnosticTestServiceRequestResponse>> GetByPratitionerAsync(Guid practitionerId)
        {
            var diagnosticTestServiceRequest = await _serviceRequestCrudHelper.GetByPratitionerAsync(practitionerId);
            return diagnosticTestServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<DiagnosticTestServiceRequestResponse> CreateAsync(DiagnosticTestServiceRequestInput input, Person practitioner)
        {
            _mapper.Map(practitioner, input);
            var diagnosticTestServiceRequest = _mapper.Map<DiagnosticTestServiceRequest>(input);
            var insertedDiagnosticTestServiceRequest = await _serviceRequestCrudHelper.CreateAsync(input, diagnosticTestServiceRequest);
            var diagnosticTestServiceRequestResponse = _mapper.Map<DiagnosticTestServiceRequest>(insertedDiagnosticTestServiceRequest);

            //generate ReferToFacilityDocument
            insertedDiagnosticTestServiceRequest = await _serviceRequestDocumentHelper.CreateCovid19TestReferralDocument(practitioner, diagnosticTestServiceRequestResponse);

            return insertedDiagnosticTestServiceRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task<DiagnosticTestServiceRequestResponse> UpdateAsync(DiagnosticTestServiceRequestUpdate input, Person practitioner)
        {
            Validation.ValidateIdWithException(input?.Encounter?.Id, "Encounter Id cannot be empty");
            Validation.ValidateIdWithException(input?.Subject?.Id, "Subject Id cannot be empty");

            _mapper.Map(practitioner, input);
            var diagnosticTestServiceRequest = _mapper.Map<DiagnosticTestServiceRequest>(input);
            var updatedDiagnosticTestServiceRequest = await _serviceRequestCrudHelper.UpdateAsync(input, diagnosticTestServiceRequest);
            var diagnosticTestServiceRequestResponse = _mapper.Map<DiagnosticTestServiceRequest>(updatedDiagnosticTestServiceRequest);

            //delete original ReferToFacilityDocument then create new one with the updated information
            var outcome = await _serviceRequestDocumentHelper.UpdateCovid19TestReferralDocument(input, practitioner, diagnosticTestServiceRequestResponse);

            return updatedDiagnosticTestServiceRequest;
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
