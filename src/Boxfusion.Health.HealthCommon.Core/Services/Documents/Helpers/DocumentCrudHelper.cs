using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boxfusion.Health.HealthCommon.Core.Services.Documents.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentCrudHelper : IDocumentCrudHelper, ITransientDependency
    {
		private readonly IRepository<Document, Guid> _repository;
		private readonly IRepository<EncounterLocation, Guid> _encounterLocationRepository;
		private readonly ICdmSettings _cdmSettings;
		private readonly IMapper _mapper;
		private readonly IStoredFileService _storedFileService;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="encounterLocationRepository"></param>
		/// <param name="cdmSettings"></param>
		/// <param name="mapper"></param>
		/// <param name="storedFileService"></param>
		public DocumentCrudHelper(
			IRepository<Document, Guid> repository, 
			IRepository<EncounterLocation, Guid> encounterLocationRepository, 
			ICdmSettings cdmSettings, 
			IMapper mapper,
			IStoredFileService storedFileService)
        {
            _repository = repository;
            _encounterLocationRepository = encounterLocationRepository;
            _cdmSettings = cdmSettings;
			_mapper = mapper;
			_storedFileService = storedFileService;

		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<DocumentResponse>> GetByConsultationIdAsync(Guid encounterId, Guid patientId)
		{
			var document = await _repository.GetAllListAsync(x => x.Subject.Id == patientId && x.Encounter.Id == encounterId);
			var documentResponses = _mapper.Map<List<DocumentResponse>>(document);
			var encounterLocation = await _encounterLocationRepository.FirstOrDefaultAsync(x => x.Location.Id == Guid.Parse(_cdmSettings.FacilityIdentifier));

			if (documentResponses.Any())
				documentResponses.ForEach(x => x.Location = _mapper.Map<EncounterLocationResponse>(encounterLocation));

			return documentResponses;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public async Task<List<DocumentResponse>> GetByConsultationTypeAsync(Guid patientId, int type)
		{
			var document = await _repository.GetAllListAsync(a => a.Subject.Id == patientId && a.Type == (RefListDocumentTypeValueSets)type);
			var documentResponses = _mapper.Map<List<DocumentResponse>>(document);
			var encounterLocation = await _encounterLocationRepository.FirstOrDefaultAsync(x => x.Location.Id == Guid.Parse(_cdmSettings.FacilityIdentifier));

			if (documentResponses.Any())
				documentResponses.ForEach(x => x.Location = _mapper.Map<EncounterLocationResponse>(encounterLocation));

			return documentResponses;
		}

		///// <summary>
		///// 
		///// </summary>
		///// <param name="patientId"></param>
		///// <param name="type"></param>
		///// <returns></returns>
		//public async Task<DocumentResponse> CreateAsync(DocumentInput input)
		//{
		//	var document = _mapper.Map<Document>(input);
		//	var insertDocument = await _repository.InsertAsync(document);
		//	var documentResponse = _mapper.Map<DocumentResponse>(insertDocument);
		//	var encounterLocation = await _encounterLocationRepository.FirstOrDefaultAsync(x => x.Location.Id == Guid.Parse(_cdmSettings.FacilityIdentifier));

		//	if (documentResponse != null)
		//		documentResponse.Location = _mapper.Map<EncounterLocationResponse>(encounterLocation);

		//	return documentResponse;
		//}
	}
}
