using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services.Enums;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Notes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationStatements.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class MedicationStatementsCrudHelper: SheshaAppServiceBase, ITransientDependency, IMedicationStatementsCrudHelper
    {
        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<MedicationStatement, Guid> _repository;
        private readonly IRepository<Note, Guid> _noteRepository;
        private readonly IRepository<Dosage, Guid> _dosageRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="noteRepository"></param>
        /// <param name="dosageRepository"></param>
        public MedicationStatementsCrudHelper(IUnitOfWorkManager unitOfWork,
            IMapper mapper,
            IRepository<MedicationStatement, Guid> repository,
            IRepository<Note, Guid> noteRepository,
            IRepository<Dosage, Guid> dosageRepository)
		{
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
            _noteRepository = noteRepository;
            _dosageRepository = dosageRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<MedicationStatementResponse>> GetAllAsync()
        {
           return await MedicationStatementUtilityHelper.GetAllMedicationsStatementsWithBackboneElements(RefListFilterIdType.none, Guid.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MedicationStatementResponse> GetByIdAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "id cannot be null.");

            var entity = await _repository.GetAsync(id);
            if (entity == null) throw new UserFriendlyException("MedicationStatement with specified id does not exist.");

            var medicationStatementResult = _mapper.Map<MedicationStatementResponse>(entity);
            await MapBackDosages(medicationStatementResult); //Gets all Backbone elements dosages related to entity
            await MapBackNotes(medicationStatementResult); //Gets all Backbone elements dosages related to entity

            return medicationStatementResult;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		public async Task<List<MedicationStatementResponse>> GetByPatientIdAsync(Guid patientId)
        {
            Validation.ValidateIdWithException(patientId, "patientId cannot be null.");

            return await MedicationStatementUtilityHelper.GetAllMedicationsStatementsWithBackboneElements(RefListFilterIdType.patientId, patientId);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
		public async Task<List<MedicationStatementResponse>> GetByPractitionerIdAsync(Guid practitionerId)
		{
            Validation.ValidateIdWithException(practitionerId, "practitionerId cannot be null.");

            return await MedicationStatementUtilityHelper.GetAllMedicationsStatementsWithBackboneElements(RefListFilterIdType.practitionerId, practitionerId);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<MedicationStatementResponse> CreateOrUpdateAsync(MedicationStatementInput input)
        {
            var entity = new MedicationStatement();
            var saveNotesTasks = new List<Task<NoteDto>>();
            var saveDosageTasks = new List<Task<DosageResponse>>();

            using (var uow = _unitOfWork.Begin())
            {
                entity = await SaveOrUpdateEntityAsync<MedicationStatement>((Guid?)Validation.ValidateId(input.Id), async item =>
                {
                    ObjectMapper.Map(input, item);
                    item.IsDeleted = false;
                });

                if (input.Notes?.Count > 0)
                {
                    input.Notes.ForEach(note => saveNotesTasks.Add(SaveUpdateNote(note, entity)));
                }

                if (input.Dosage?.Count > 0)
                {
                    input.Dosage.ForEach(dosage => saveDosageTasks.Add(SaveUpdateDosage(dosage, entity)));
                }
                uow.Complete();
            }
            //await _unitOfWork.Current.SaveChangesAsync();

            var result = _mapper.Map<MedicationStatementResponse>(entity);
            result.Notes = (await Task.WhenAll(saveNotesTasks)).ToList<NoteDto>();
            result.Dosage = (await Task.WhenAll(saveDosageTasks)).ToList<DosageResponse>();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            Validation.ValidateIdWithException(id, "id cannot be null.");

            var entity = await _repository.GetAsync(id);
            if (entity == null) throw new UserFriendlyException("MedicationStatement with specified id does not exist.");

            await _repository.DeleteAsync(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dosage"></param>
        /// <param name="medicationStatement"></param>
        /// <returns></returns>
		private async Task<DosageResponse> SaveUpdateDosage(DosageInput dosage, MedicationStatement medicationStatement)
		{
            var entityResult = await SaveOrUpdateEntityAsync<Dosage>((Guid?)Validation.ValidateId(dosage.Id), async item => {
                ObjectMapper.Map(dosage, item);
                item.OwnerId = medicationStatement.Id.ToString();
                item.OwnerType = medicationStatement.GetTypeShortAlias();
            });

            return _mapper.Map<DosageResponse>(entityResult);
		}

        private async Task MapBackDosages(MedicationStatementResponse medicationStatementResult)
        {
            var list = await _dosageRepository.GetAll().Where(a => a.OwnerId == medicationStatementResult.Id.ToString()).ToListAsync();
            medicationStatementResult.Dosage = list?.Count > 0 ? _mapper.Map<List<DosageResponse>>(list) : null;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="note"></param>
		/// <param name="medicationStatement"></param>
		/// <returns></returns>
		private async Task<NoteDto> SaveUpdateNote(CreateNoteDto note, MedicationStatement medicationStatement)
		{
            var noteEntity = await SaveOrUpdateEntityAsync<Note>((Guid?)Validation.ValidateId(note.Id), async item => {
                ObjectMapper.Map(note, item);
                item.OwnerId = medicationStatement.Id.ToString();
                item.OwnerType = medicationStatement.GetTypeShortAlias();
                item.Author = medicationStatement.InformationSource; //InformationSource: Person or organization that provided the information about the taking of this medication
            });

            return _mapper.Map<NoteDto>(noteEntity);
		}

        private async Task MapBackNotes(MedicationStatementResponse medicationStatementResult)
        {
            var list = await _noteRepository.GetAllListAsync(a => a.OwnerId == medicationStatementResult.Id.ToString());
            medicationStatementResult.Notes = _mapper.Map<List<NoteDto>>(list);
        }
    }
}
