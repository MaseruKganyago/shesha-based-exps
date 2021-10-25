using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Reports;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.Referrals;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.Covid19;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helper;
using Microsoft.AspNetCore.Http;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using System.Linq;
using Shesha.StoredFiles.Dto;
using Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile;
using System.Data;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using FastMember;

namespace Boxfusion.Health.HealthCommon.Core.Services.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentHelper: IDocumentHelper, ITransientDependency
    {
        private readonly IDocumentProcessor<ReferralFacilityContent> _documentProcessorReferralFacilityContent;
        private readonly IDocumentProcessor<Covid19TestReferralContent> _documentProcessorCovid19TestReferralContent;
        private readonly IDocumentProcessor<ConsultationReportContent> _documentProcessorConsultationReportContent;
        private readonly IDocumentProcessor<EScriptContent> _documentScriptProcessor;
        private readonly IDocumentProcessorHelper _documentProcessorHelper;
        private readonly ICdmSettings _cdmSettings;
        private readonly IRepository<Document, Guid> _documentRepository;
        private readonly IRepository<StoredFile, Guid> _fileRepository;
        private readonly IRepository<CdmPatient, Guid> _patientRepository;
        private readonly IStoredFileService _fileService;
        private readonly ISaveFileDocument _saveFileDocument;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentProcessorReferralFacilityContent"></param>
        /// <param name="documentProcessorCovid19TestReferralContent"></param>
        /// <param name="documentProcessorConsultationReportContent"></param>
        /// <param name="documentScriptProcessor"></param>
        /// <param name="documentProcessorHelper"></param>
        /// <param name="cdmSettings"></param>
        /// <param name="documentRepository"></param>
        /// <param name="fileRepository"></param>
        /// <param name="fileService"></param>
        /// <param name="patientRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="saveFileDocument"></param>
        public DocumentHelper(
            IDocumentProcessor<ReferralFacilityContent> documentProcessorReferralFacilityContent,
            IDocumentProcessor<Covid19TestReferralContent> documentProcessorCovid19TestReferralContent,
            IDocumentProcessor<ConsultationReportContent> documentProcessorConsultationReportContent,
            IDocumentProcessor<EScriptContent> documentScriptProcessor,
            IDocumentProcessorHelper documentProcessorHelper, 
            ICdmSettings cdmSettings,
            IRepository<Document, Guid> documentRepository, 
            IRepository<StoredFile, Guid> fileRepository, IStoredFileService fileService,
            IRepository<CdmPatient, Guid> patientRepository,
            IMapper mapper,
            ISaveFileDocument saveFileDocument)
        {
            _documentProcessorReferralFacilityContent = documentProcessorReferralFacilityContent;
            _documentProcessorCovid19TestReferralContent = documentProcessorCovid19TestReferralContent;
            _documentProcessorConsultationReportContent = documentProcessorConsultationReportContent;
            _documentProcessorHelper = documentProcessorHelper;
            _cdmSettings = cdmSettings;
            _documentRepository = documentRepository;
            _patientRepository = patientRepository;
            _fileRepository = fileRepository;
            _fileService = fileService;
            _mapper = mapper;
            _saveFileDocument = saveFileDocument;
            _documentScriptProcessor = documentScriptProcessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitioner"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public async Task<ReferralServiceRequestResponse> CreateReferToFacilityDocument(Person practitioner, ReferralServiceRequest output)
        {
            //Getting document content for referral letter and mapping practitioner, patient and referral letter info to referralcontent object
            var referralLetterContent = Util.GetReferralLetterInfo(Guid.Parse(_cdmSettings.OrganisationIdentifier), Guid.Parse(_cdmSettings.FacilityIdentifier), practitioner.Id);
            _mapper.Map(output, referralLetterContent);
            var content = _mapper.Map(practitioner, referralLetterContent);
            var stream = _documentProcessorReferralFacilityContent.GeneratePDF(content, RefListDocumentTypeValueSets.ReferralToFacility);

            var doc = await _documentProcessorHelper.SaveFileAsync(stream, output.Subject, RefListDocumentTypeValueSets.Covid19);
            var document = _mapper.Map<Document>(output);
            _mapper.Map(practitioner, document);
            document.StoredFile = doc;
            await _documentRepository.InsertAsync(document);


            var outcome = _mapper.Map<ReferralServiceRequestResponse>(output);
            outcome.ReferralLetterPath = doc.GetFileUrl();
            outcome.FileId = doc.Id;

            return outcome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public async Task<ReferralServiceRequestResponse> UpdateReferToFacilityDocument(ReferralServiceRequestUpdate input, Person practitioner, ReferralServiceRequest output)
        {
            //Getting document content for referral letter and mapping practitioner, patient and referral letter info to referralcontent object
            var referralLetterContent = Util.GetReferralLetterInfo(Guid.Parse(_cdmSettings.OrganisationIdentifier), Guid.Parse(_cdmSettings.FacilityIdentifier), practitioner.Id);
            _mapper.Map(output, referralLetterContent);
            var content = _mapper.Map(practitioner, referralLetterContent);

            await DeleteOriginalFile(input.FileId); //delete originally created file and generate a new one with the updated information
            await _documentRepository.DeleteAsync(input.DocumentId); //delete original document

            //Generate new covid19 letter
            var stream = _documentProcessorReferralFacilityContent.GeneratePDF(content, RefListDocumentTypeValueSets.ReferralToFacility);

            var doc = await _documentProcessorHelper.SaveFileAsync(stream, output.Subject, RefListDocumentTypeValueSets.Covid19);
            var document = _mapper.Map<Document>(output);
            _mapper.Map(practitioner, document);
            document.StoredFile = doc;
            await _documentRepository.InsertAsync(document);


            var outcome = _mapper.Map<ReferralServiceRequestResponse>(output);
            outcome.ReferralLetterPath = doc.GetFileUrl();
            outcome.FileId = doc.Id;
            return outcome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitioner"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<DiagnosticTestServiceRequestResponse> CreateCovid19TestReferralDocument(Person practitioner, DiagnosticTestServiceRequest entity)
        {
            //Getting document content for covid19 letter and mapping practitioner, patient and referral letter info to referralcontent object            
            var covid19TestReferralContent = Util.GetCovid19TestReferralContentInfo(Guid.Parse(_cdmSettings.OrganisationIdentifier), Guid.Parse(_cdmSettings.FacilityIdentifier), practitioner.Id);
            _mapper.Map(entity, covid19TestReferralContent);
            var content = _mapper.Map(practitioner, covid19TestReferralContent);

            //Generate new covid19 letter
            var stream = _documentProcessorCovid19TestReferralContent.GeneratePDF(content, RefListDocumentTypeValueSets.Covid19);

            var doc = await _documentProcessorHelper.SaveFileAsync(stream, entity.Subject, RefListDocumentTypeValueSets.Covid19);
            var document = _mapper.Map<Document>(entity);
            _mapper.Map(practitioner, document);
            document.StoredFile = doc;
            await _documentRepository.InsertAsync(document);



            var outcome = _mapper.Map<DiagnosticTestServiceRequestResponse>(entity);
            outcome.Covid19TestReferralPath = doc.GetFileUrl();
            outcome.FileId = doc.Id;
            return outcome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<DiagnosticTestServiceRequestResponse> UpdateCovid19TestReferralDocument(DiagnosticTestServiceRequestUpdate input, Person practitioner, DiagnosticTestServiceRequest entity)
        {
            //Getting document content for referral letter and mapping practitioner, patient and referral letter info to referralcontent object
            var covid19TestReferralContent = Util.GetCovid19TestReferralContentInfo(Guid.Parse(_cdmSettings.OrganisationIdentifier), Guid.Parse(_cdmSettings.FacilityIdentifier), practitioner.Id);
            _mapper.Map(entity, covid19TestReferralContent);
            var content = _mapper.Map(practitioner, covid19TestReferralContent);

            await DeleteOriginalFile(input.FileId); //delete originally created file and generate a new one with the updated information
            await _documentRepository.DeleteAsync(input.DocumentId); //delete original document

            //Generate new covid19 letter
            var stream = _documentProcessorCovid19TestReferralContent.GeneratePDF(content, RefListDocumentTypeValueSets.Covid19);

            var doc = await _documentProcessorHelper.SaveFileAsync(stream, entity.Subject, RefListDocumentTypeValueSets.Covid19);
            var document = _mapper.Map<Document>(entity);
            _mapper.Map(practitioner, document);
            document.StoredFile = doc;
            await _documentRepository.InsertAsync(document);

            var outcome = _mapper.Map<DiagnosticTestServiceRequestResponse>(entity);
            outcome.Covid19TestReferralPath = doc.GetFileUrl();
            outcome.FileId = doc.Id;
            return outcome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitioner"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public async Task<List<CdmMedicationRequestResponse>> CreateScriptDocument(Person practitioner, List<CdmMedicationRequest> output)
        {
            var eScriptInfo = Util.GetEScriptContentInfo(Guid.Parse(_cdmSettings.OrganisationIdentifier), Guid.Parse(_cdmSettings.FacilityIdentifier), practitioner.Id);
            _mapper.Map(output.FirstOrDefault(), eScriptInfo);
            _mapper.Map(practitioner, eScriptInfo);
            var patient = await _patientRepository.GetAsync(output.FirstOrDefault().Subject.Id);
            _mapper.Map(patient, eScriptInfo);
            eScriptInfo.MedicationRequests = GetEScriptRegionData(
                output.Select(x => new EScriptRegionData
                {
                    Key = $"{x.MedicationName}, {x.Dosage}, {x.Route}, {x.Frequency}, {x.Duration}, {x.Repeat}, {x.Instruction}",
                    Quantity = x.Quantity.ToString()
                }).ToList());

            var stream = _documentScriptProcessor.GeneratePDF(eScriptInfo, RefListDocumentTypeValueSets.eScript);
            var doc = await _documentProcessorHelper.SaveFileAsync(stream, patient, RefListDocumentTypeValueSets.eScript);
            var document = _mapper.Map<Document>(output.FirstOrDefault());

            var outcome = _mapper.Map<List<CdmMedicationRequestResponse>>(output);
            outcome.ForEach(x => x.EScriptPath = doc.GetFileUrl());
            outcome.ForEach(x => x.FileId = doc.Id);
            return outcome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultationReportContent"></param>
        /// <param name="patient"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        public async Task CreateConsultationReportDocument(ConsultationReportContent consultationReportContent, CdmPatient patient, CdmPractitioner practitioner)
        {
            ////Create a consultation report note
            var stream = _documentProcessorConsultationReportContent.GeneratePDF(consultationReportContent, RefListDocumentTypeValueSets.ConsultationReport);
            var doc = await _documentProcessorHelper.SaveFileAsync(stream, patient, RefListDocumentTypeValueSets.Covid19);
            var document = _mapper.Map<Document>(consultationReportContent);

            _mapper.Map(practitioner, document);
            document.StoredFile = doc;
            await _documentRepository.InsertAsync(document);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteOriginalFile(Guid id)
        {
            //delete originally created file
            var file = await _fileRepository.GetAsync(id);
            await _fileService.DeleteAsync(file);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eScriptRegionData"></param>
        /// <returns></returns>
        public DataTable GetEScriptRegionData(List<EScriptRegionData> eScriptRegionData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(eScriptRegionData))
            {
                table.Load(reader);
            }

            table.TableName = "MedicationRequestContent";
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symptoms"></param>
        /// <returns></returns>
        public DataTable GetPatientSymtoms(List<Symptoms> symptoms)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(symptoms))
            {
                table.Load(reader);
            }

            table.TableName = "Symptoms";
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provisionalDiagnoses"></param>
        /// <returns></returns>
        public DataTable GetPatientDiagnosis(List<ProvisionalDiagnosis> provisionalDiagnoses)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(provisionalDiagnoses))
            {
                table.Load(reader);
            }

            table.TableName = "ProvisionalDiagnosis";
            return table;
        }
    }
}
