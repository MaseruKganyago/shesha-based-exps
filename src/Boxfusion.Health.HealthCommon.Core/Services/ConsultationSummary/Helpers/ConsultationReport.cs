using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsultationReport : IConsultationReport, ITransientDependency
    {
        //consultation report
        private readonly IRepository<CdmPatient, Guid> _patientRepository;
        private readonly IRepository<CdmPractitioner, Guid> _practitionerRepository;
        private readonly IRepository<Encounter, Guid> _encounterRepository;
        private readonly IRepository<Condition, Guid> _conditionRepository;
        private readonly IRepository<ConditionIcdTenCode, Guid> _conditionIcdTenCodeRepository;
        private readonly IRepository<ChwVisitServiceRequest, Guid> _chwVisitServiceRequestRepository;
        private readonly IRepository<AmbulanceServiceRequest, Guid> _ambulanceServiceRequestRepository;
        private readonly IRepository<ReferralServiceRequest, Guid> _referralServiceRequestRepository;
        private readonly IRepository<DiagnosticTestServiceRequest, Guid> _diagnosticTestServiceRequestRepository;
        private readonly IRepository<Document, Guid> _documentRepository;
        private readonly IRepository<CdmMedicationRequest, Guid> _medicationRequestRepository;
        private readonly ICdmSettings _cdmSettings;
        private readonly IMapper _mapper;
        private readonly IDocumentHelper _serviceRequestDocumentHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientRepository"></param>
        /// <param name="practitionerRepository"></param>
        /// <param name="encounterRepository"></param>
        /// <param name="conditionRepository"></param>
        /// <param name="conditionIcdTenCodeRepository"></param>
        /// <param name="chwVisitServiceRequestRepository"></param>
        /// <param name="ambulanceServiceRequestRepository"></param>
        /// <param name="referralServiceRequestRepository"></param>
        /// <param name="diagnosticTestServiceRequestRepository"></param>
        /// <param name="documentReferenceRepository"></param>
        /// <param name="medicationRequestRepository"></param>
        /// <param name="cdmSettings"></param>
        /// <param name="mapper"></param>
        /// <param name="serviceRequestDocumentHelper"></param>
        public ConsultationReport(
            IRepository<CdmPatient, Guid> patientRepository, 
            IRepository<CdmPractitioner, Guid> practitionerRepository, 
            IRepository<Encounter, Guid> encounterRepository, 
            IRepository<Condition, Guid> conditionRepository, 
            IRepository<ConditionIcdTenCode, Guid> conditionIcdTenCodeRepository, 
            IRepository<ChwVisitServiceRequest, Guid> chwVisitServiceRequestRepository, 
            IRepository<AmbulanceServiceRequest, Guid> ambulanceServiceRequestRepository, 
            IRepository<ReferralServiceRequest, Guid> referralServiceRequestRepository, 
            IRepository<DiagnosticTestServiceRequest, Guid> diagnosticTestServiceRequestRepository, 
            IRepository<Document, Guid> documentRepository, 
            IRepository<CdmMedicationRequest, Guid> medicationRequestRepository, 
            ICdmSettings cdmSettings, 
            IMapper mapper, 
            IDocumentHelper serviceRequestDocumentHelper)
        {
            _patientRepository = patientRepository;
            _practitionerRepository = practitionerRepository;
            _encounterRepository = encounterRepository;
            _conditionRepository = conditionRepository;
            _conditionIcdTenCodeRepository = conditionIcdTenCodeRepository;
            _chwVisitServiceRequestRepository = chwVisitServiceRequestRepository;
            _ambulanceServiceRequestRepository = ambulanceServiceRequestRepository;
            _referralServiceRequestRepository = referralServiceRequestRepository;
            _diagnosticTestServiceRequestRepository = diagnosticTestServiceRequestRepository;
            _documentRepository = documentRepository;
            _medicationRequestRepository = medicationRequestRepository;
            _cdmSettings = cdmSettings;
            _mapper = mapper;
            _serviceRequestDocumentHelper = serviceRequestDocumentHelper;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task GenerateConsultationReport(ConsultationSummaryInput input)
        {
            var patient = await _patientRepository.GetAsync(input.PatientId);
            var practitioner = await _practitionerRepository.GetAsync(input.PractitionerId);
            var encounter = await _encounterRepository.GetAsync(input.EncounterId);

            //Getting document content for referral letter and mapping practitioner, patient and referral letter info to referralcontent object            
            var consultationReportContent = Util.GetConsultationReportContentInfo(Guid.Parse(_cdmSettings.OrganisationIdentifier), Guid.Parse(_cdmSettings.FacilityIdentifier), practitioner.Id);
            _mapper.Map(practitioner, consultationReportContent);
            _mapper.Map(patient, consultationReportContent);
            _mapper.Map(encounter, consultationReportContent);

            //set sysmptoms
            consultationReportContent.PatientSymptoms = _serviceRequestDocumentHelper.GetPatientSymtoms(_conditionIcdTenCodeRepository.GetAll().Where(x => x.Condition.Subject.Id == patient.Id && x.Condition.Encounter.Id == input.EncounterId && x.Condition.Asserter.Id == patient.Id)
                .Select(x => new Symptoms
                {
                    Description = x.IcdTenCode.ICDTenThreeCodeDesc
                }).ToList());

            //set provisional diagnosis
            consultationReportContent.PatientProvisionDiagnoses = _serviceRequestDocumentHelper.GetPatientDiagnosis(_conditionIcdTenCodeRepository.GetAll().Where(x => x.Condition.Subject.Id == patient.Id && x.Condition.Encounter.Id == input.EncounterId && x.Condition.Asserter.Id != patient.Id)
                .Select(x => new ProvisionalDiagnosis
                {
                    Description = x.IcdTenCode.ICDTenThreeCodeDesc
                }).ToList());

            //set clinical management
            consultationReportContent.ClinicalManagement = new ClinicalManagement
            {
                AmbulanceServiceRequestMessage = _ambulanceServiceRequestRepository.GetAll().Any(x => x.Subject.Id == patient.Id && x.Encounter.Id == input.EncounterId) ? "Call Ambulance" : "",
                ChwServiceRequestMessage = _chwVisitServiceRequestRepository.GetAll().Any(x => x.Subject.Id == patient.Id && x.Encounter.Id == input.EncounterId) ? "Requested a CHW visit" : "",
                Covid19ServiceRequestMessage = _diagnosticTestServiceRequestRepository.GetAll().Any() ? "Covid-19 Referral" : "",
                ReferToFacilityServiceRequestMessage = _referralServiceRequestRepository.GetAll().Any() ? "Refer to Facility (Clinic, Hospital)" : "",
                ReferToPractitionerServiceRequestMessage = _referralServiceRequestRepository.GetAll().Any() ? "Escalate to Dr" : "",
                SickNoteMessage = _documentRepository.GetAll().Any(x => x.Type == RefListDocumentTypeValueSets.SickNote && x.Subject.Id == patient.Id && x.Encounter.Id == input.EncounterId) ? "Issue Sick Note" : ""
            };

            //set medication requests
            consultationReportContent.MedicationRequests = _serviceRequestDocumentHelper.GetEScriptRegionData(_medicationRequestRepository.GetAll().Where(x => x.Subject.Id == patient.Id && x.Encounter.Id == input.EncounterId)
                .Select(x => new EScriptRegionData
                {
                    Key = $"{x.MedicationName}, {x.Dosage}, {x.Route}, {x.Frequency}, {x.Duration}, {x.Repeat}, {x.Instruction}",
                    Quantity = x.Quantity.ToString()
                }).ToList());

            await _serviceRequestDocumentHelper.CreateConsultationReportDocument(consultationReportContent, patient, practitioner);
        }
    }
}
