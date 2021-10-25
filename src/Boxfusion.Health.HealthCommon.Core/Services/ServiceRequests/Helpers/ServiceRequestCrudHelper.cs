using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Extentions;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class ServiceRequestCrudHelper<T,TResult> : IServiceRequestCrudHelper<T, TResult>, ITransientDependency where T : CdmServiceRequest where TResult : class
    {
        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IRepository<T, Guid> _repository;
        private readonly IRepository<Note, Guid> _noteRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="repository"></param>
        /// <param name="noteRepository"></param>
        /// <param name="mapper"></param>
        public ServiceRequestCrudHelper(
            IUnitOfWorkManager unitOfWork, 
            IRepository<T, Guid> repository, 
            IRepository<Note, Guid> noteRepository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _noteRepository = noteRepository;
            _mapper = mapper;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TResult>> GetAllAsync()
        {
            var serviceRequests = await _repository.GetAllListAsync();
            return _mapper.Map<List<TResult>>(serviceRequests);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TResult> GetAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "Id cannot be empty");
            var serviceRequest = await _repository.GetAsync(id);
            return _mapper.Map<TResult>(serviceRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<TResult>> GetByPatientAsync(Guid patientId)
        {
            var serviceRequests = await _repository.GetAllListAsync(x => x.Subject.Id == patientId);
            return _mapper.Map<List<TResult>>(serviceRequests);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<TResult>> GetByPratitionerAsync(Guid practitionerId)
        {
            var serviceRequests = await _repository.GetAllListAsync(x => x.Subject.Id == practitionerId);
            return _mapper.Map<List<TResult>>(serviceRequests);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<TResult> CreateAsync(CdmServiceRequestInput input, T entity, Func<Task> action = null) 
        {
            var serviceRequest = await _repository.InsertAsync(entity);
            List<NoteResponse> notes = null;

            //Handles all BackboneElements related to service request 
            if (input?.Notes?.Count > 0)
            {
                var taskNotes = new List<Task<NoteResponse>>(); //Tasks lists to handle batch insert into database
                input.Notes.ForEach((noteInput) => taskNotes.Add(CreateNoteAsync(noteInput, serviceRequest)));
                var noteResponses = ((IList<NoteResponse>)await Task.WhenAll(taskNotes)); //save identifiers to db
                notes = noteResponses.ToList();
            }

            var serviceRequestResponse =  _mapper.Map<TResult>(serviceRequest);
            UtilityHelper.TrySetProperty(serviceRequestResponse, "Notes", notes);

            //Additional logic from sub classes
            if (action != null) await action.Invoke();

            return serviceRequestResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<TResult> UpdateAsync(CdmServiceRequestInput input, T entity, Func<Task> action = null)
        {
            var serviceRequest = await _repository.UpdateAsync(entity);
            List<NoteResponse> notes = null;

            //Handles all BackboneElements related to service request 
            if (input?.Notes?.Count > 0 && !input.Notes.Any(x => x.Id == null || x.Id is Guid guid && guid == Guid.Empty))
            {
                var taskNotes = new List<Task<NoteResponse>>(); //Tasks lists to handle batch insert into database
                input.Notes.ForEach((noteInput) => taskNotes.Add(UpdateNoteAsync(noteInput, serviceRequest)));
                var noteResponses = ((IList<NoteResponse>)await Task.WhenAll(taskNotes)); //save notes to db
                notes = noteResponses.ToList();
            }

            var serviceRequestResponse = _mapper.Map<TResult>(serviceRequest);
            UtilityHelper.TrySetProperty(serviceRequestResponse, "Notes", notes);

            //Additional logic from sub classes
            if (action != null) await action.Invoke();

            return serviceRequestResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "Service Request Id cannot be empty");
            await _repository.DeleteAsync(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
		private async Task<NoteResponse> CreateNoteAsync<T>(NoteInput input, T ownerEntity) where T : ServiceRequest
        {
            var entity = _mapper.Map<Note>(input);
            using (var uow = _unitOfWork.Begin())
            {
                entity = await _noteRepository.InsertAsync(entity);
                entity.OwnerId = ownerEntity.Id.ToString();
                entity.OwnerType = ownerEntity.GetType().GetAttributeValue((EntityAttribute dna) => dna.TypeShortAlias);
                uow.Complete();
            }
            var noteResponse = _mapper.Map<NoteResponse>(entity);

            return noteResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<NoteResponse> UpdateNoteAsync<T>(NoteInput input, T ownerEntity) where T : ServiceRequest
        {
            var entity = await _noteRepository.GetAsync(input.Id);
            _mapper.Map(input, entity);

            using (var uow = _unitOfWork.Begin())
            {
                entity = await _noteRepository.UpdateAsync(entity);
                entity.OwnerId = ownerEntity.Id.ToString();
                entity.OwnerType = ownerEntity.GetTypeShortAlias();
                uow.Complete();
            }

            return _mapper.Map<NoteResponse>(entity);
        }
    }
}
