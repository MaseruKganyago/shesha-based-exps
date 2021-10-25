using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.ServiceAgents;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicationRequestCrudHelper : IMedicationRequestCrudHelper, ITransientDependency
    {
        //private readonly ICdmSettings _cdmSettings;
        private readonly IUnitOfWorkManager _unitOfWork;
        private IServiceAgentHttp _serviceAgentHttp;
        private readonly IRepository<CdmMedicationRequest, Guid> _repository;
        private readonly IMapper _mapper;
        private readonly IDocumentHelper _serviceRequestDocumentHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdmSettings"></param>
        /// <param name="serviceAgentHttp"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="serviceRequestDocumentHelper"></param>
        public MedicationRequestCrudHelper(
            ICdmSettings cdmSettings,
            IServiceAgentHttp serviceAgentHttp,
            IRepository<CdmMedicationRequest, Guid> repository,
            IMapper mapper,
            IUnitOfWorkManager unitOfWork,
            IDocumentHelper serviceRequestDocumentHelper
            )
        {
            _repository = repository;
            _mapper = mapper;
            _serviceAgentHttp = serviceAgentHttp;
            _unitOfWork = unitOfWork;
            _serviceRequestDocumentHelper = serviceRequestDocumentHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name=""></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<List<AutocompleteItemDto>> GetMedpraxMedicationProductList(int pageIndex = 1, int pageSize = 100, string value = "")
        {
            var result = _serviceAgentHttp.PostAsync(pageIndex, pageSize, value);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CdmMedicationRequestResponse>> GetAll()
        {
            return _mapper.Map<List<CdmMedicationRequestResponse>>(await _repository.GetAllListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CdmMedicationRequestResponse> GetId(Guid id)
        {
            return _mapper.Map<CdmMedicationRequestResponse>(await _repository.GetAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async  Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPatientId(Guid patientId, Guid parentId)
        {
            return _mapper.Map<List<CdmMedicationRequestResponse>>(await _repository.GetAllListAsync(x => x.Subject.Id == patientId && x.BasedOnOwnerId == parentId.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPractitionerId(Guid practitionerId, Guid parentId)
        {
            return _mapper.Map<List<CdmMedicationRequestResponse>>(await _repository.GetAllListAsync(x => x.PerformerOwnerId == practitionerId.ToString() && x.BasedOnOwnerId == parentId.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="cdmPractitioner"></param>
        /// <returns></returns>
        public async Task<List<CdmMedicationRequestResponse>> Create(List<CdmMedicationRequestInput> input, Person cdmPractitioner)
        {
            var medicationRequestInput = input.FirstOrDefault(); //get the first element in the list
            input.Remove(medicationRequestInput); //remove the first element from the list of medication requests

            //save the first element independently and update its BasedOn property with its Id (database)
            var entity = _mapper.Map<CdmMedicationRequest>(medicationRequestInput);
            _mapper.Map(cdmPractitioner, medicationRequestInput);

            var insertedEntity = await _repository.InsertAsync(entity);
            insertedEntity.BasedOnOwnerId = insertedEntity.Id.ToString();
            insertedEntity.BasedOnOwnerType = insertedEntity.GetTypeShortAlias();
            var updatedEntity = await _repository.UpdateAsync(insertedEntity);

            //add the list without the first object and set their "BasedOn" property to the Id of the first object
            List<CdmMedicationRequest> medicationRequestList = new List<CdmMedicationRequest>();
            medicationRequestList.Add(updatedEntity);
            if (input != null && input?.Count() > 0)
            {
                var taskMedicationRequests = new List<Task<CdmMedicationRequest>>(); //Tasks lists to handle batch insert into database
                input.ForEach((v) => taskMedicationRequests.Add(CreateMedicationRequest(v, updatedEntity)));
                var medicationRequests = ((IList<CdmMedicationRequest>)await Task.WhenAll(taskMedicationRequests)); //save medication request to db
                medicationRequestList.AddRange(medicationRequests.ToList());
            }

            ////Getting document content for referral letter and mapping practitioner, patient and referral letter info to referralcontent object
            var outcome = await _serviceRequestDocumentHelper.CreateScriptDocument(cdmPractitioner, medicationRequestList);

            return outcome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CdmMedicationRequestResponse> Update(CdmMedicationRequestUpdate input)
        {
            var medicationRequest = await _repository.GetAsync(input.Id);
            _mapper.Map(input, medicationRequest);
            var updatedMedicatioRequest = await _repository.UpdateAsync(medicationRequest);

            return _mapper.Map<CdmMedicationRequestResponse>(updatedMedicatioRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private async Task<CdmMedicationRequest> CreateMedicationRequest(CdmMedicationRequestInput input, CdmMedicationRequest parent)
        {
            var insertedEntity = new CdmMedicationRequest();
            using (var uow = _unitOfWork.Begin())
            {
                var entity = _mapper.Map<CdmMedicationRequest>(input);
                entity.BasedOnOwnerId = parent.Id.ToString();
                entity.BasedOnOwnerType = parent.GetTypeShortAlias();
                entity.PerformerOwnerId = parent.PerformerOwnerId;
                entity.PerformerOwnerType = parent.PerformerOwnerType;
                insertedEntity = await _repository.InsertAsync(entity);

                uow.Complete();
            }

            return insertedEntity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private async Task<CdmMedicationRequest> UpdateMedicationRequest(CdmMedicationRequestUpdate input, CdmMedicationRequest parent)
        {
            var insertedEntity = new CdmMedicationRequest();
            using (var uow = _unitOfWork.Begin())
            {
                var entity = _mapper.Map<CdmMedicationRequest>(input);
                entity.BasedOnOwnerId = parent.Id.ToString();
                entity.BasedOnOwnerType = parent.GetTypeShortAlias();
                entity.PerformerOwnerId = parent.PerformerOwnerId;
                entity.PerformerOwnerType = parent.PerformerOwnerType;
                insertedEntity = await _repository.UpdateAsync(entity);

                uow.Complete();
            }

            return insertedEntity;
        }
    }
}
