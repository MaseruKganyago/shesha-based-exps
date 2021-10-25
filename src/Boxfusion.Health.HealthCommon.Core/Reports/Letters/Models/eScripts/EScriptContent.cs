using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts
{

    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(MedicationRequest))]
    public class EScriptContent
    {
        /// <summary>
        /// 
        /// </summary>
        private EScriptContent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string PractitionerTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PractitionerInitials { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PractitionerSurname { get; set; }
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
        public string PatientMedicalAidName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PatientMedicalAidNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PatientContactNumber { get; set; }

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

        ///// <summary>
        ///// 
        ///// </summary>
        //public List<MedicationRequestContent> medicationRequestContents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable MedicationRequests { get; set; }
    }
}
