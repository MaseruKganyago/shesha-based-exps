using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsultationReportContent
    {
        /// <summary>
        /// 
        /// </summary>
        private ConsultationReportContent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string PractitionerTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HealthCareProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HPCSANumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DispensaryNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhysicalAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactDetail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EvaluationLocation { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string PatientFullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PatientGender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PatientAge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Symptoms> Symptoms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ProvisionalDiagnosis> ProvisionalDiagnosis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClinicalManagement ClinicalManagement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EScriptRegionData> EScriptRegionData { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string AuthoredOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QualificationIssuerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private RefListQualificationCodes CodeLkp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QualificationName => UtilityHelper.GetRefListItemText("Fhir", "QualificationCodes", (int)this.CodeLkp);
        /// <summary>
        /// 
        /// </summary>
        public string PractitionerRole { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable PatientSymptoms { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DataTable PatientProvisionDiagnoses { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DataTable MedicationRequests { get; set; }
    }
}
