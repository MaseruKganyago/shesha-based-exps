using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Shesha.Domain;
using Shesha.StoredFiles.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitioner"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> CreateReferToFacilityDocument(Person practitioner, ReferralServiceRequest output);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        Task<ReferralServiceRequestResponse> UpdateReferToFacilityDocument(ReferralServiceRequestUpdate input, Person practitioner, ReferralServiceRequest output);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitioner"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> CreateCovid19TestReferralDocument(Person practitioner, DiagnosticTestServiceRequest entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="practitioner"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<DiagnosticTestServiceRequestResponse> UpdateCovid19TestReferralDocument(DiagnosticTestServiceRequestUpdate input, Person practitioner, DiagnosticTestServiceRequest entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitioner"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> CreateScriptDocument(Person practitioner, List<CdmMedicationRequest> output);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultationReportContent"></param>
        /// <param name="patient"></param>
        /// <param name="practitioner"></param>
        /// <returns></returns>
        Task CreateConsultationReportDocument(ConsultationReportContent consultationReportContent, CdmPatient patient, CdmPractitioner practitioner);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteOriginalFile(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicationRequestContents"></param>
        /// <returns></returns>
        DataTable GetEScriptRegionData(List<EScriptRegionData> medicationRequestContents);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symptoms"></param>
        /// <returns></returns>
        DataTable GetPatientSymtoms(List<Symptoms> symptoms);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provisionalDiagnoses"></param>
        /// <returns></returns>
        DataTable GetPatientDiagnosis(List<ProvisionalDiagnosis> provisionalDiagnoses);
    }
}
